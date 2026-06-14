using ConsentOrchestrator.Domain.Events;

namespace ConsentOrchestrator.Domain.Common;

/// <summary>
/// Base class for aggregate roots — the single entry point of an aggregate that
/// guards its invariants. Behaviour that changes the aggregate's state records
/// the corresponding <see cref="IDomainEvent"/> here; the application layer
/// dispatches those events once the change is committed.
/// </summary>
public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

    protected AggregateRoot(TId id) : base(id) { }

    protected void Raise(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    public void ClearDomainEvents() => _domainEvents.Clear();
}