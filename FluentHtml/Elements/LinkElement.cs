using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class LinkElement : Element
{
    public LinkElement() => SetTag("link", selfClosing: true);

    public LinkElement Rel(string rel) { Attributes.Set("rel", rel); return this; }
    public LinkElement Href(string href) { Attributes.Set("href", href); return this; }
}

public static class LinkExtensions
{
    public static LinkElement Link() => new();
}
