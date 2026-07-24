using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class WbrElement : Element
{
    public WbrElement() => SetTag("wbr", selfClosing: true);
}

public static class WbrExtensions
{
    public static WbrElement Wbr() => new();
}
