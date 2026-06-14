using OnetrustAdapter.Application.DTOs.Requests;
using OnetrustAdapter.Application.DTOs.Responses;

namespace OnetrustAdapter.Application.Contracts;

public interface IOnetrustApiClient
{
    Task<IReadOnlyList<PurposeResponse>> GetPurposesAsync(Guid collectionPointId, CancellationToken ct = default);
    Task UpdateUserConsentsAsync(UpdateUserConsentRequest request, CancellationToken ct = default);
}
