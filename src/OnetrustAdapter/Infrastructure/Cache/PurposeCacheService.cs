using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using OnetrustAdapter.Application.Contracts;
using OnetrustAdapter.Application.DTOs.Responses;

namespace OnetrustAdapter.Infrastructure.Cache;

public class PurposeCacheService(
    IMemoryCache cache,
    ILogger<PurposeCacheService> logger) : IPurposeCacheService
{
    private static string Key(Guid id) => $"ot:purposes:{id}";
    private static readonly TimeSpan Ttl = TimeSpan.FromMinutes(60);

    public Task<IReadOnlyList<PurposeResponse>?> GetAsync(Guid collectionPointId, CancellationToken ct = default)
    {
        cache.TryGetValue(Key(collectionPointId), out IReadOnlyList<PurposeResponse>? result);
        return Task.FromResult(result);
    }

    public Task SetAsync(Guid collectionPointId, IReadOnlyList<PurposeResponse> purposes, CancellationToken ct = default)
    {
        cache.Set(Key(collectionPointId), purposes, Ttl);
        logger.LogDebug("Purposes cached for {CollectionPointId} — TTL {Ttl}min", collectionPointId, Ttl.TotalMinutes);
        return Task.CompletedTask;
    }
}
