using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using OnetrustAdapter.Application.Contracts;
using OnetrustAdapter.Application.DTOs.Requests;
using OnetrustAdapter.Application.DTOs.Responses;

namespace OnetrustAdapter.Infrastructure.Http;

public class OnetrustApiClient(
    HttpClient httpClient,
    ILogger<OnetrustApiClient> logger) : IOnetrustApiClient
{
    public async Task<IReadOnlyList<PurposeResponse>> GetPurposesAsync(
        Guid collectionPointId,
        CancellationToken ct = default)
    {
        logger.LogInformation("GET OneTrust purposes for collectionPoint {CollectionPointId}", collectionPointId);

        var response = await httpClient.GetAsync($"api/purposes?collectionPointId={collectionPointId}", ct);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IReadOnlyList<PurposeResponse>>(ct)
            ?? [];
    }

    public async Task UpdateUserConsentsAsync(
        UpdateUserConsentRequest request,
        CancellationToken ct = default)
    {
        logger.LogInformation("POST OneTrust update consents for user {UserId}", request.UserId);

        var response = await httpClient.PostAsJsonAsync("api/consents", request, ct);
        response.EnsureSuccessStatusCode();
    }
}
