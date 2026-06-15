using ConsentOrchestrator.Application.DTOs.Enums;
using ConsentOrchestrator.Application.DTOs.Requests;
using ConsentOrchestrator.Application.DTOs.Responses;
using ConsentOrchestrator.Application.UseCases.UpdateUserConsent;
using ConsentOrchestrator.Domain.Entities;
using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Application.Mappers;

public static class ConsentMapper
{
    public static UpdateUserConsentCommand ToCommand(
        Guid userId,
        Guid collectionPointId,
        UpdateUserConsentRequest request,
        string correlationId) => new(
            UserId.From(userId),
            CollectionPointId.From(collectionPointId),
            request.Source,
            request.Purposes.Select(ToDecision).ToList(),
            correlationId);

    public static Purpose ToDomain(PurposeResponse dto) => new(
        PurposeId.From(dto.Id),
        dto.Name,
        dto.Description,
        ConsentStatusExtensions.FromWireFormat(dto.Status),
        dto.Version,
        dto.PurposeType,
        CollectionPointId.From(dto.CollectionPointId),
        dto.CommunicationPreferences.Select(ToCommunicationPreference).ToList(),
        dto.OtherPreferences.Select(o => new OtherPreference(o.Id, o.Type, o.IsConsented)).ToList());

    public static UpdateUserConsentResponse ToResponse(
        UserId userId,
        CollectionPointId collectionPointId,
        IReadOnlyList<UnsubscribeLink> links) => new(
            userId.Value,
            collectionPointId.Value,
            "SUCCESS",
            links.Select(l => new UnsubscribeLinkResponse(l.PurposeId.Value, l.Url)).ToList());

    private static CommunicationPreference ToCommunicationPreference(CommunicationPreferenceResponse dto) => new(
        dto.Id,
        dto.Name,
        dto.Description,
        dto.Version,
        CommunicationPreferenceTypeExtensions.FromWireFormat(dto.CommunicationType),
        dto.PreferenceOptions.Select(o => new PreferenceOption(o.Id, o.Type, o.IsConsented)).ToList());

    private static ConsentDecision ToDecision(PurposeConsentRequest request) => new(
        PurposeId.From(request.Id),
        ToStatus(request.Status),
        request.CommunicationPreferences.Select(c => new CommunicationPreferenceDecision(
            c.Id,
            c.Options.Select(o => new PreferenceOption(o.Id, o.Type, o.IsConsented)).ToList())).ToList(),
        request.OtherPreferences.Select(o => new PreferenceOption(o.Id, o.Type, o.IsConsented)).ToList());

    private static ConsentStatus ToStatus(ConsentStatusDto status) => status switch
    {
        ConsentStatusDto.CONFIRMED => ConsentStatus.Confirmed,
        ConsentStatusDto.DECLINED => ConsentStatus.Declined,
        ConsentStatusDto.PENDING => ConsentStatus.Pending,
        _ => throw new ArgumentOutOfRangeException(nameof(status), status, "Unknown consent status.")
    };
}