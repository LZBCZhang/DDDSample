namespace ConsentOrchestrator.Application.DTOs.Responses;

public record UpdateUserConsentResponse(
    Guid UserId,
    Guid CollectionPointId,
    string Status,
    IReadOnlyList<UnsubscribeLinkResponse> UnsubscribeLinks);

public record UnsubscribeLinkResponse(
    Guid PurposeId,
    string Url);
