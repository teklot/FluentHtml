using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class ColElement : Element
{
    public ColElement() => SetTag("col", selfClosing: true);
}

public static class ColExtensions
{
    public static ColElement Col() => new();
}
