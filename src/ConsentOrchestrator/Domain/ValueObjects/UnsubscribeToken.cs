namespace ConsentOrchestrator.Domain.ValueObjects;

public record UnsubscribeToken(string Value)
{
    public static UnsubscribeToken Generate() =>
        new(Convert.ToBase64String(Guid.NewGuid().ToByteArray())
            .Replace("+", "-").Replace("/", "_").TrimEnd('='));
    public override string ToString() => Value;
}
