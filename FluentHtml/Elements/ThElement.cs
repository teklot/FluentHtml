using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class ThElement : Element
{
    public ThElement(params Node[] children) : base(children) => SetTag("th");
    public ThElement(string textContent) : base(textContent) => SetTag("th");

    public ThElement ColSpan(int span) { Attributes.Set("colspan", span.ToString()); return this; }
    public ThElement RowSpan(int span) { Attributes.Set("rowspan", span.ToString()); return this; }
}

public static class ThExtensions
{
    public static ThElement Th(params Node[] children) => new(children);
    public static ThElement Th(string textContent) => new(textContent);
}
