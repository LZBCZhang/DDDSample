namespace ConsentOrchestrator.Domain.ValueObjects;

public record PurposeId(Guid Value)
{
    public static PurposeId From(Guid value) => new(value);
    public static explicit operator Guid(PurposeId id) => id.Value;
    public override string ToString() => Value.ToString();
}
