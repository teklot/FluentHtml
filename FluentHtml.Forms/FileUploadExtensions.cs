using FluentHtml.Elements;
using FluentHtml.Nodes;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentHtml.Forms;

/// <summary>
/// Provides extension methods for generating file upload input elements.
/// </summary>
public static class FileUploadExtensions
{
    /// <summary>
    /// Creates a file upload <c>&lt;input&gt;</c> element bound to the specified model property.
    /// </summary>
    /// <typeparam name="TModel">The type of the model that owns the property.</typeparam>
    /// <param name="model">The model instance used for type inference.</param>
    /// <param name="property">An expression that selects the property to bind.</param>
    /// <param name="multiple">If true, allows multiple file selection.</param>
    /// <param name="accept">Optional comma-separated list of accepted file types (e.g., ".jpg,.png,.pdf").</param>
    /// <returns>An <see cref="InputElement"/> configured for file upload.</returns>
    public static InputElement FileInputFor<TModel>(this TModel model, Expression<Func<TModel, object?>> property, bool multiple = false, string? accept = null) where TModel : notnull
    {
        var expression = new ModelExpression<TModel>(property);
        var input = new InputElement()
            .Type("file")
            .Name(expression.HtmlFieldName)
            .Id(expression.HtmlFieldName)
            .Class("form-control");

        if (multiple)
            input.Attributes.SetBool("multiple");

        if (!string.IsNullOrEmpty(accept))
            input.Attributes.Set("accept", accept);

        return input;
    }

    /// <summary>
    /// Creates a file upload <c>&lt;input&gt;</c> element with a file type filter.
    /// </summary>
    /// <typeparam name="TModel">The type of the model that owns the property.</typeparam>
    /// <param name="model">The model instance used for type inference.</param>
    /// <param name="property">An expression that selects the property to bind.</param>
    /// <param name="accept">The comma-separated list of accepted file types (e.g., ".jpg,.png,.gif").</param>
    /// <returns>An <see cref="InputElement"/> configured for file upload with type filtering.</returns>
    public static InputElement FileInputFor<TModel>(this TModel model, Expression<Func<TModel, object?>> property, string accept) where TModel : notnull
    {
        return FileInputFor(model, property, multiple: false, accept: accept);
    }

    /// <summary>
    /// Creates a file upload <c>&lt;input&gt;</c> element wrapped in a Bootstrap-styled group.
    /// </summary>
    /// <typeparam name="TModel">The type of the model that owns the property.</typeparam>
    /// <param name="model">The model instance used for type inference.</param>
    /// <param name="property">An expression that selects the property to bind.</param>
    /// <param name="label">Optional label text above the input.</param>
    /// <param name="multiple">If true, allows multiple file selection.</param>
    /// <param name="accept">Optional comma-separated list of accepted file types.</param>
    /// <returns>A <see cref="DivElement"/> containing the label and file input.</returns>
    public static DivElement FileInputGroup<TModel>(this TModel model, Expression<Func<TModel, object?>> property, string? label = null, bool multiple = false, string? accept = null) where TModel : notnull
    {
        var expression = new ModelExpression<TModel>(property);
        var wrapper = new DivElement();
        wrapper.Class("mb-3");

        if (!string.IsNullOrEmpty(label))
        {
            var labelElement = new LabelElement(label);
            labelElement.For(expression.HtmlFieldName);
            labelElement.Class("form-label");
            wrapper.AddChild(labelElement);
        }

        wrapper.AddChild(FileInputFor(model, property, multiple, accept));
        return wrapper;
    }
}
