using System.Text;
using ConsentOrchestrator.Domain.Interfaces;

namespace ConsentOrchestrator.Domain.ValueObjects;

/// <summary>
/// A self-contained, tamper-evident unsubscribe token. It carries the user,
/// collection point and purpose it targets, together with an HMAC signature over
/// that payload (<c>base64url(payload).signature</c>). The payload can be read
/// back by anyone, but only a holder of the signing secret can produce or alter a
/// valid token — so <see cref="Decode"/> both authenticates the token and recovers
/// the identifiers it carries, without any server-side storage.
/// </summary>
public record UnsubscribeToken(string Value)
{
    private const char SignatureSeparator = '.';
    private const char FieldSeparator = ':';

    public static UnsubscribeToken Generate(
        IHmacTokenGenerator hmacTokenGenerator,
        UserId userId,
        CollectionPointId collectionPointId,
        PurposeId purposeId)
    {
        var payload = $"{userId}{FieldSeparator}{collectionPointId}{FieldSeparator}{purposeId}";
        var signature = hmacTokenGenerator.Generate(payload);

        return new UnsubscribeToken($"{EncodePayload(payload)}{SignatureSeparator}{signature}");
    }

    /// <summary>
    /// Authenticates <paramref name="token"/> and, when its signature is valid,
    /// returns the identifiers it carries. Returns <c>null</c> when the token is
    /// malformed or has been tampered with.
    /// </summary>
    public static UnsubscribeTokenData? Decode(IHmacTokenGenerator hmacTokenGenerator, string token)
    {
        var parts = token.Split(SignatureSeparator);
        if (parts.Length != 2)
            return null;

        string payload;
        try
        {
            payload = DecodePayload(parts[0]);
        }
        catch (FormatException)
        {
            return null;
        }

        if (!hmacTokenGenerator.Validate(payload, parts[1]))
            return null;

        var fields = payload.Split(FieldSeparator);
        if (fields.Length != 3
            || !Guid.TryParse(fields[0], out var userId)
            || !Guid.TryParse(fields[1], out var collectionPointId)
            || !Guid.TryParse(fields[2], out var purposeId))
            return null;

        return new UnsubscribeTokenData(
            UserId.From(userId),
            CollectionPointId.From(collectionPointId),
            PurposeId.From(purposeId));
    }

    private static string EncodePayload(string payload) =>
        Convert.ToBase64String(Encoding.UTF8.GetBytes(payload))
            .Replace("+", "-", StringComparison.Ordinal)
            .Replace("/", "_", StringComparison.Ordinal)
            .TrimEnd('=');

    private static string DecodePayload(string encoded)
    {
        var base64 = encoded.Replace('-', '+').Replace('_', '/');
        base64 = (base64.Length % 4) switch
        {
            2 => base64 + "==",
            3 => base64 + "=",
            _ => base64,
        };

        return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
    }

    public override string ToString() => Value;
}

/// <summary>The identifiers recovered from a validated <see cref="UnsubscribeToken"/>.</summary>
public record UnsubscribeTokenData(
    UserId UserId,
    CollectionPointId CollectionPointId,
    PurposeId PurposeId);