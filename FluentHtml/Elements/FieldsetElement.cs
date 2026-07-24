using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class FieldsetElement : Element
{
    public FieldsetElement(params Node[] children) : base(children) => SetTag("fieldset");
    public FieldsetElement(string textContent) : base(textContent) => SetTag("fieldset");
}

public static class FieldsetExtensions
{
    public static FieldsetElement Fieldset(params Node[] children) => new(children);
    public static FieldsetElement Fieldset(string textContent) => new(textContent);
}
