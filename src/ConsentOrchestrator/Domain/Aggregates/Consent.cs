using ConsentOrchestrator.Domain.Common;
using ConsentOrchestrator.Domain.Entities;
using ConsentOrchestrator.Domain.Events;
using ConsentOrchestrator.Domain.Exceptions;
using ConsentOrchestrator.Domain.Interfaces;
using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Domain.Aggregates;

/// <summary>
/// Aggregate root capturing a user's consent decisions at a collection point.
/// It is the only entry point to its <see cref="ConsentedPurpose"/> members and
/// the single place where consent invariants are enforced. Recording a consent
/// raises the <see cref="ConsentUpdated"/> and <see cref="UnsubscribeLinkGenerated"/>
/// domain events.
/// </summary>
public sealed class Consent : AggregateRoot<ConsentId>
{
    private readonly List<ConsentedPurpose> _purposes;
    private readonly List<UnsubscribeLink> _unsubscribeLinks;

    public string Source { get; }
    public DateTimeOffset OccurredAt { get; }
    public IReadOnlyList<ConsentedPurpose> Purposes => _purposes;
    public IReadOnlyList<UnsubscribeLink> UnsubscribeLinks => _unsubscribeLinks;

    private Consent(
        ConsentId id,
        string source,
        List<ConsentedPurpose> purposes,
        List<UnsubscribeLink> unsubscribeLinks,
        DateTimeOffset occurredAt) : base(id)
    {
        Source = source;
        _purposes = purposes;
        _unsubscribeLinks = unsubscribeLinks;
        OccurredAt = occurredAt;
    }

    /// <summary>
    /// Factory that records a user's consent. Guarantees a valid aggregate at
    /// birth: there must be at least one decision, every decision must target a
    /// purpose offered at the collection point, every communication preference and
    /// preference option must be offered by that purpose, and every other
    /// preference must be one the purpose exposes. An unsubscribe link is generated
    /// per purpose and the matching domain events are raised.
    /// </summary>
    public static Consent Record(
        UserId userId,
        CollectionPointId collectionPointId,
        string source,
        IReadOnlyList<ConsentDecision> decisions,
        IReadOnlyList<Purpose> availablePurposes,
        IUnsubscribeLinkGenerator linkGenerator)
    {
        if (decisions.Count == 0)
            throw new InvalidConsentException("A consent must record at least one purpose decision.");

        var catalog = availablePurposes.ToDictionary(p => p.Id);
        var consentedPurposes = new List<ConsentedPurpose>(decisions.Count);

        foreach (var decision in decisions)
        {
            if (!catalog.TryGetValue(decision.PurposeId, out var purpose))
                throw new UnknownPurposeException(decision.PurposeId);

            foreach (var preference in decision.CommunicationPreferences)
            {
                var offered = purpose.FindCommunicationPreference(preference.CommunicationPreferenceId)
                    ?? throw new InvalidConsentException(
                        $"Purpose {decision.PurposeId} does not offer communication preference {preference.CommunicationPreferenceId}.");

                var unknownOption = preference.Options.FirstOrDefault(option => !offered.OffersOption(option.Id));
                if (unknownOption is not null)
                    throw new InvalidConsentException(
                        $"Communication preference {preference.CommunicationPreferenceId} does not offer option {unknownOption.Id}.");
            }

            var unknownOther = decision.OtherPreferences.FirstOrDefault(other => !purpose.OffersOtherPreference(other.Id));
            if (unknownOther is not null)
                throw new InvalidConsentException(
                    $"Purpose {decision.PurposeId} does not offer other preference {unknownOther.Id}.");

            consentedPurposes.Add(new ConsentedPurpose(
                decision.PurposeId,
                decision.Status,
                decision.CommunicationPreferences,
                decision.OtherPreferences));
        }

        var occurredAt = DateTimeOffset.UtcNow;

        var unsubscribeLinks = decisions
            .Select(decision => linkGenerator.Generate(userId, collectionPointId, decision.PurposeId))
            .ToList();

        var consent = new Consent(
            new ConsentId(userId, collectionPointId),
            source,
            consentedPurposes,
            unsubscribeLinks,
            occurredAt);

        consent.Raise(new ConsentUpdated(
            userId,
            collectionPointId,
            source,
            consentedPurposes.Select(ToUpdatedPurpose).ToList(),
            occurredAt));

        consent.Raise(new UnsubscribeLinkGenerated(userId, unsubscribeLinks, occurredAt));

        return consent;
    }

    private static UpdatedPurpose ToUpdatedPurpose(ConsentedPurpose purpose) => new(
        purpose.Id,
        purpose.Status.ToWireFormat(),
        purpose.CommunicationPreferences
            .Select(preference => new UpdatedCommunicationPreference(
                preference.CommunicationPreferenceId,
                preference.Options.Select(ToUpdatedOption).ToList()))
            .ToList(),
        purpose.OtherPreferences.Select(ToUpdatedOption).ToList());

    private static UpdatedPreferenceOption ToUpdatedOption(PreferenceOption option) =>
        new(option.Id, option.Type, option.IsConsented);
}