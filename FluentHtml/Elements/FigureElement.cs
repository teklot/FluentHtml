using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class FigureElement : Element
{
    public FigureElement(params Node[] children) : base(children) => SetTag("figure");
    public FigureElement(string textContent) : base(textContent) => SetTag("figure");
}

public static class FigureExtensions
{
    public static FigureElement Figure(params Node[] children) => new(children);
    public static FigureElement Figure(string textContent) => new(textContent);
}
