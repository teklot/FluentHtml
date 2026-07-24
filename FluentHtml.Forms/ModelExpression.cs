using System.Linq.Expressions;
using System.Reflection;

namespace FluentHtml.Forms;

public sealed class ModelExpression<TModel>
{
    private readonly Expression<Func<TModel, object?>> _expression;

    public ModelExpression(Expression<Func<TModel, object?>> expression)
    {
        _expression = expression ?? throw new ArgumentNullException(nameof(expression));
    }

    public string PropertyName => GetPropertyName();

    public string HtmlFieldName => PropertyName;

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

public static class ModelExpression
{
    public static ModelExpression<TModel> For<TModel>(Expression<Func<TModel, object?>> expression)
        => new(expression);
}
