using System.Diagnostics.CodeAnalysis;

using iStruction.Monads.FluentAssertions;


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
}
