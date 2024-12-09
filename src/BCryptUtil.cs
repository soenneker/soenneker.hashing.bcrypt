using Soenneker.Extensions.String;
using BC = BCrypt.Net.BCrypt;

namespace Soenneker.Hashing.BCrypt;

/// <summary>
/// A utility library for BCrypt hashing and verification
/// </summary>
public static class BCryptUtil
{
    /// <summary>
    /// Generates a bcrypt hash for the given plaintext.
    /// </summary>
    /// <param name="plainText">The plaintext to hash.</param>
    /// <param name="workFactor">Optional: The work factor (default is 11).</param>
    /// <returns>The hashed string.</returns>
    public static string Hash(string plainText, int workFactor = 11)
    {
        plainText.ThrowIfNullOrWhitespace();

        return BC.EnhancedHashPassword(plainText, workFactor);
    }

    /// <summary>
    /// Verifies the given plaintext against a bcrypt hash.
    /// </summary>
    /// <param name="plainText">The plaintext to verify.</param>
    /// <param name="hash">The bcrypt hash to verify against.</param>
    /// <returns>True if the plaintext matches the hash; otherwise, false.</returns>
    public static bool Verify(string plainText, string hash)
    {
        plainText.ThrowIfNullOrWhitespace();
        hash.ThrowIfNullOrWhitespace();

        return BC.EnhancedVerify(plainText, hash);
    }
}