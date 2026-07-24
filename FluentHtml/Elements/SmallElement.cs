using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class SmallElement : Element
{
    public SmallElement(params Node[] children) : base(children) => SetTag("small");
    public SmallElement(string textContent) : base(textContent) => SetTag("small");
}

public static class SmallExtensions
{
    public static SmallElement Small(params Node[] children) => new(children);
    public static SmallElement Small(string textContent) => new(textContent);
}
