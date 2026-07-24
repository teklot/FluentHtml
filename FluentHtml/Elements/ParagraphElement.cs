using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class ParagraphElement : Element
{
    public ParagraphElement(params Node[] children) : base(children) => SetTag("p");
    public ParagraphElement(string textContent) : base(textContent) => SetTag("p");

    public new ParagraphElement Id(string id) { base.Id(id); return this; }
    public new ParagraphElement Class(string className) { base.Class(className); return this; }
    public ParagraphElement Lead() => (ParagraphElement)Class("lead");
}

public static class ParagraphExtensions
{
    public static ParagraphElement P(params Node[] children) => new(children);
    public static ParagraphElement P(string textContent) => new(textContent);
}
