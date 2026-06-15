using ConsentOrchestrator.Domain.Common;
using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Domain.Aggregates;

/// <summary>
/// A purpose the user has expressed a decision on, as recorded inside the
/// <see cref="Consent"/> aggregate: the status plus the consented communication
/// preference options and other preferences. An internal member of the aggregate:
/// it is only ever created and reached through its root.
/// </summary>
public sealed class ConsentedPurpose : Entity<PurposeId>
{
    public ConsentStatus Status { get; }
    public IReadOnlyList<CommunicationPreferenceDecision> CommunicationPreferences { get; }
    public IReadOnlyList<PreferenceOption> OtherPreferences { get; }

    internal ConsentedPurpose(
        PurposeId id,
        ConsentStatus status,
        IReadOnlyList<CommunicationPreferenceDecision> communicationPreferences,
        IReadOnlyList<PreferenceOption> otherPreferences) : base(id)
    {
        Status = status;
        CommunicationPreferences = communicationPreferences;
        OtherPreferences = otherPreferences;
    }
}