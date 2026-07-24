using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class NavElement : Element
{
    public NavElement(params Node[] children) : base(children) => SetTag("nav");
    public NavElement(string textContent) : base(textContent) => SetTag("nav");

    public new NavElement Id(string id) { base.Id(id); return this; }
    public new NavElement Class(string className) { base.Class(className); return this; }
}

public static class NavExtensions
{
    public static NavElement Nav(params Node[] children) => new(children);
    public static NavElement Nav(string textContent) => new(textContent);
}
