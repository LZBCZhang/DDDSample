using OnetrustAdapter.Application.DTOs.Responses;

namespace OnetrustAdapter.Application.Contracts;

public interface IPurposeCacheService
{
    Task<IReadOnlyList<PurposeResponse>?> GetAsync(Guid collectionPointId, CancellationToken ct = default);
    Task SetAsync(Guid collectionPointId, IReadOnlyList<PurposeResponse> purposes, CancellationToken ct = default);
}
