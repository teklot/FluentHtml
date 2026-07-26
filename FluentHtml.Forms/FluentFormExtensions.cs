using FluentHtml.Elements;
using FluentHtml.Nodes;
using System.Linq.Expressions;

namespace FluentHtml.Forms;

/// <summary>
/// Provides fluent extension methods that generate HTML form elements from model expressions.
/// </summary>
public static class FluentFormExtensions
{
    /// <summary>
    /// Creates a text <c>&lt;input&gt;</c> element bound to the specified model property.
    /// </summary>
    /// <typeparam name="TModel">The type of the model that owns the property.</typeparam>
    /// <param name="model">The model instance used for type inference.</param>
    /// <param name="property">An expression that selects the property to bind.</param>
    /// <returns>An <see cref="InputElement"/> configured as a text input.</returns>
    public static InputElement InputFor<TModel>(this TModel model, Expression<Func<TModel, object?>> property) where TModel : notnull
    {
        var expression = new ModelExpression<TModel>(property);
        return new InputElement()
            .Type("text")
            .Name(expression.HtmlFieldName)
            .Id(expression.HtmlFieldName)
            .Class("form-control");
    }

    /// <summary>
    /// Creates an <c>&lt;input&gt;</c> element of the specified type, bound to the given model property.
    /// </summary>
    /// <typeparam name="TModel">The type of the model that owns the property.</typeparam>
    /// <param name="model">The model instance used for type inference.</param>
    /// <param name="property">An expression that selects the property to bind.</param>
    /// <param name="type">The HTML input type (for example <c>"email"</c>, <c>"password"</c>, <c>"number"</c>).</param>
    /// <returns>An <see cref="InputElement"/> configured with the requested type.</returns>
    public static InputElement InputFor<TModel>(this TModel model, Expression<Func<TModel, object?>> property, string type) where TModel : notnull
    {
        var expression = new ModelExpression<TModel>(property);
        return new InputElement()
            .Type(type)
            .Name(expression.HtmlFieldName)
            .Id(expression.HtmlFieldName)
            .Class("form-control");
    }

    /// <summary>
    /// Creates a <c>&lt;label&gt;</c> element associated with the specified model property.
    /// </summary>
    /// <typeparam name="TModel">The type of the model that owns the property.</typeparam>
    /// <param name="model">The model instance used for type inference.</param>
    /// <param name="property">An expression that selects the property the label describes.</param>
    /// <returns>A <see cref="LabelElement"/> linked to the property's HTML field name.</returns>
    public static LabelElement LabelFor<TModel>(this TModel model, Expression<Func<TModel, object?>> property) where TModel : notnull
    {
        var expression = new ModelExpression<TModel>(property);
        return new LabelElement(expression.DisplayName)
            .For(expression.HtmlFieldName)
            .Class("form-label");
    }

    /// <summary>
    /// Creates a <c>&lt;textarea&gt;</c> element bound to the specified model property.
    /// </summary>
    /// <typeparam name="TModel">The type of the model that owns the property.</typeparam>
    /// <param name="model">The model instance used for type inference.</param>
    /// <param name="property">An expression that selects the property to bind.</param>
    /// <param name="rows">The number of visible text rows. Defaults to <c>4</c>.</param>
    /// <param name="cols">The visible width in characters, or <c>null</c> to omit the attribute.</param>
    /// <returns>A <see cref="TextareaElement"/> configured with the specified dimensions.</returns>
    public static TextareaElement TextAreaFor<TModel>(this TModel model, Expression<Func<TModel, object?>> property, int rows = 4, int? cols = null) where TModel : notnull
    {
        var expression = new ModelExpression<TModel>(property);
        var textarea = new TextareaElement();
        textarea.Attributes.Set("name", expression.HtmlFieldName);
        textarea.Attributes.Set("id", expression.HtmlFieldName);
        textarea.Attributes.Set("rows", rows.ToString());
        textarea.Attributes.Set("class", "form-control");

        if (cols.HasValue)
            textarea.Attributes.Set("cols", cols.Value.ToString());

        return textarea;
    }

    /// <summary>
    /// Creates a <c>&lt;select&gt;</c> element populated with the given items and bound to the specified model property.
    /// </summary>
    /// <typeparam name="TModel">The type of the model that owns the property.</typeparam>
    /// <param name="model">The model instance used for type inference.</param>
    /// <param name="property">An expression that selects the property to bind.</param>
    /// <param name="items">The collection of options to populate the select element.</param>
    /// <returns>A <see cref="SelectElement"/> containing option elements for each <see cref="SelectListItem"/>.</returns>
    public static SelectElement SelectFor<TModel>(this TModel model, Expression<Func<TModel, object?>> property, IEnumerable<SelectListItem> items) where TModel : notnull
    {
        var expression = new ModelExpression<TModel>(property);
        var options = items.Select(item =>
        {
            var option = new OptionElement(item.Text).Value(item.Value);
            if (item.Selected)
                option.Selected();
            return (Node)option;
        }).ToArray();

        return new SelectElement(options)
            .Name(expression.HtmlFieldName)
            .Id(expression.HtmlFieldName)
            .Class("form-select");
    }

    /// <summary>
    /// Creates a checkbox <c>&lt;input&gt;</c> element bound to the specified model property.
    /// </summary>
    /// <typeparam name="TModel">The type of the model that owns the property.</typeparam>
    /// <param name="model">The model instance used for type inference.</param>
    /// <param name="property">An expression that selects the property to bind.</param>
    /// <returns>An <see cref="InputElement"/> configured as a checkbox.</returns>
    public static InputElement CheckboxFor<TModel>(this TModel model, Expression<Func<TModel, object?>> property) where TModel : notnull
    {
        var expression = new ModelExpression<TModel>(property);
        return new InputElement()
            .Type("checkbox")
            .Name(expression.HtmlFieldName)
            .Id(expression.HtmlFieldName)
            .Class("form-check-input");
    }

    /// <summary>
    /// Creates a <c>&lt;label&gt;</c> element suitable for use alongside a checkbox bound to the specified model property.
    /// </summary>
    /// <typeparam name="TModel">The type of the model that owns the property.</typeparam>
    /// <param name="model">The model instance used for type inference.</param>
    /// <param name="property">An expression that selects the property the label describes.</param>
    /// <param name="label">
    /// Optional custom label text. When <c>null</c>, the property's display name is used.
    /// </param>
    /// <returns>A <see cref="LabelElement"/> linked to the property's HTML field name.</returns>
    public static LabelElement CheckboxLabelFor<TModel>(this TModel model, Expression<Func<TModel, object?>> property, string? label = null) where TModel : notnull
    {
        var expression = new ModelExpression<TModel>(property);
        return new LabelElement(label ?? expression.DisplayName)
            .For(expression.HtmlFieldName)
            .Class("form-check-label");
    }

    /// <summary>
    /// Creates a submit <c>&lt;button&gt;</c> element with the default primary styling.
    /// </summary>
    /// <param name="text">The button label. Defaults to <c>"Submit"</c>.</param>
    /// <returns>A <see cref="ButtonElement"/> configured as a submit button.</returns>
    public static ButtonElement SubmitButton(string text = "Submit")
    {
        return new ButtonElement(text)
            .Type("submit")
            .Class("btn btn-primary");
    }

    /// <summary>
    /// Creates a submit <c>&lt;button&gt;</c> element with a custom CSS class.
    /// </summary>
    /// <param name="text">The button label.</param>
    /// <param name="cssClass">The CSS class(es) to apply to the button.</param>
    /// <returns>A <see cref="ButtonElement"/> configured as a submit button.</returns>
    public static ButtonElement SubmitButton(string text, string cssClass)
    {
        return new ButtonElement(text)
            .Type("submit")
            .Class(cssClass);
    }
}
