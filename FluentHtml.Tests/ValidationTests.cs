using System.ComponentModel.DataAnnotations;
using FluentHtml.Rendering;
using FluentHtml.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FluentHtml.Tests;

public class ValidationTests
{
    private readonly Renderer _renderer = new();

    private class SampleModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Username length must be between 3 and 10.")]
        public string Username { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;
    }

    [Fact]
    public void Validate_ValidModel_ReturnsIsValidTrue()
    {
        var model = new SampleModel { Username = "John", Email = "john@example.com" };
        var result = model.Validate();

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_InvalidModel_ReturnsIsValidFalseWithErrors()
    {
        var model = new SampleModel { Username = "", Email = "invalid-email" };
        var result = model.Validate();

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e == "Username is required.");
        Assert.Contains(result.Errors, e => e == "Invalid email address.");
    }

    [Fact]
    public void ValidationMessageComponent_RendersSpanWithErrors()
    {
        var componentWithError = new ValidationMessageComponent("Username", "Username is required.");
        var componentWithoutError = new ValidationMessageComponent("Username", null);

        var htmlWithError = _renderer.Render(componentWithError);
        var htmlWithoutError = _renderer.Render(componentWithoutError);

        Assert.Contains("<span", htmlWithError);
        Assert.Contains("class=\"field-validation-error text-danger\"", htmlWithError);
        Assert.Contains("Username is required.</span>", htmlWithError);

        Assert.Contains("<span", htmlWithoutError);
        Assert.Contains("class=\"field-validation-error\"", htmlWithoutError);
        Assert.DoesNotContain("text-danger", htmlWithoutError);
    }

    [Fact]
    public void ValidationSummaryComponent_RendersHeadingAndList()
    {
        string[] errors = ["Error 1", "Error 2"];
        var summaryWithHeading = new ValidationSummaryComponent("Errors Found", errors);
        var summaryNoHeading = new ValidationSummaryComponent(null, errors);

        var htmlWithHeading = _renderer.Render(summaryWithHeading);
        var htmlNoHeading = _renderer.Render(summaryNoHeading);

        Assert.Contains("<div class=\"validation-summary-errors\"", htmlWithHeading);
        Assert.Contains("<h3>Errors Found</h3>", htmlWithHeading);
        Assert.Contains("<ul><li>Error 1</li><li>Error 2</li></ul>", htmlWithHeading);

        Assert.DoesNotContain("<h3>", htmlNoHeading);
        Assert.Contains("<ul><li>Error 1</li><li>Error 2</li></ul>", htmlNoHeading);
    }

    [Fact]
    public void ValidationExtensions_WithModelState_EvaluatesErrorsAndCssClasses()
    {
        var model = new SampleModel();
        var modelState = new ModelStateDictionary();
        modelState.AddModelError("Username", "Username is required.");

        Assert.False(model.IsValid(modelState));
        Assert.True(model.HasError(m => m.Username, modelState));
        Assert.False(model.HasError(m => m.Email, modelState));

        Assert.Equal("is-invalid", model.ValidationCssClass(m => m.Username, modelState));
        Assert.Equal("is-valid", model.ValidationCssClass(m => m.Email, modelState));

        var msg = model.ValidationMessage(m => m.Username, modelState);
        var htmlMsg = _renderer.Render(msg);
        Assert.Contains("Username is required.", htmlMsg);

        var summary = modelState.ValidationSummary("Please fix:");
        var htmlSummary = _renderer.Render(summary);
        Assert.Contains("Please fix:", htmlSummary);
        Assert.Contains("Username is required.", htmlSummary);
    }
}
