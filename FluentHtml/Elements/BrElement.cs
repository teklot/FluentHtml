using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class BrElement : Element
{
    public BrElement() => SetTag("br", selfClosing: true);
}

public static class BrExtensions
{
    public static BrElement Br() => new();
}
