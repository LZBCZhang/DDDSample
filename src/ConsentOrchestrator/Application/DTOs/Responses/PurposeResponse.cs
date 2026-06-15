namespace ConsentOrchestrator.Application.DTOs.Responses;

public record PurposeResponse(
    Guid Id,
    string Name,
    string Description,
    string Status,
    int Version,
    string PurposeType,
    Guid CollectionPointId,
    IReadOnlyList<CommunicationPreferenceResponse> CommunicationPreferences,
    IReadOnlyList<PreferenceOptionResponse> OtherPreferences);

public record CommunicationPreferenceResponse(
    Guid Id,
    string Name,
    string Description,
    int Version,
    string CommunicationType,
    IReadOnlyList<PreferenceOptionResponse> PreferenceOptions);

public record PreferenceOptionResponse(
    Guid Id,
    string Type,
    bool IsConsented);