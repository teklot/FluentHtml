using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class MetaElement : Element
{
    public MetaElement() => SetTag("meta", selfClosing: true);

    public MetaElement Charset(string charset) { Attributes.Set("charset", charset); return this; }
    public MetaElement Name(string name) { Attributes.Set("name", name); return this; }
    public MetaElement Content(string content) { Attributes.Set("content", content); return this; }
    public MetaElement Property(string property) { Attributes.Set("property", property); return this; }
}

public static class MetaExtensions
{
    public static MetaElement Meta() => new();
}
