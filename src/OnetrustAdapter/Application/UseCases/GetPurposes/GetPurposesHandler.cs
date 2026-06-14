using OnetrustAdapter.Application.Contracts;
using OnetrustAdapter.Application.DTOs.Responses;
using Microsoft.Extensions.Logging;

namespace OnetrustAdapter.Application.UseCases.GetPurposes;

public class GetPurposesHandler(
    IPurposeCacheService cache,
    IOnetrustApiClient onetrustClient,
    ILogger<GetPurposesHandler> logger)
{
    public async Task<IReadOnlyList<PurposeResponse>> HandleAsync(
        Guid collectionPointId,
        CancellationToken ct = default)
    {
        var cached = await cache.GetAsync(collectionPointId, ct);
        if (cached is not null)
        {
            logger.LogDebug("Purposes cache hit for {CollectionPointId}", collectionPointId);
            return cached;
        }

        logger.LogDebug("Purposes cache miss — fetching from OneTrust API for {CollectionPointId}", collectionPointId);

        var purposes = await onetrustClient.GetPurposesAsync(collectionPointId, ct);
        await cache.SetAsync(collectionPointId, purposes, ct);

        return purposes;
    }
}
