using ConsentOrchestrator.Domain.Entities;
using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Application.Contracts;

public interface IPurposeCacheService
{
    Task<IReadOnlyList<Purpose>?> GetAsync(CollectionPointId collectionPointId, CancellationToken ct = default);
    Task SetAsync(CollectionPointId collectionPointId, IReadOnlyList<Purpose> purposes, CancellationToken ct = default);
}
