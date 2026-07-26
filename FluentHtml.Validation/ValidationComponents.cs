using FluentHtml.Elements;
using FluentHtml.Nodes;

namespace FluentHtml.Validation;

/// <summary>
/// A FluentHtml element that renders a field-level validation error message inside a styled span.
/// </summary>
public sealed class ValidationMessageComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationMessageComponent"/> class.
    /// Renders a span with the <c>field-validation-error</c> CSS class, and adds <c>text-danger</c> when an error message is present.
    /// </summary>
    /// <param name="fieldName">The name of the field this validation message is associated with.</param>
    /// <param name="errorMessage">The validation error message to display, or <c>null</c> if the field is valid.</param>
    public ValidationMessageComponent(string fieldName, string? errorMessage)
        : base(errorMessage ?? string.Empty)
    {
        SetTag("span");
        Class("field-validation-error");
        if (!string.IsNullOrEmpty(errorMessage))
            Class("text-danger");
    }
}

/// <summary>
/// A FluentHtml element that renders a summary of all validation errors as an unordered list inside a div.
/// </summary>
public sealed class ValidationSummaryComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationSummaryComponent"/> class.
    /// Builds a div containing an optional heading and an unordered list of all error messages.
    /// </summary>
    /// <param name="heading">An optional heading to display above the error list, or <c>null</c> to omit the heading.</param>
    /// <param name="errors">The collection of validation error messages to display.</param>
    public ValidationSummaryComponent(string? heading, IEnumerable<string> errors)
        : base(BuildContent(heading, errors))
    {
        SetTag("div");
        Class("validation-summary-errors");
    }

    /// <summary>
    /// Builds the child nodes for the validation summary, including an optional heading and the error list.
    /// </summary>
    /// <param name="heading">An optional heading string, or <c>null</c> to omit.</param>
    /// <param name="errors">The collection of validation error messages to render as list items.</param>
    /// <returns>An array of <see cref="Node"/> instances representing the heading and unordered list.</returns>
    private static Node[] BuildContent(string? heading, IEnumerable<string> errors)
    {
        var nodes = new List<Node>();

        if (!string.IsNullOrEmpty(heading))
            nodes.Add(new Heading3Element(heading));

        var list = new UlElement(errors.Select(e => new LiElement(e)).ToArray());
        nodes.Add(list);

        return nodes.ToArray();
    }
}
