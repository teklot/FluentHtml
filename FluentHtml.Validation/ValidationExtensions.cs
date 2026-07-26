using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FluentHtml.Validation;

/// <summary>
/// Provides extension methods for integrating ASP.NET Core model state validation with FluentHtml components.
/// </summary>
public static class ValidationExtensions
{
    /// <summary>
    /// Creates a <see cref="ValidationMessageComponent"/> for the specified property, displaying the first validation error if present.
    /// </summary>
    /// <typeparam name="TModel">The type of the model being validated.</typeparam>
    /// <param name="model">The model instance to validate against.</param>
    /// <param name="property">An expression identifying the property to check for errors.</param>
    /// <param name="modelState">The current model state dictionary containing validation errors.</param>
    /// <returns>A <see cref="ValidationMessageComponent"/> containing the error message for the property, or an empty message if valid.</returns>
    public static ValidationMessageComponent ValidationMessage<TModel>(
        this TModel model,
        Expression<Func<TModel, object?>> property,
        ModelStateDictionary modelState) where TModel : notnull
    {
        var propertyName = GetPropertyName(property);
        var hasError = modelState.TryGetValue(propertyName, out var entry) && entry.Errors.Count > 0;
        var errorMessage = hasError ? entry!.Errors.First().ErrorMessage : null;

        return new ValidationMessageComponent(propertyName, errorMessage);
    }

    /// <summary>
    /// Creates a <see cref="ValidationSummaryComponent"/> that lists all validation errors from the model state.
    /// </summary>
    /// <param name="modelState">The current model state dictionary containing validation errors.</param>
    /// <param name="heading">An optional heading to display above the error list.</param>
    /// <returns>A <see cref="ValidationSummaryComponent"/> containing a summary of all validation errors.</returns>
    public static ValidationSummaryComponent ValidationSummary(
        this ModelStateDictionary modelState,
        string? heading = null)
    {
        var errors = modelState
            .Where(kvp => kvp.Value is not null && kvp.Value.Errors.Count > 0)
            .SelectMany(kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage))
            .Where(e => !string.IsNullOrEmpty(e))
            .Distinct();

        return new ValidationSummaryComponent(heading, errors);
    }

    /// <summary>
    /// Determines whether the model state is valid for the given model.
    /// </summary>
    /// <typeparam name="TModel">The type of the model being validated.</typeparam>
    /// <param name="model">The model instance to check.</param>
    /// <param name="modelState">The current model state dictionary.</param>
    /// <returns><c>true</c> if the model state contains no validation errors; otherwise, <c>false</c>.</returns>
    public static bool IsValid<TModel>(this TModel model, ModelStateDictionary modelState) where TModel : notnull
    {
        return modelState.IsValid;
    }

    /// <summary>
    /// Determines whether the specified property has a validation error in the model state.
    /// </summary>
    /// <typeparam name="TModel">The type of the model being validated.</typeparam>
    /// <param name="model">The model instance to check.</param>
    /// <param name="property">An expression identifying the property to check for errors.</param>
    /// <param name="modelState">The current model state dictionary containing validation errors.</param>
    /// <returns><c>true</c> if the specified property has at least one validation error; otherwise, <c>false</c>.</returns>
    public static bool HasError<TModel>(
        this TModel model,
        Expression<Func<TModel, object?>> property,
        ModelStateDictionary modelState) where TModel : notnull
    {
        var propertyName = GetPropertyName(property);
        return modelState.TryGetValue(propertyName, out var entry) && entry.Errors.Count > 0;
    }

    /// <summary>
    /// Returns a Bootstrap-compatible CSS class indicating the validation state of the specified property.
    /// </summary>
    /// <typeparam name="TModel">The type of the model being validated.</typeparam>
    /// <param name="model">The model instance to check.</param>
    /// <param name="property">An expression identifying the property to evaluate.</param>
    /// <param name="modelState">The current model state dictionary containing validation errors.</param>
    /// <returns><c>"is-invalid"</c> if the property has errors; otherwise, <c>"is-valid"</c>.</returns>
    public static string ValidationCssClass<TModel>(
        this TModel model,
        Expression<Func<TModel, object?>> property,
        ModelStateDictionary modelState) where TModel : notnull
    {
        var propertyName = GetPropertyName(property);
        if (modelState.TryGetValue(propertyName, out var entry) && entry.Errors.Count > 0)
            return "is-invalid";
        return "is-valid";
    }

    /// <summary>
    /// Extracts the property name from a lambda expression that references a property on a model.
    /// </summary>
    /// <typeparam name="TModel">The type of the model containing the property.</typeparam>
    /// <param name="expression">A lambda expression that references the property.</param>
    /// <returns>The name of the property referenced by the expression.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the expression does not refer to a property.</exception>
    private static string GetPropertyName<TModel>(Expression<Func<TModel, object?>> expression)
    {
        var body = expression.Body;

        if (body is UnaryExpression unary)
            body = unary.Operand;

        if (body is MemberExpression member && member.Member is PropertyInfo prop)
            return prop.Name;

        throw new InvalidOperationException($"Expression '{expression}' does not refer to a property.");
    }
}
