using ConsentOrchestrator.Domain.Common;
using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Domain.Aggregates;

/// <summary>
/// A purpose the user has expressed a decision on, as recorded inside the
/// <see cref="Consent"/> aggregate. An internal member of the aggregate: it is
/// only ever created and reached through its root.
/// </summary>
public sealed class ConsentedPurpose : Entity<PurposeId>
{
    public ConsentStatus Status { get; }
    public IReadOnlyList<string> Communications { get; }

    internal ConsentedPurpose(PurposeId id, ConsentStatus status, IReadOnlyList<string> communications)
        : base(id)
    {
        Status = status;
        Communications = communications;
    }
}
