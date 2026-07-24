using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class EmbedElement : Element
{
    public EmbedElement() => SetTag("embed", selfClosing: true);
}

public static class EmbedExtensions
{
    public static EmbedElement Embed() => new();
}
