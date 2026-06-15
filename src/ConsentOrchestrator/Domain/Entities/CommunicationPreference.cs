using ConsentOrchestrator.Domain.Common;
using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Domain.Entities;

/// <summary>
/// A communication preference offered by a purpose (e.g. Email, SMS) together
/// with the preference options it exposes. Identified by its id, so it is an
/// entity; its options are value objects.
/// </summary>
public sealed class CommunicationPreference : Entity<Guid>
{
    public string Name { get; }
    public string Description { get; }
    public int Version { get; }
    public CommunicationPreferenceType CommunicationType { get; }
    public IReadOnlyList<PreferenceOption> PreferenceOptions { get; }

    public CommunicationPreference(
        Guid id,
        string name,
        string description,
        int version,
        CommunicationPreferenceType communicationType,
        IReadOnlyList<PreferenceOption> preferenceOptions) : base(id)
    {
        Name = name;
        Description = description;
        Version = version;
        CommunicationType = communicationType;
        PreferenceOptions = preferenceOptions;
    }

    /// <summary>True when this preference exposes an option with the given id.</summary>
    public bool OffersOption(Guid optionId) => PreferenceOptions.Any(o => o.Id == optionId);
}