using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class UlElement : Element
{
    public UlElement(params Node[] children) : base(children) => SetTag("ul");
    public UlElement(string textContent) : base(textContent) => SetTag("ul");
}

public static class UlExtensions
{
    public static UlElement Ul(params Node[] children) => new(children);
    public static UlElement Ul(string textContent) => new(textContent);
}
