using ConsentOrchestrator.Application.DTOs.Responses;
using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Application.Contracts;

public interface IOnetrustAdapterClient
{
    Task<IReadOnlyList<PurposeResponse>> GetPurposesAsync(
        CollectionPointId collectionPointId,
        string correlationId,
        CancellationToken ct = default);

    Task UpdateUserConsentsAsync(
        UserId userId,
        CollectionPointId collectionPointId,
        IReadOnlyList<ConsentDecision> decisions,
        string correlationId,
        CancellationToken ct = default);
}
