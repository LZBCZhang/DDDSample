using ConsentOrchestrator.Domain.Common;
using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Domain.Entities;

/// <summary>
/// A purpose offered at a collection point, together with the communication
/// channels it supports. Identified by its <see cref="PurposeId"/>, so it is
/// an entity; its supported channels are value objects.
/// </summary>
public sealed class Purpose : Entity<PurposeId>
{
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<CommunicationChannel> Channels { get; }

    public Purpose(PurposeId id, string name, string description, IReadOnlyList<CommunicationChannel> channels)
        : base(id)
    {
        Name = name;
        Description = description;
        Channels = channels;
    }

    /// <summary>True when this purpose offers a channel of the given type.</summary>
    public bool OffersChannel(string channelType) =>
        Channels.Any(c => string.Equals(c.Type, channelType, StringComparison.OrdinalIgnoreCase));
}
