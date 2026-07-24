using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class AsideElement : Element
{
    public AsideElement(params Node[] children) : base(children) => SetTag("aside");
    public AsideElement(string textContent) : base(textContent) => SetTag("aside");
}

public static class AsideExtensions
{
    public static AsideElement Aside(params Node[] children) => new(children);
    public static AsideElement Aside(string textContent) => new(textContent);
}
