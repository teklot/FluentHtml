using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class DivElement : Element
{
    public DivElement(params Node[] children) : base(children) => SetTag("div");
    public DivElement(string textContent) : base(textContent) => SetTag("div");

    public new DivElement Id(string id) { base.Id(id); return this; }
    public new DivElement Class(string className) { base.Class(className); return this; }
    public new DivElement Style(string style) { base.Style(style); return this; }
    public new DivElement Data(string key, string value) { base.Data(key, value); return this; }
    public new DivElement Aria(string key, string value) { base.Aria(key, value); return this; }
    public new DivElement Role(string role) { base.Role(role); return this; }
    public new DivElement Hidden() { base.Hidden(); return this; }
    public new DivElement Disabled() { base.Disabled(); return this; }
    public new DivElement Required() { base.Required(); return this; }
    public new DivElement ReadOnly() { base.ReadOnly(); return this; }
    public new DivElement Custom(string name, string value) { base.Custom(name, value); return this; }
    public new DivElement On(string eventName, string handler) { base.On(eventName, handler); return this; }
}

public static class DivExtensions
{
    public static DivElement Div(params Node[] children) => new(children);
    public static DivElement Div(string textContent) => new(textContent);
}
