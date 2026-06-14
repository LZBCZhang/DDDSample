using System.Net;
using System.Text;
using System.Text.Json;

namespace ConsentOrchestrator.Tests.Acceptance;

/// <summary>
/// In-memory primary handler standing in for the OnetrustAdapter HTTP API.
/// Serves the two endpoints the real <c>OnetrustAdapterClient</c> calls and
/// records the requests so tests can assert on them.
/// </summary>
internal sealed class FakeOnetrustHandler(ConsentApiFactory factory) : HttpMessageHandler
{
    private readonly ConsentApiFactory _factory = factory;

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _factory.ReceivedCorrelationIds.Add(
            request.Headers.TryGetValues("X-Correlation-Id", out var values)
                ? values.FirstOrDefault()
                : null);

        var path = request.RequestUri!.AbsolutePath;

        if (request.Method == HttpMethod.Get && path.Contains("/purposes/", StringComparison.Ordinal))
            return Task.FromResult(GetPurposes());

        if (request.Method == HttpMethod.Post && path.Contains("/consents", StringComparison.Ordinal))
            return Task.FromResult(UpdateConsents());

        return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound));
    }

    private HttpResponseMessage GetPurposes()
    {
        _factory.GetPurposesCallCount++;

        if (_factory.GetPurposesStatus != HttpStatusCode.OK)
            return new HttpResponseMessage(_factory.GetPurposesStatus);

        var json = _factory.GetPurposesReturnsNullBody
            ? "null"
            : JsonSerializer.Serialize(_factory.AvailablePurposes);

        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json"),
        };
    }

    private HttpResponseMessage UpdateConsents()
    {
        _factory.UpdateConsentsCallCount++;
        return new HttpResponseMessage(_factory.UpdateConsentsStatus);
    }
}