using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class FigcaptionElement : Element
{
    public FigcaptionElement(params Node[] children) : base(children) => SetTag("figcaption");
    public FigcaptionElement(string textContent) : base(textContent) => SetTag("figcaption");
}

public static class FigcaptionExtensions
{
    public static FigcaptionElement Figcaption(params Node[] children) => new(children);
    public static FigcaptionElement Figcaption(string textContent) => new(textContent);
}
