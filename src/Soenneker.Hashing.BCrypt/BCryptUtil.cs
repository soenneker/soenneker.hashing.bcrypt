using System;
using Soenneker.Extensions.String;
using BC = BCrypt.Net.BCrypt;

namespace Soenneker.Hashing.BCrypt;

/// <summary>
/// A utility library for BCrypt hashing and verification
/// </summary>
public static class BCryptUtil
{
    private const int _minWorkFactor = 4;
    private const int _maxWorkFactor = 16;

    /// <summary>
    /// Generates a bcrypt hash for the given plaintext.
    /// </summary>
    /// <param name="plainText">The plaintext to hash.</param>
    /// <param name="workFactor">Optional: The work factor (default is 11).</param>
    /// <returns>The hashed string.</returns>
    public static string Hash(string plainText, int workFactor = 11)
    {
        plainText.ThrowIfNullOrWhiteSpace();

        if (workFactor is < _minWorkFactor or > _maxWorkFactor)
            throw new InvalidOperationException($"BCrypt work factor must be between {_minWorkFactor} and {_maxWorkFactor}.");

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
        plainText.ThrowIfNullOrWhiteSpace();
        hash.ThrowIfNullOrWhiteSpace();

        if (!TryGetWorkFactor(hash, out int workFactor) || workFactor is < _minWorkFactor or > _maxWorkFactor)
            return false;

        try
        {
            return BC.EnhancedVerify(plainText, hash);
        }
        catch
        {
            return false;
        }
    }

    private static bool TryGetWorkFactor(string hash, out int workFactor)
    {
        workFactor = 0;

        return hash.Length == 60 && hash[0] == '$' && hash[1] == '2' && hash[3] == '$' && hash[6] == '$' &&
               int.TryParse(hash.AsSpan(4, 2), out workFactor);
    }
}
