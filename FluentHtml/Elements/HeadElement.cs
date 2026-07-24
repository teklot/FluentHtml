using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class HeadElement : Element
{
    public HeadElement(params Node[] children) : base(children) => SetTag("head");
    public HeadElement(string textContent) : base(textContent) => SetTag("head");
}

public static class HeadExtensions
{
    public static HeadElement Head(params Node[] children) => new(children);
    public static HeadElement Head(string textContent) => new(textContent);
}
