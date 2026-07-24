using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class SelectElement : Element
{
    public SelectElement(params Node[] children) : base(children) => SetTag("select");
    public SelectElement(string textContent) : base(textContent) => SetTag("select");

    public SelectElement Name(string name) { Attributes.Set("name", name); return this; }
    public new SelectElement Id(string id) { base.Id(id); return this; }
    public new SelectElement Class(string className) { base.Class(className); return this; }
    public new SelectElement Disabled() { base.Disabled(); return this; }
    public new SelectElement Required() { base.Required(); return this; }
}

public static class SelectExtensions
{
    public static SelectElement Select(params Node[] children) => new(children);
    public static SelectElement Select(string textContent) => new(textContent);
}
