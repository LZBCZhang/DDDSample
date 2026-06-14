namespace OnetrustAdapter.Application.DTOs.Responses;

public record PurposeResponse(
    Guid Id,
    string Name,
    string Description,
    IReadOnlyList<CommunicationResponse> Communications);

public record CommunicationResponse(
    Guid Id,
    string Type);
