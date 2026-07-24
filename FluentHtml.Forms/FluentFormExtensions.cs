using FluentHtml.Elements;
using FluentHtml.Nodes;
using System.Linq.Expressions;

namespace FluentHtml.Forms;

public static class FluentFormExtensions
{
    public static InputElement InputFor<TModel>(this TModel model, Expression<Func<TModel, object?>> property) where TModel : notnull
    {
        var expression = new ModelExpression<TModel>(property);
        return new InputElement()
            .Type("text")
            .Name(expression.HtmlFieldName)
            .Id(expression.HtmlFieldName)
            .Class("form-control");
    }

    public static InputElement InputFor<TModel>(this TModel model, Expression<Func<TModel, object?>> property, string type) where TModel : notnull
    {
        var expression = new ModelExpression<TModel>(property);
        return new InputElement()
            .Type(type)
            .Name(expression.HtmlFieldName)
            .Id(expression.HtmlFieldName)
            .Class("form-control");
    }

    public static LabelElement LabelFor<TModel>(this TModel model, Expression<Func<TModel, object?>> property) where TModel : notnull
    {
        var expression = new ModelExpression<TModel>(property);
        return new LabelElement(expression.DisplayName)
            .For(expression.HtmlFieldName)
            .Class("form-label");
    }

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

    public static InputElement CheckboxFor<TModel>(this TModel model, Expression<Func<TModel, object?>> property) where TModel : notnull
    {
        var expression = new ModelExpression<TModel>(property);
        return new InputElement()
            .Type("checkbox")
            .Name(expression.HtmlFieldName)
            .Id(expression.HtmlFieldName)
            .Class("form-check-input");
    }

    public static LabelElement CheckboxLabelFor<TModel>(this TModel model, Expression<Func<TModel, object?>> property, string? label = null) where TModel : notnull
    {
        var expression = new ModelExpression<TModel>(property);
        return new LabelElement(label ?? expression.DisplayName)
            .For(expression.HtmlFieldName)
            .Class("form-check-label");
    }

    public static ButtonElement SubmitButton(string text = "Submit")
    {
        return new ButtonElement(text)
            .Type("submit")
            .Class("btn btn-primary");
    }

    public static ButtonElement SubmitButton(string text, string cssClass)
    {
        return new ButtonElement(text)
            .Type("submit")
            .Class(cssClass);
    }
}
