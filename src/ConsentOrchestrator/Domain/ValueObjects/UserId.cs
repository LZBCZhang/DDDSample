namespace ConsentOrchestrator.Domain.ValueObjects;

public record UserId(Guid Value)
{
    public static UserId From(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
