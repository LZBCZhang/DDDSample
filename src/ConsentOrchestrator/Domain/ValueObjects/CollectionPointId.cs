namespace ConsentOrchestrator.Domain.ValueObjects;

public record CollectionPointId(Guid Value)
{
    public static CollectionPointId From(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
