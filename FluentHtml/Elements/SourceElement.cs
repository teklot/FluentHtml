using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class SourceElement : Element
{
    public SourceElement() => SetTag("source", selfClosing: true);
}

public static class SourceExtensions
{
    public static SourceElement Source() => new();
}
