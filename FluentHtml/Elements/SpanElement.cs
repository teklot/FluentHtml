using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class SpanElement : Element
{
    public SpanElement(params Node[] children) : base(children) => SetTag("span");
    public SpanElement(string textContent) : base(textContent) => SetTag("span");
}

public static class SpanExtensions
{
    public static SpanElement Span(params Node[] children) => new(children);
    public static SpanElement Span(string textContent) => new(textContent);
}
