using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using ConsentOrchestrator.Application.DTOs.Enums;
using ConsentOrchestrator.Application.DTOs.Requests;
using ConsentOrchestrator.Application.DTOs.Responses;
using ConsentOrchestrator.API.Middlewares;
using FluentAssertions;

namespace ConsentOrchestrator.Tests.Acceptance;

/// <summary>
/// End-to-end acceptance tests driving the public HTTP surface of the
/// ConsentOrchestrator API. Each test owns a fresh in-memory host (and thus a
/// fresh cache) for isolation.
/// </summary>
public sealed class UpdateUserConsentAcceptanceTests : IDisposable
{
    private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNameCaseInsensitive = true };

    private readonly ConsentApiFactory _factory = new();
    private readonly HttpClient _client;

    public UpdateUserConsentAcceptanceTests() => _client = _factory.CreateClient();

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    // ── Helpers ───────────────────────────────────────────────────────
    private static PurposeResponse Purpose(Guid id, params string[] channels) =>
        new(id, "Marketing", "Marketing purpose",
            channels.Select(c => new CommunicationResponse(Guid.NewGuid(), c)).ToList());

    private async Task<HttpResponseMessage> PostAsync(
        Guid userId, Guid collectionPointId, object body, string? correlationId = null)
    {
        using var request = new HttpRequestMessage(
            HttpMethod.Post, $"api/consent/user/{userId}/{collectionPointId}")
        {
            Content = JsonContent.Create(body),
        };

        if (correlationId is not null)
            request.Headers.Add(CorrelationIdMiddleware.HeaderName, correlationId);

        return await _client.SendAsync(request);
    }

    private sealed record ApiResponse(
        Guid UserId, Guid CollectionPointId, string Status, List<ApiLink> UnsubscribeLinks);

    private sealed record ApiLink(Guid PurposeId, string Url);

    // ── Happy path ────────────────────────────────────────────────────
    [Fact]
    public async Task UpdateUserConsent_WithValidDecision_Returns200_WithUnsubscribeLink_AndPublishesEvents()
    {
        var userId = Guid.NewGuid();
        var collectionPointId = Guid.NewGuid();
        var purposeId = Guid.NewGuid();
        _factory.AvailablePurposes.Add(Purpose(purposeId, "EMAIL"));

        var body = new UpdateUserConsentRequest("web",
            [new PurposeRequest(purposeId, ConsentStatusDto.CONFIRMED, ["EMAIL"])]);

        var httpResponse = await PostAsync(userId, collectionPointId, body);

        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var response = await httpResponse.Content.ReadFromJsonAsync<ApiResponse>(JsonOptions);
        response!.UserId.Should().Be(userId);
        response.CollectionPointId.Should().Be(collectionPointId);
        response.Status.Should().Be("SUCCESS");
        response.UnsubscribeLinks.Should().ContainSingle()
            .Which.PurposeId.Should().Be(purposeId);
        response.UnsubscribeLinks[0].Url.Should().StartWith("https://frontend.test/unsubscribe?token=");

        // Both domain events were published to Service Bus.
        _factory.PublishedMessages.Select(m => m.Subject)
            .Should().BeEquivalentTo("ConsentUpdated", "UnsubscribeLinkGenerated");

        // The consents were forwarded to the OneTrust adapter.
        _factory.UpdateConsentsCallCount.Should().Be(1);
    }

    [Fact]
    public async Task UpdateUserConsent_WithSeveralStatusesAndChannels_Returns200()
    {
        var userId = Guid.NewGuid();
        var collectionPointId = Guid.NewGuid();
        var confirmed = Guid.NewGuid();
        var declined = Guid.NewGuid();
        var pending = Guid.NewGuid();
        var push = Guid.NewGuid();
        var sms = Guid.NewGuid();

        _factory.AvailablePurposes.AddRange(
        [
            Purpose(confirmed, "EMAIL"),
            Purpose(declined, "EMAIL"),
            Purpose(pending, "EMAIL"),
            Purpose(push, "PUSH-NOTIFICATION"),
            Purpose(sms, "SMS"),
        ]);

        var body = new UpdateUserConsentRequest("mobile",
        [
            new PurposeRequest(confirmed, ConsentStatusDto.CONFIRMED, ["EMAIL"]),
            new PurposeRequest(declined, ConsentStatusDto.DECLINED, ["EMAIL"]),
            new PurposeRequest(pending, ConsentStatusDto.PENDING, []),
            new PurposeRequest(push, ConsentStatusDto.CONFIRMED, ["PUSH-NOTIFICATION"]),
            new PurposeRequest(sms, ConsentStatusDto.CONFIRMED, ["SMS"]),
        ]);

        var httpResponse = await PostAsync(userId, collectionPointId, body);

        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var response = await httpResponse.Content.ReadFromJsonAsync<ApiResponse>(JsonOptions);
        response!.UnsubscribeLinks.Should().HaveCount(5);
    }

    // ── Caching ───────────────────────────────────────────────────────
    [Fact]
    public async Task UpdateUserConsent_SecondCallForSameCollectionPoint_HitsCache()
    {
        var collectionPointId = Guid.NewGuid();
        var purposeId = Guid.NewGuid();
        _factory.AvailablePurposes.Add(Purpose(purposeId, "EMAIL"));

        var body = new UpdateUserConsentRequest("web",
            [new PurposeRequest(purposeId, ConsentStatusDto.CONFIRMED, ["EMAIL"])]);

        var first = await PostAsync(Guid.NewGuid(), collectionPointId, body);
        var second = await PostAsync(Guid.NewGuid(), collectionPointId, body);

        first.StatusCode.Should().Be(HttpStatusCode.OK);
        second.StatusCode.Should().Be(HttpStatusCode.OK);

        // Purposes resolved from OneTrust once, then served from cache.
        _factory.GetPurposesCallCount.Should().Be(1);
    }

    // ── Correlation id ────────────────────────────────────────────────
    [Fact]
    public async Task UpdateUserConsent_WithCorrelationIdHeader_EchoesItAndPropagatesItDownstream()
    {
        const string correlationId = "corr-acceptance-123";
        var collectionPointId = Guid.NewGuid();
        var purposeId = Guid.NewGuid();
        _factory.AvailablePurposes.Add(Purpose(purposeId, "EMAIL"));

        var body = new UpdateUserConsentRequest("web",
            [new PurposeRequest(purposeId, ConsentStatusDto.CONFIRMED, ["EMAIL"])]);

        var httpResponse = await PostAsync(Guid.NewGuid(), collectionPointId, body, correlationId);

        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        httpResponse.Headers.GetValues(CorrelationIdMiddleware.HeaderName).Should().ContainSingle()
            .Which.Should().Be(correlationId);
        _factory.ReceivedCorrelationIds.Should().AllBeEquivalentTo(correlationId);
    }

    [Fact]
    public async Task UpdateUserConsent_WithoutCorrelationIdHeader_GeneratesOne()
    {
        var collectionPointId = Guid.NewGuid();
        var purposeId = Guid.NewGuid();
        _factory.AvailablePurposes.Add(Purpose(purposeId, "EMAIL"));

        var body = new UpdateUserConsentRequest("web",
            [new PurposeRequest(purposeId, ConsentStatusDto.CONFIRMED, ["EMAIL"])]);

        var httpResponse = await PostAsync(Guid.NewGuid(), collectionPointId, body);

        var generated = httpResponse.Headers.GetValues(CorrelationIdMiddleware.HeaderName).Single();
        generated.Should().NotBeNullOrWhiteSpace();
        Guid.TryParse(generated, out _).Should().BeTrue();
    }

    // ── Domain invariant violations → 400 ─────────────────────────────
    [Fact]
    public async Task UpdateUserConsent_WithNoDecisions_Returns400()
    {
        var body = new UpdateUserConsentRequest("web", []);

        var httpResponse = await PostAsync(Guid.NewGuid(), Guid.NewGuid(), body);

        httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        await AssertErrorBody(httpResponse);
    }

    [Fact]
    public async Task UpdateUserConsent_WithUnknownPurpose_Returns400()
    {
        var collectionPointId = Guid.NewGuid();
        _factory.AvailablePurposes.Add(Purpose(Guid.NewGuid(), "EMAIL"));

        var body = new UpdateUserConsentRequest("web",
            [new PurposeRequest(Guid.NewGuid(), ConsentStatusDto.CONFIRMED, ["EMAIL"])]);

        var httpResponse = await PostAsync(Guid.NewGuid(), collectionPointId, body);

        httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        await AssertErrorBody(httpResponse);
    }

    [Fact]
    public async Task UpdateUserConsent_WithChannelNotOfferedByPurpose_Returns400()
    {
        var collectionPointId = Guid.NewGuid();
        var purposeId = Guid.NewGuid();
        _factory.AvailablePurposes.Add(Purpose(purposeId, "EMAIL"));

        var body = new UpdateUserConsentRequest("web",
            [new PurposeRequest(purposeId, ConsentStatusDto.CONFIRMED, ["SMS"])]);

        var httpResponse = await PostAsync(Guid.NewGuid(), collectionPointId, body);

        httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        await AssertErrorBody(httpResponse);
    }

    // ── Downstream / mapper failures ──────────────────────────────────
    [Fact]
    public async Task UpdateUserConsent_WhenAdapterRejectsUpdate_Returns502()
    {
        var collectionPointId = Guid.NewGuid();
        var purposeId = Guid.NewGuid();
        _factory.AvailablePurposes.Add(Purpose(purposeId, "EMAIL"));
        _factory.UpdateConsentsStatus = HttpStatusCode.BadRequest; // adapter rejects

        var body = new UpdateUserConsentRequest("web",
            [new PurposeRequest(purposeId, ConsentStatusDto.CONFIRMED, ["EMAIL"])]);

        var httpResponse = await PostAsync(Guid.NewGuid(), collectionPointId, body);

        httpResponse.StatusCode.Should().Be(HttpStatusCode.BadGateway);
        await AssertErrorBody(httpResponse);
    }

    [Fact]
    public async Task UpdateUserConsent_WhenAdapterReturnsNoPurposes_Returns404()
    {
        var collectionPointId = Guid.NewGuid();
        var purposeId = Guid.NewGuid();
        _factory.GetPurposesReturnsNullBody = true; // null body → PurposesNotFoundException

        var body = new UpdateUserConsentRequest("web",
            [new PurposeRequest(purposeId, ConsentStatusDto.CONFIRMED, ["EMAIL"])]);

        var httpResponse = await PostAsync(Guid.NewGuid(), collectionPointId, body);

        httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        await AssertErrorBody(httpResponse);
    }

    [Fact]
    public async Task UpdateUserConsent_WhenAdapterPurposesCallFails_Returns500()
    {
        var collectionPointId = Guid.NewGuid();
        var purposeId = Guid.NewGuid();
        _factory.GetPurposesStatus = HttpStatusCode.BadRequest; // EnsureSuccessStatusCode throws

        var body = new UpdateUserConsentRequest("web",
            [new PurposeRequest(purposeId, ConsentStatusDto.CONFIRMED, ["EMAIL"])]);

        var httpResponse = await PostAsync(Guid.NewGuid(), collectionPointId, body);

        httpResponse.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        await AssertErrorBody(httpResponse);
    }

    [Fact]
    public async Task UpdateUserConsent_WithUnknownStatusValue_Returns500()
    {
        var collectionPointId = Guid.NewGuid();
        var purposeId = Guid.NewGuid();
        _factory.AvailablePurposes.Add(Purpose(purposeId, "EMAIL"));

        // status 99 is outside ConsentStatusDto → mapper throws ArgumentOutOfRangeException.
        var body = new
        {
            source = "web",
            purposes = new[]
            {
                new { id = purposeId, status = 99, communications = new[] { "EMAIL" } },
            },
        };

        var httpResponse = await PostAsync(Guid.NewGuid(), collectionPointId, body);

        httpResponse.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        await AssertErrorBody(httpResponse);
    }

    private static async Task AssertErrorBody(HttpResponseMessage response)
    {
        var payload = await response.Content.ReadFromJsonAsync<JsonElement>();
        payload.TryGetProperty("error", out var error).Should().BeTrue();
        error.GetString().Should().NotBeNullOrWhiteSpace();
    }
}