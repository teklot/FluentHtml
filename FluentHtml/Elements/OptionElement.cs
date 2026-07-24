using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class OptionElement : Element
{
    public OptionElement(params Node[] children) : base(children) => SetTag("option");
    public OptionElement(string textContent) : base(textContent) => SetTag("option");

    public OptionElement Value(string value) { Attributes.Set("value", value); return this; }
    public OptionElement Selected() { Attributes.SetBool("selected"); return this; }
}

public static class OptionExtensions
{
    public static OptionElement Option(params Node[] children) => new(children);
    public static OptionElement Option(string textContent) => new(textContent);
}
