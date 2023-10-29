using System.Diagnostics.CodeAnalysis;

using FluentAssertions;


namespace iStruction.Monads.UnitTests;

[ExcludeFromCodeCoverage]
public class MaybeTest
{
    [Fact]
    public void Maybe_CanCreateNone()
    {
        // Arrange
        // Act
        var result = Maybe.None<string>();

        // Assert
        result.Should().BeNone();
    }


    [Fact]
    public void Maybe_CanCreateSome()
    {
        // Arrange
        // Act
        var result = "Somestring".Some();

        // Assert
        result.Should().BeSome();
    }


    [Fact]
    public void Match_WhenSome_ReturnsResultOfSome()
    {
        // Arrange
        var sut = "Somestring".Some();

        // Act
        var result = sut.Match(false, _ => true);

        // Assert
        result.Should().BeTrue();
    }


    [Fact]
    public void Match_WhenNone_ReturnsResultOfNone()
    {
        // Arrange
        var sut = Maybe<string>.None();

        // Act
        var result = sut.Match(true, _ => false);

        // Assert
        result.Should().BeTrue();
    }
}
