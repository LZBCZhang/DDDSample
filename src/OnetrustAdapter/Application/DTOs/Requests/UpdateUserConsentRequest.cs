namespace OnetrustAdapter.Application.DTOs.Requests;

/// <summary>
/// Payload expected by OnetrustAdapter — maps to OneTrust API format.
/// </summary>
public record UpdateUserConsentRequest(
    Guid UserId,
    Guid CollectionPointId,
    IReadOnlyList<PurposeRequest> Purposes);

public record PurposeRequest(
    Guid PurposeId,
    string Status,
    IReadOnlyList<CommunicationPreferenceRequest> CommunicationsPreferences);

public record CommunicationPreferenceRequest(
    Guid Id,
    IReadOnlyList<CommunicationOptionRequest> Options);

public record CommunicationOptionRequest(
    Guid Id,
    bool IsConsented);
