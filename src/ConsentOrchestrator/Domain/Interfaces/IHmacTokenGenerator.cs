namespace ConsentOrchestrator.Domain.Interfaces;

/// <summary>
/// Domain service that signs a payload into an opaque, tamper-evident token
/// using a keyed HMAC. Lets the model mint unsubscribe tokens that can later be
/// validated without persisting any server-side state. The cryptographic detail
/// lives in the infrastructure; the domain only depends on this contract.
/// </summary>
public interface IHmacTokenGenerator
{
    /// <summary>Signs <paramref name="payload"/> and returns the resulting token.</summary>
    string Generate(string payload);

    /// <summary>
    /// Returns <c>true</c> when <paramref name="token"/> is the authentic signature
    /// of <paramref name="payload"/> — i.e. it matches a freshly computed HMAC.
    /// </summary>
    bool Validate(string payload, string token);
}