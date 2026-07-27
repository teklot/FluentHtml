using System.ComponentModel.DataAnnotations;

namespace FluentHtml.Validation;

/// <summary>
/// Provides the <see cref="Validate{T}"/> extension method for model validation using DataAnnotations.
/// </summary>
public static class ValidateExtensions
{
    /// <summary>
    /// Validates the specified model using <see cref="System.ComponentModel.DataAnnotations"/> attributes.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    /// <param name="model">The model instance to validate.</param>
    /// <returns>A <see cref="ValidationResult"/> with <see cref="ValidationResult.IsValid"/> and any error messages.</returns>
    public static ValidationResult Validate<T>(this T model) where T : class
    {
        var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
        var context = new ValidationContext(model);
        var isValid = Validator.TryValidateObject(model, context, results, validateAllProperties: true);
        return new ValidationResult(isValid, results.Select(r => r.ErrorMessage!).ToList());
    }
}
