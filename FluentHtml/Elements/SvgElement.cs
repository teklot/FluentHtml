using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class SvgElement : Element
{
    public SvgElement(params Node[] children) : base(children) => SetTag("svg");
    public SvgElement(string textContent) : base(textContent) => SetTag("svg");
}

public static class SvgExtensions
{
    public static SvgElement Svg(params Node[] children) => new(children);
    public static SvgElement Svg(string textContent) => new(textContent);
}
