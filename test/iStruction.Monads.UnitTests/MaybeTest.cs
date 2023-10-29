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
    public void Maybe_WhenCreateSomeWithNull_ThrowsException()
    {
        // Arrange
        // Act
        var exception = Assert.Throws<ArgumentNullException>(
            () => default(string).Some()
        );

        // Assert
        exception.Should().NotBeNull();
        exception.ParamName.Should().Be("item");
    }


    [Fact]
    public void Match_WhenSomeIsFunc_ReturnsResultOfSome()
    {
        // Arrange
        var sut = "Somestring".Some();

        // Act
        var result = sut.Match(false, _ => true);

        // Assert
        result.Should().BeTrue();
    }


    [Fact]
    public void Match_WhenSomeFuncIsNull_ThrowsException_1()
    {
        // Arrange
        var sut = "Somestring".Some();

        // Act
        var exception = Assert.Throws<ArgumentNullException>(
            () => sut.Match(false, default)
        );

        // Assert
        exception.Should().NotBeNull();
        exception.ParamName.Should().Be("some");
    }


    [Fact]
    public void Match_WhenNoneIsValue_ReturnsResultOfNone()
    {
        // Arrange
        var sut = Maybe<string>.None();

        // Act
        var result = sut.Match(true, _ => false);

        // Assert
        result.Should().BeTrue();
    }


    [Fact]
    public void Match_WhenNoneIsFunc_ReturnsResultOfNone()
    {
        // Arrange
        var sut = Maybe<string>.None();

        // Act
        var result = sut.Match(() => true, _ => false);

        // Assert
        result.Should().BeTrue();
    }


    [Fact]
    public void Match_WhenNoneIsFunc_ReturnsResultOfSome()
    {
        // Arrange
        var sut = "Somestring".Some();

        // Act
        var result = sut.Match(() => false, _ => true);

        // Assert
        result.Should().BeTrue();
    }


    [Fact]
    public void Match_WhenNoneFuncIsNull_ThrowsException()
    {
        // Arrange
        var sut = Maybe<string>.None();

        // Act
        var exception = Assert.Throws<ArgumentNullException>(
            () => sut.Match(null, _ => false)
        );

        // Assert
        exception.Should().NotBeNull();
        exception.ParamName.Should().Be("none");
    }


    [Fact]
    public void Match_WhenSomeFuncIsNull_ThrowsException_2()
    {
        // Arrange
        var sut = "Somestring".Some();

        // Act
        var exception = Assert.Throws<ArgumentNullException>(
            () => sut.Match(() => false, default)
        );

        // Assert
        exception.Should().NotBeNull();
        exception.ParamName.Should().Be("some");
    }
}
