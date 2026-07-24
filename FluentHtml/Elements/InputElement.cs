using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class InputElement : Element
{
    public InputElement() => SetTag("input", selfClosing: true);

    public InputElement Type(string type) { Attributes.Set("type", type); return this; }
    public InputElement Value(string value) { Attributes.Set("value", value); return this; }
    public InputElement Name(string name) { Attributes.Set("name", name); return this; }
    public InputElement Placeholder(string placeholder) { Attributes.Set("placeholder", placeholder); return this; }
    public new InputElement Id(string id) { base.Id(id); return this; }
    public new InputElement Class(string className) { base.Class(className); return this; }
    public new InputElement Required() { base.Required(); return this; }
    public new InputElement Disabled() { base.Disabled(); return this; }
    public new InputElement ReadOnly() { base.ReadOnly(); return this; }
}

public static class InputExtensions
{
    public static InputElement Input() => new();
}
