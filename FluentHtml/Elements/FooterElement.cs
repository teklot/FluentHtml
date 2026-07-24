using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class FooterElement : Element
{
    public FooterElement(params Node[] children) : base(children) => SetTag("footer");
    public FooterElement(string textContent) : base(textContent) => SetTag("footer");
}

public static class FooterExtensions
{
    public static FooterElement Footer(params Node[] children) => new(children);
    public static FooterElement Footer(string textContent) => new(textContent);
}
