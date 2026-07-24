using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class TheadElement : Element
{
    public TheadElement(params Node[] children) : base(children) => SetTag("thead");
    public TheadElement(string textContent) : base(textContent) => SetTag("thead");
}

public static class TheadExtensions
{
    public static TheadElement Thead(params Node[] children) => new(children);
    public static TheadElement Thead(string textContent) => new(textContent);
}
