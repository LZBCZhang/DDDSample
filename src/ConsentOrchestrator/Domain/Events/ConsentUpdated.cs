using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Domain.Events;

public record ConsentUpdated(
    UserId UserId,
    CollectionPointId CollectionPointId,
    string Source,
    IReadOnlyList<UpdatedPurpose> Purposes,
    DateTimeOffset OccurredAt) : IDomainEvent;

public record UpdatedPurpose(
    PurposeId PurposeId,
    string Status,
    IReadOnlyList<UpdatedCommunicationPreference> CommunicationPreferences,
    IReadOnlyList<UpdatedPreferenceOption> OtherPreferences);

public record UpdatedCommunicationPreference(
    Guid CommunicationPreferenceId,
    IReadOnlyList<UpdatedPreferenceOption> Options);

public record UpdatedPreferenceOption(
    Guid Id,
    string Type,
    bool IsConsented);