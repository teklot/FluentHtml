using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class LegendElement : Element
{
    public LegendElement(params Node[] children) : base(children) => SetTag("legend");
    public LegendElement(string textContent) : base(textContent) => SetTag("legend");
}

public static class LegendExtensions
{
    public static LegendElement Legend(params Node[] children) => new(children);
    public static LegendElement Legend(string textContent) => new(textContent);
}
