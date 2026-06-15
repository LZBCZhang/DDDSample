using System.Net.Http.Json;
using System.Text.Json;
using ConsentOrchestrator.Application.Contracts;
using ConsentOrchestrator.Application.DTOs.Responses;
using ConsentOrchestrator.Domain.Exceptions;
using ConsentOrchestrator.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace ConsentOrchestrator.Infrastructure.Http;

public class OnetrustAdapterClient(
    HttpClient httpClient,
    ILogger<OnetrustAdapterClient> logger) : IOnetrustAdapterClient
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    // ── Get Purposes ──────────────────────────────────────────────────
    public async Task<IReadOnlyList<PurposeResponse>> GetPurposesAsync(
        CollectionPointId collectionPointId,
        string correlationId,
        CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"api/onetrust/purposes/{collectionPointId}");

        request.Headers.Add("X-Correlation-Id", correlationId);

        logger.LogInformation(
            "[{CorrelationId}] GET purposes from OnetrustAdapter — collectionPoint {CollectionPointId}",
            correlationId, collectionPointId);

        var response = await httpClient.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();

        var purposes = await response.Content.ReadFromJsonAsync<IReadOnlyList<PurposeResponse>>(JsonOptions, ct)
            ?? throw new PurposesNotFoundException(collectionPointId);

        return purposes;
    }

    // ── Update User Consents ──────────────────────────────────────────
    public async Task UpdateUserConsentsAsync(
        UserId userId,
        CollectionPointId collectionPointId,
        IReadOnlyList<ConsentDecision> decisions,
        string correlationId,
        CancellationToken ct = default)
    {
        // Translate the domain decisions into the OneTrust payload format (ACL).
        var payload = new OnetrustUpdatePayload(
            userId.Value,
            collectionPointId.Value,
            decisions.Select(decision => new OnetrustPurposePayload(
                decision.PurposeId.Value,
                decision.Status.ToWireFormat(),
                decision.CommunicationPreferences.Select(preference => new OnetrustCommunicationPayload(
                    preference.CommunicationPreferenceId,
                    preference.Options.Select(option => new OnetrustCommunicationOption(
                        option.Id,
                        option.IsConsented)).ToList()
                )).ToList()
            )).ToList());

        using var httpRequest = new HttpRequestMessage(
            HttpMethod.Post,
            $"api/onetrust/users/{userId}/consents");

        httpRequest.Headers.Add("X-Correlation-Id", correlationId);
        httpRequest.Content = JsonContent.Create(payload);

        logger.LogInformation(
            "[{CorrelationId}] POST update consents to OnetrustAdapter — user {UserId}",
            correlationId, userId);

        var response = await httpClient.SendAsync(httpRequest, ct);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(ct);
            logger.LogError(
                "[{CorrelationId}] OnetrustAdapter returned {StatusCode}: {Body}",
                correlationId, response.StatusCode, body);

            throw new ConsentUpdateException(
                $"OnetrustAdapter failed with {response.StatusCode}: {body}");
        }

        logger.LogInformation(
            "[{CorrelationId}] Consents successfully sent to OnetrustAdapter for user {UserId}",
            correlationId, userId);
    }

    // ── Onetrust Payload Models (internal to ACL) ─────────────────────
    private record OnetrustUpdatePayload(
        Guid UserId,
        Guid CollectionPointId,
        IReadOnlyList<OnetrustPurposePayload> Purposes);

    private record OnetrustPurposePayload(
        Guid PurposeId,
        string Status,
        IReadOnlyList<OnetrustCommunicationPayload> CommunicationsPreferences);

    private record OnetrustCommunicationPayload(
        Guid Id,
        IReadOnlyList<OnetrustCommunicationOption> Options);

    private record OnetrustCommunicationOption(
        Guid Id,
        bool IsConsented);
}
