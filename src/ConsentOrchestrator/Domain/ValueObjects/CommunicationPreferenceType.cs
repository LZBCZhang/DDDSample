namespace ConsentOrchestrator.Domain.ValueObjects;

/// <summary>The channel a communication preference is delivered through.</summary>
public enum CommunicationPreferenceType
{
    Email,
    Sms,
    PushNotification
}

public static class CommunicationPreferenceTypeExtensions
{
    /// <summary>The stable, external representation used on the wire.</summary>
    public static string ToWireFormat(this CommunicationPreferenceType type) => type switch
    {
        CommunicationPreferenceType.Email => "EMAIL",
        CommunicationPreferenceType.Sms => "SMS",
        CommunicationPreferenceType.PushNotification => "PUSH-NOTIFICATION",
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown communication preference type.")
    };

    public static CommunicationPreferenceType FromWireFormat(string type) => type.ToUpperInvariant() switch
    {
        "EMAIL" => CommunicationPreferenceType.Email,
        "SMS" => CommunicationPreferenceType.Sms,
        "PUSH-NOTIFICATION" => CommunicationPreferenceType.PushNotification,
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown communication preference type.")
    };
}