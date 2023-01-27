using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests.CategoryTests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        // Arrange
        var action = () => new Category(1, "Category Name");

        // Act & Assert
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category With Invalid Id Throw Domain Exception")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalid()
    {
        // Arrange
        var action = () => new Category(-1, "Category Name");

        // Act & Assert
        action.Should().Throw<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category with invalid name throw domain exception")]
    public void CreateCategory_MissingNameValue_DomainExceptionShortName()
    {
        // Arrange
        var action = () => new Category(1, "Ca");

        // Act & Assert
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Name: Name is too short, minimum 3 characters.");
    }

    [Fact(DisplayName = "Create Category with empty name throw domain exception")]
    public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
    {
        // Arrange
        var action = () => new Category(1, "");

        // Act & Assert
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Name: Name is required.");
    }


    [Fact(DisplayName = "Create Category with null name throw domain exception")]
    public void CreateCategory_WithNullNameValue_ThrowDomainExceptionInvalidName()
    {
        // Arrange
        var action = () => new Category(1, null);

        // Act & Assert
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Name: Name is required.");
    }
}