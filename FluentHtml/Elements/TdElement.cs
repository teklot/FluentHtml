using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class TdElement : Element
{
    public TdElement(params Node[] children) : base(children) => SetTag("td");
    public TdElement(string textContent) : base(textContent) => SetTag("td");

    public TdElement ColSpan(int span) { Attributes.Set("colspan", span.ToString()); return this; }
    public TdElement RowSpan(int span) { Attributes.Set("rowspan", span.ToString()); return this; }
}

public static class TdExtensions
{
    public static TdElement Td(params Node[] children) => new(children);
    public static TdElement Td(string textContent) => new(textContent);
}
