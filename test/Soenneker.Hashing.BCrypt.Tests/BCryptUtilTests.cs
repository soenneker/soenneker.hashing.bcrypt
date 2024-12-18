using FluentAssertions;
using Soenneker.Tests.FixturedUnit;
using System;
using Xunit;


namespace Soenneker.Hashing.BCrypt.Tests;

[Collection("Collection")]
public class BCryptUtilTests : FixturedUnitTest
{
    public BCryptUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Hash_ShouldGenerateValidHash()
    {
        // Arrange
        var password = "MySecurePassword";

        // Act
        string hash = BCryptUtil.Hash(password);

        // Assert
        hash.Should().NotBeNullOrEmpty("a hash should be generated");
        hash.Should().NotBe(password, "the hash should not match the plain text password");
    }

    [Fact]
    public void Verify_ShouldReturnTrueForValidPassword()
    {
        // Arrange
        var password = "MySecurePassword";
        string hash = BCryptUtil.Hash(password);

        // Act
        bool isValid = BCryptUtil.Verify(password, hash);

        // Assert
        isValid.Should().BeTrue("the password matches the hash");
    }

    [Fact]
    public void Verify_ShouldReturnFalseForInvalidPassword()
    {
        // Arrange
        var password = "MySecurePassword";
        string hash = BCryptUtil.Hash(password);

        // Act
        bool isValid = BCryptUtil.Verify("WrongPassword", hash);

        // Assert
        isValid.Should().BeFalse("the password does not match the hash");
    }

    [Fact]
    public void Hash_ShouldThrowExceptionForNullInput()
    {
        // Arrange
        string nullPassword = null;

        // Act
        Action act = () => BCryptUtil.Hash(nullPassword);

        // Assert
        act.Should().Throw<ArgumentException>("a null or empty password is invalid");
    }

    [Fact]
    public void Verify_ShouldThrowExceptionForNullPassword()
    {
        // Arrange
        string hash = BCryptUtil.Hash("MySecurePassword");
        string? nullPassword = null;

        // Act
        Action act = () => BCryptUtil.Verify(nullPassword, hash);

        // Assert
        act.Should().Throw<ArgumentException>("a null or empty password is invalid");
    }

    [Fact]
    public void Verify_ShouldThrowExceptionForNullHash()
    {
        // Arrange
        var password = "MySecurePassword";
        string nullHash = null;

        // Act
        Action act = () => BCryptUtil.Verify(password, nullHash);

        // Assert
        act.Should().Throw<ArgumentException>("a null or empty hash is invalid");
    }

    [Fact]
    public void Hash_ShouldRespectCustomWorkFactor()
    {
        // Arrange
        var password = "MySecurePassword";
        var workFactor = 12;

        // Act
        string hash = BCryptUtil.Hash(password, workFactor);

        // Assert
        hash.Should().NotBeNullOrEmpty("a hash should still be generated with a custom work factor");
    }
}