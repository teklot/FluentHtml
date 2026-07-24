using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class DelElement : Element
{
    public DelElement(params Node[] children) : base(children) => SetTag("del");
    public DelElement(string textContent) : base(textContent) => SetTag("del");
}

public static class DelExtensions
{
    public static DelElement Del(params Node[] children) => new(children);
    public static DelElement Del(string textContent) => new(textContent);
}
