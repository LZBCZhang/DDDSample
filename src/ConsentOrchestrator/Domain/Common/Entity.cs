namespace ConsentOrchestrator.Domain.Common;

/// <summary>
/// Base class for domain entities — objects defined by a stable identity
/// rather than by their attributes. Two entities are equal when they share
/// the same concrete type and identity.
/// </summary>
public abstract class Entity<TId> where TId : notnull
{
    public TId Id { get; }

    protected Entity(TId id) => Id = id;

    public override bool Equals(object? obj) =>
        obj is Entity<TId> other && GetType() == other.GetType() && Id.Equals(other.Id);

    public override int GetHashCode() => HashCode.Combine(GetType(), Id);
}