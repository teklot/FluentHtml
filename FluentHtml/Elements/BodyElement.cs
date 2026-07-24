using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class BodyElement : Element
{
    public BodyElement(params Node[] children) : base(children) => SetTag("body");
    public BodyElement(string textContent) : base(textContent) => SetTag("body");
}

public static class BodyExtensions
{
    public static BodyElement Body(params Node[] children) => new(children);
    public static BodyElement Body(string textContent) => new(textContent);
}
