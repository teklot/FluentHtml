using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class MarkElement : Element
{
    public MarkElement(params Node[] children) : base(children) => SetTag("mark");
    public MarkElement(string textContent) : base(textContent) => SetTag("mark");
}

public static class MarkExtensions
{
    public static MarkElement Mark(params Node[] children) => new(children);
    public static MarkElement Mark(string textContent) => new(textContent);
}
