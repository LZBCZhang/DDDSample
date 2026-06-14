using System.Security.Cryptography;
using System.Text;
using ConsentOrchestrator.Domain.Interfaces;

namespace ConsentOrchestrator.Infrastructure.Security;

/// <summary>
/// HMAC-SHA256 implementation of <see cref="IHmacTokenGenerator"/>. Signs the
/// payload with a shared secret and returns a URL-safe Base64 token.
/// </summary>
public sealed class HmacToken(string secretKey) : IHmacTokenGenerator
{
    private readonly byte[] _key = Encoding.UTF8.GetBytes(secretKey);

    public string Generate(string payload)
    {
        var hash = HMACSHA256.HashData(_key, Encoding.UTF8.GetBytes(payload));

        return Convert.ToBase64String(hash)
            .Replace("+", "-", StringComparison.Ordinal)
            .Replace("/", "_", StringComparison.Ordinal)
            .TrimEnd('=');
    }

    public bool Validate(string payload, string token)
    {
        var expected = Generate(payload);

        // Constant-time comparison to avoid leaking information through timing.
        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(expected),
            Encoding.UTF8.GetBytes(token));
    }
}