[![](https://img.shields.io/nuget/v/soenneker.hashing.bcrypt.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.hashing.bcrypt/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hashing.bcrypt/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.hashing.bcrypt/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.hashing.bcrypt.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.hashing.bcrypt/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hashing.bcrypt/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.hashing.bcrypt/actions/workflows/codeql.yml)

# Soenneker.Hashing.BCrypt

A utility library for BCrypt hashing and verification.

## Install

```bash
dotnet add package Soenneker.Hashing.BCrypt
```

## Quick start

```csharp
using Soenneker.Hashing.BCrypt;

var result = BCryptUtil.Hash("value");
```

Generates a bcrypt hash for the given plaintext.

## What you get

- `BCryptUtil` — A utility library for BCrypt hashing and verification.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `BCryptUtil.Verify(plainText, hash)` | Verifies the given plaintext against a bcrypt hash. | True if the plaintext matches the hash; otherwise, false. |
