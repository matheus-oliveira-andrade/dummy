using Web.Models;

namespace Web.Tests.Models;

public class PersonTests
{
    [Fact]
    public void Person_WithNameAndBirthDate_SetCorrectlyValues()
    {
        // Arrange & Act
        var result = new Person("Angelo", new DateTime(1800, 02, 23));

        // Assert
        Assert.Equal("Angelo", result.Name);
        Assert.Equal(new DateTime(1800, 02, 23), result.BirthDate);
    }

    [Fact]
    public void Person_ThrowsArgumentException_WhenNameIsEmpty()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Person(string.Empty, new DateTime(1800, 02, 23)));
    }

    [Fact]
    public void Person_ThrowsArgumentException_WhenBirthDateIsDefault()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Person("Marcos", default));
    }

    [Fact]
    public void GetAge_WithValue_ResultHasCorrectValue()
    {
        // Arrange
        var person = new Person("Maria", new DateTime(1999, 09, 15));

        // Act
        var result = person.GetAge(new DateTime(2022, 07, 06));

        // Assert
        Assert.Equal(22, result);
    }
}