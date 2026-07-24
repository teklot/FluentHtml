using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class AreaElement : Element
{
    public AreaElement() => SetTag("area", selfClosing: true);
}

public static class AreaExtensions
{
    public static AreaElement Area() => new();
}
