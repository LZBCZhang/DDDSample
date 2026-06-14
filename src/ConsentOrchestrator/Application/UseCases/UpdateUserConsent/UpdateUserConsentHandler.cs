using ConsentOrchestrator.Application.Contracts;
using ConsentOrchestrator.Application.Mappers;
using ConsentOrchestrator.Domain.Aggregates;
using ConsentOrchestrator.Domain.Entities;
using ConsentOrchestrator.Domain.Interfaces;
using ConsentOrchestrator.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace ConsentOrchestrator.Application.UseCases.UpdateUserConsent;

public class UpdateUserConsentHandler(
    IPurposeCacheService purposeCache,
    IOnetrustAdapterClient onetrustClient,
    IEventBus eventBus,
    IUnsubscribeLinkGenerator linkGenerator,
    ILogger<UpdateUserConsentHandler> logger)
{
    public async Task<UpdateUserConsentResult> HandleAsync(
        UpdateUserConsentCommand command,
        CancellationToken ct = default)
    {
        logger.LogInformation(
            "[{CorrelationId}] Handling UpdateUserConsent for user {UserId} / collectionPoint {CollectionPointId}",
            command.CorrelationId, command.UserId, command.CollectionPointId);

        // ── Resolve the purposes offered at this collection point (cache → adapter) ──
        var availablePurposes = await GetPurposesAsync(command.CollectionPointId, command.CorrelationId, ct);

        // ── Build a valid Consent aggregate: invariants are enforced and the
        //    ConsentUpdated / UnsubscribeLinkGenerated events are raised here. ──
        var consent = Consent.Record(
            command.UserId,
            command.CollectionPointId,
            command.Source,
            command.Decisions,
            availablePurposes,
            linkGenerator);

        // ── Persist the user's consents in OneTrust through the adapter (ACL). ──
        await onetrustClient.UpdateUserConsentsAsync(
            command.UserId,
            command.CollectionPointId,
            command.Decisions,
            command.CorrelationId,
            ct);

        logger.LogInformation(
            "[{CorrelationId}] Consents updated successfully in OneTrust for user {UserId}",
            command.CorrelationId, command.UserId);

        // ── Dispatch the domain events raised by the aggregate. ──
        foreach (var domainEvent in consent.DomainEvents)
            await eventBus.PublishAsync(domainEvent, ct);

        consent.ClearDomainEvents();

        logger.LogInformation(
            "[{CorrelationId}] Domain events published for user {UserId}",
            command.CorrelationId, command.UserId);

        return new UpdateUserConsentResult(consent.UnsubscribeLinks);
    }

    // ── Resolve purposes from cache, falling back to the OnetrustAdapter. ──
    private async Task<IReadOnlyList<Purpose>> GetPurposesAsync(
        CollectionPointId collectionPointId,
        string correlationId,
        CancellationToken ct)
    {
        var cached = await purposeCache.GetAsync(collectionPointId, ct);
        if (cached is not null)
        {
            logger.LogDebug(
                "[{CorrelationId}] Purposes cache hit for collectionPoint {CollectionPointId}",
                correlationId, collectionPointId);
            return cached;
        }

        logger.LogDebug(
            "[{CorrelationId}] Purposes cache miss — calling OnetrustAdapter for collectionPoint {CollectionPointId}",
            correlationId, collectionPointId);

        var dtos = await onetrustClient.GetPurposesAsync(collectionPointId, correlationId, ct);
        var purposes = dtos.Select(ConsentMapper.ToDomain).ToList();

        await purposeCache.SetAsync(collectionPointId, purposes, ct);

        return purposes;
    }
}
