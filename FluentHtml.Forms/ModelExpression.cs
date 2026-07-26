using System.Linq.Expressions;
using System.Reflection;

namespace FluentHtml.Forms;

/// <summary>
/// Wraps a lambda expression that selects a property on a model, providing metadata such as
/// the property name, HTML field name, and display name used for form element generation.
/// </summary>
/// <typeparam name="TModel">The type of the model that owns the property.</typeparam>
public sealed class ModelExpression<TModel>
{
    private readonly Expression<Func<TModel, object?>> _expression;

    /// <summary>
    /// Initializes a new instance of <see cref="ModelExpression{TModel}"/> from a property selector expression.
    /// </summary>
    /// <param name="expression">
    /// A lambda expression that selects a property on <typeparamref name="TModel"/>,
    /// for example <c>m => m.Name</c>.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="expression"/> is <c>null</c>.</exception>
    public ModelExpression(Expression<Func<TModel, object?>> expression)
    {
        _expression = expression ?? throw new ArgumentNullException(nameof(expression));
    }

    /// <summary>
    /// Gets the name of the property referenced by the expression.
    /// </summary>
    public string PropertyName => GetPropertyName();

    /// <summary>
    /// Gets the HTML field name used for form input elements, derived from the property name.
    /// </summary>
    public string HtmlFieldName => PropertyName;

    /// <summary>
    /// Gets the human-readable display name for the property.
    /// Falls back to a <c>[Display(Name = ...)]</c> attribute when present, otherwise uses the property name.
    /// </summary>
    public string DisplayName => GetDisplayName();

    private string GetPropertyName()
    {
        var body = _expression.Body;

        if (body is UnaryExpression unary)
            body = unary.Operand;

        if (body is MemberExpression member && member.Member is PropertyInfo prop)
            return prop.Name;

        throw new InvalidOperationException($"Expression '{_expression}' does not refer to a property.");
    }

    private string GetDisplayName()
    {
        var body = _expression.Body;

        if (body is UnaryExpression unary)
            body = unary.Operand;

        if (body is MemberExpression member && member.Member is PropertyInfo prop)
        {
            var displayAttr = prop.GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>();
            if (displayAttr?.Name is not null)
                return displayAttr.Name;

            return prop.Name;
        }

        return PropertyName;
    }
}

/// <summary>
/// Provides factory methods for creating <see cref="ModelExpression{TModel}"/> instances.
/// </summary>
public static class ModelExpression
{
    /// <summary>
    /// Creates a new <see cref="ModelExpression{TModel}"/> from the given property selector.
    /// </summary>
    /// <typeparam name="TModel">The type of the model that owns the property.</typeparam>
    /// <param name="expression">
    /// A lambda expression that selects a property on <typeparamref name="TModel"/>.
    /// </param>
    /// <returns>A new <see cref="ModelExpression{TModel}"/> wrapping the expression.</returns>
    public static ModelExpression<TModel> For<TModel>(Expression<Func<TModel, object?>> expression)
        => new(expression);
}
