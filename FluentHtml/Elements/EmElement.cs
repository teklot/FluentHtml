using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class EmElement : Element
{
    public EmElement(params Node[] children) : base(children) => SetTag("em");
    public EmElement(string textContent) : base(textContent) => SetTag("em");
}

public static class EmExtensions
{
    public static EmElement Em(params Node[] children) => new(children);
    public static EmElement Em(string textContent) => new(textContent);
}
