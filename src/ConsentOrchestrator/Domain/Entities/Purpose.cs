using ConsentOrchestrator.Domain.Common;
using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Domain.Entities;

/// <summary>
/// A purpose offered at a collection point, with the communication preferences
/// (and their options) and any other preferences it exposes. Identified by its
/// <see cref="PurposeId"/>, so it is an entity.
/// </summary>
public sealed class Purpose : Entity<PurposeId>
{
    public string Name { get; }
    public string Description { get; }
    public ConsentStatus Status { get; }
    public int Version { get; }
    public string PurposeType { get; }
    public CollectionPointId CollectionPointId { get; }
    public IReadOnlyList<CommunicationPreference> CommunicationPreferences { get; }
    public IReadOnlyList<OtherPreference> OtherPreferences { get; }

    public Purpose(
        PurposeId id,
        string name,
        string description,
        ConsentStatus status,
        int version,
        string purposeType,
        CollectionPointId collectionPointId,
        IReadOnlyList<CommunicationPreference> communicationPreferences,
        IReadOnlyList<OtherPreference> otherPreferences) : base(id)
    {
        Name = name;
        Description = description;
        Status = status;
        Version = version;
        PurposeType = purposeType;
        CollectionPointId = collectionPointId;
        CommunicationPreferences = communicationPreferences;
        OtherPreferences = otherPreferences;
    }

    /// <summary>The communication preference with the given id, or <c>null</c>.</summary>
    public CommunicationPreference? FindCommunicationPreference(Guid communicationPreferenceId) =>
        CommunicationPreferences.FirstOrDefault(c => c.Id == communicationPreferenceId);

    /// <summary>True when this purpose exposes an other-preference with the given id.</summary>
    public bool OffersOtherPreference(Guid otherPreferenceId) =>
        OtherPreferences.Any(o => o.Id == otherPreferenceId);
}