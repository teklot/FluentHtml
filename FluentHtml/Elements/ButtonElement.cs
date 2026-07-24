using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class ButtonElement : Element
{
    public ButtonElement(params Node[] children) : base(children) => SetTag("button");
    public ButtonElement(string textContent) : base(textContent) => SetTag("button");

    public ButtonElement Type(string type) { Attributes.Set("type", type); return this; }
    public new ButtonElement Id(string id) { base.Id(id); return this; }
    public new ButtonElement Class(string className) { base.Class(className); return this; }
    public new ButtonElement Disabled() { base.Disabled(); return this; }
    public new ButtonElement Required() { base.Required(); return this; }
}

public static class ButtonExtensions
{
    public static ButtonElement Button(params Node[] children) => new(children);
    public static ButtonElement Button(string textContent) => new(textContent);
}
