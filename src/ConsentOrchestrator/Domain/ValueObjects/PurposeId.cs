namespace ConsentOrchestrator.Domain.ValueObjects;

public record PurposeId(Guid Value)
{
    public static PurposeId From(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
