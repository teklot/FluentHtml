namespace FluentHtml.Validation;

/// <summary>
/// Represents the result of a model validation operation.
/// </summary>
public sealed class ValidationResult
{
    /// <summary>
    /// Gets whether the model passed all validation rules.
    /// </summary>
    public bool IsValid { get; }

    /// <summary>
    /// Gets the list of validation error messages.
    /// </summary>
    public IReadOnlyList<string> Errors { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="ValidationResult"/>.
    /// </summary>
    /// <param name="isValid">Whether validation succeeded.</param>
    /// <param name="errors">The list of error messages.</param>
    public ValidationResult(bool isValid, List<string> errors)
    {
        IsValid = isValid;
        Errors = errors.AsReadOnly();
    }
}
