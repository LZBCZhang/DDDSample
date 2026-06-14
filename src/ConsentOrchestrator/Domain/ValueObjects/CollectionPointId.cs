namespace ConsentOrchestrator.Domain.ValueObjects;

public record CollectionPointId(Guid Value)
{
    public static CollectionPointId From(Guid value) => new(value);
    public static explicit operator Guid(CollectionPointId id) => id.Value;
    public override string ToString() => Value.ToString();
}
