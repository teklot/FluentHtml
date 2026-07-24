using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class AnchorElement : Element
{
    public AnchorElement(params Node[] children) : base(children) => SetTag("a");
    public AnchorElement(string textContent) : base(textContent) => SetTag("a");

    public AnchorElement Href(string href) { Attributes.Set("href", href); return this; }
    public new AnchorElement Id(string id) { base.Id(id); return this; }
    public new AnchorElement Class(string className) { base.Class(className); return this; }
}

public static class AnchorExtensions
{
    public static AnchorElement A(params Node[] children) => new(children);
    public static AnchorElement A(string textContent) => new(textContent);
}
