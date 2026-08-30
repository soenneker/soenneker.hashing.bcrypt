[![](https://img.shields.io/nuget/v/soenneker.hashing.bcrypt.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.hashing.bcrypt/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hashing.bcrypt/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.hashing.bcrypt/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hashing.bcrypt/build-and-test.yml?style=for-the-badge&label=build)](https://github.com/soenneker/soenneker.hashing.bcrypt/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/nuget/dt/soenneker.hashing.bcrypt.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.hashing.bcrypt/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hashing.bcrypt/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.hashing.bcrypt/actions/workflows/codeql.yml)

# Soenneker.Hashing.BCrypt

Hashes and verifies passwords with BCrypt.Net-Next’s enhanced bcrypt mode. Enhanced mode pre-hashes the password before bcrypt, avoiding bcrypt’s usual 72-byte input truncation.

## Installation

```bash
dotnet add package Soenneker.Hashing.BCrypt
```

## Hash and verify

```csharp
using Soenneker.Hashing.BCrypt;

string storedHash = BCryptUtil.Hash(password);

bool valid = BCryptUtil.Verify(candidatePassword, storedHash);
```

Each `Hash()` call creates a new random salt and includes the salt and work factor in the returned record. Store that complete string; do not store a separate salt.

The default work factor is 11. It can be selected explicitly:

```csharp
string storedHash = BCryptUtil.Hash(password, workFactor: 12);
```

Supported work factors are 4 through 16. `Hash()` throws `InvalidOperationException` outside that range, and `Verify()` rejects records embedding an excessive cost before performing expensive work. Benchmark authentication under expected concurrency before increasing the cost.

## Compatibility

This utility calls `EnhancedHashPassword()` and `EnhancedVerify()`, not BCrypt.Net’s standard password methods. A hash produced here must be verified with enhanced mode; a different bcrypt implementation that hashes the raw password may not interoperate even when the encoded record looks like ordinary bcrypt.

`Verify()` returns `false` for a mismatched password, malformed record, or unsupported work factor. Empty plaintext or hash arguments retain the library’s argument-validation behavior. Rate-limit authentication attempts and never log plaintext passwords.
