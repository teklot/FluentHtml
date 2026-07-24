using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class LabelElement : Element
{
    public LabelElement(params Node[] children) : base(children) => SetTag("label");
    public LabelElement(string textContent) : base(textContent) => SetTag("label");

    public LabelElement For(string forId) { Attributes.Set("for", forId); return this; }
    public new LabelElement Id(string id) { base.Id(id); return this; }
    public new LabelElement Class(string className) { base.Class(className); return this; }
}

public static class LabelExtensions
{
    public static LabelElement Label(params Node[] children) => new(children);
    public static LabelElement Label(string textContent) => new(textContent);
}
