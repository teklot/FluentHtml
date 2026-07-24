using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class TemplateElement : Element
{
    public TemplateElement(params Node[] children) : base(children) => SetTag("template");
    public TemplateElement(string textContent) : base(textContent) => SetTag("template");
}

public static class TemplateExtensions
{
    public static TemplateElement Template(params Node[] children) => new(children);
    public static TemplateElement Template(string textContent) => new(textContent);
}
