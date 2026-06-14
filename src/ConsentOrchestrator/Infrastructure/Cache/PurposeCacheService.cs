using ConsentOrchestrator.Application.Contracts;
using ConsentOrchestrator.Domain.Entities;
using ConsentOrchestrator.Domain.ValueObjects;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace ConsentOrchestrator.Infrastructure.Cache;

public class PurposeCacheService(
    IMemoryCache cache,
    ILogger<PurposeCacheService> logger) : IPurposeCacheService
{
    private static string CacheKey(CollectionPointId id) => $"purposes:{id}";
    private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(30);

    public Task<IReadOnlyList<Purpose>?> GetAsync(CollectionPointId collectionPointId, CancellationToken ct = default)
    {
        cache.TryGetValue(CacheKey(collectionPointId), out IReadOnlyList<Purpose>? purposes);

        if (purposes is not null)
            logger.LogDebug("Purposes cache hit for {CollectionPointId}", collectionPointId);

        return Task.FromResult(purposes);
    }

    public Task SetAsync(CollectionPointId collectionPointId, IReadOnlyList<Purpose> purposes, CancellationToken ct = default)
    {
        cache.Set(CacheKey(collectionPointId), purposes, CacheDuration);

        logger.LogDebug("Purposes cached for {CollectionPointId} — TTL {TTL}min", collectionPointId, CacheDuration.TotalMinutes);

        return Task.CompletedTask;
    }
}
