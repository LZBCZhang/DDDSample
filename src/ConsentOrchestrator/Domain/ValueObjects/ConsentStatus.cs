namespace ConsentOrchestrator.Domain.ValueObjects;

/// <summary>
/// The decision a user expresses for a given purpose.
/// </summary>
public enum ConsentStatus
{
    Confirmed,
    Declined,
    Pending
}

public static class ConsentStatusExtensions
{
    /// <summary>
    /// The stable, external representation of the status used on the wire
    /// (published domain events, adapter payloads).
    /// </summary>
    public static string ToWireFormat(this ConsentStatus status) => status switch
    {
        ConsentStatus.Confirmed => "CONFIRMED",
        ConsentStatus.Declined => "DECLINED",
        ConsentStatus.Pending => "PENDING",
        _ => throw new ArgumentOutOfRangeException(nameof(status), status, "Unknown consent status.")
    };

    /// <summary>Parses the stable, external representation back into a status.</summary>
    public static ConsentStatus FromWireFormat(string status) => status.ToUpperInvariant() switch
    {
        "CONFIRMED" => ConsentStatus.Confirmed,
        "DECLINED" => ConsentStatus.Declined,
        "PENDING" => ConsentStatus.Pending,
        _ => throw new ArgumentOutOfRangeException(nameof(status), status, "Unknown consent status.")
    };
}