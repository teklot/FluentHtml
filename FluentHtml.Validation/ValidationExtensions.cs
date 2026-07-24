using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FluentHtml.Validation;

public static class ValidationExtensions
{
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

    public static bool IsValid<TModel>(this TModel model, ModelStateDictionary modelState) where TModel : notnull
    {
        return modelState.IsValid;
    }

    public static bool HasError<TModel>(
        this TModel model,
        Expression<Func<TModel, object?>> property,
        ModelStateDictionary modelState) where TModel : notnull
    {
        var propertyName = GetPropertyName(property);
        return modelState.TryGetValue(propertyName, out var entry) && entry.Errors.Count > 0;
    }

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
