using OnetrustAdapter.Application.Contracts;
using OnetrustAdapter.Application.DTOs.Requests;
using Microsoft.Extensions.Logging;

namespace OnetrustAdapter.Application.UseCases.UpdateUserConsent;

public class UpdateUserConsentHandler(
    IOnetrustApiClient onetrustClient,
    ILogger<UpdateUserConsentHandler> logger)
{
    public async Task HandleAsync(
        UpdateUserConsentRequest request,
        CancellationToken ct = default)
    {
        logger.LogInformation(
            "Forwarding consent update to OneTrust for user {UserId} / collectionPoint {CollectionPointId}",
            request.UserId, request.CollectionPointId);

        await onetrustClient.UpdateUserConsentsAsync(request, ct);

        logger.LogInformation(
            "Consent update forwarded successfully to OneTrust for user {UserId}",
            request.UserId);
    }
}
