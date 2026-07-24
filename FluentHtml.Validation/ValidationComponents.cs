using FluentHtml.Elements;
using FluentHtml.Nodes;

namespace FluentHtml.Validation;

public sealed class ValidationMessageComponent : Element
{
    public ValidationMessageComponent(string fieldName, string? errorMessage)
        : base(errorMessage ?? string.Empty)
    {
        SetTag("span");
        Class("field-validation-error");
        if (!string.IsNullOrEmpty(errorMessage))
            Class("text-danger");
    }
}

public sealed class ValidationSummaryComponent : Element
{
    public ValidationSummaryComponent(string? heading, IEnumerable<string> errors)
        : base(BuildContent(heading, errors))
    {
        SetTag("div");
        Class("validation-summary-errors");
    }

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
