[![](https://img.shields.io/nuget/v/soenneker.hashing.bcrypt.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.hashing.bcrypt/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hashing.bcrypt/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.hashing.bcrypt/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.hashing.bcrypt.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.hashing.bcrypt/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Hashing.BCrypt
### A utility library for BCrypt hashing and verification

## Features
- **Hash passwords**: Securely hash passwords.
- **Verify passwords**: Check if a password matches a hash.
- **Custom security**: Adjust the `workFactor` for extra security.

## Installation

```
dotnet add package Soenneker.Hashing.BCrypt
```

## Usage

### Hash a Password
```csharp
string hash = BCryptUtil.Hash("MyPassword");
```

### Verify a Password
```csharp
bool isValid = BCryptUtil.Verify("MyPassword", hash);
```

### Custom Work Factor
```csharp
string hash = BCryptUtil.Hash("MyPassword", workFactor: 12);
```