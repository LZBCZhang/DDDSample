using System.Net;
using ConsentOrchestrator.Domain.Interfaces;
using ConsentOrchestrator.Domain.ValueObjects;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace ConsentOrchestrator.Tests.Acceptance;

/// <summary>
/// End-to-end acceptance tests for the email one-click unsubscribe endpoint
/// (<c>GET api/consent/unsubscribe</c>).
/// </summary>
public sealed class UnsubscribeAcceptanceTests : IDisposable
{
    private readonly ConsentApiFactory _factory = new();
    private readonly HttpClient _client;

    public UnsubscribeAcceptanceTests() => _client = _factory.CreateClient();

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    // Mints a token with the same signing service the server uses.
    private string MintToken(Guid userId, Guid collectionPointId, Guid purposeId)
    {
        var hmac = _factory.Services.GetRequiredService<IHmacTokenGenerator>();
        return UnsubscribeToken.Generate(
            hmac,
            UserId.From(userId),
            CollectionPointId.From(collectionPointId),
            PurposeId.From(purposeId)).Value;
    }

    [Fact]
    public async Task Unsubscribe_WithValidToken_WithdrawsConsentAtAdapter_Returns200()
    {
        var token = MintToken(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

        var response = await _client.GetAsync($"api/consent/unsubscribe?token={token}");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        _factory.UpdateConsentsCallCount.Should().Be(1);
        // Unsubscribe never needs the purpose catalog.
        _factory.GetPurposesCallCount.Should().Be(0);
    }

    [Fact]
    public async Task Unsubscribe_WithTamperedToken_Returns400_AndDoesNotCallAdapter()
    {
        var tampered = MintToken(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()) + "x";

        var response = await _client.GetAsync($"api/consent/unsubscribe?token={tampered}");

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        _factory.UpdateConsentsCallCount.Should().Be(0);
    }

    [Fact]
    public async Task Unsubscribe_WithMalformedToken_Returns400()
    {
        var response = await _client.GetAsync("api/consent/unsubscribe?token=not-a-real-token");

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        _factory.UpdateConsentsCallCount.Should().Be(0);
    }

    [Fact]
    public async Task Unsubscribe_WhenAdapterRejects_Returns502()
    {
        var token = MintToken(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
        _factory.UpdateConsentsStatus = HttpStatusCode.BadRequest;

        var response = await _client.GetAsync($"api/consent/unsubscribe?token={token}");

        response.StatusCode.Should().Be(HttpStatusCode.BadGateway);
    }
}