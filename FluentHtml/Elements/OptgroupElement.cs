using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class OptgroupElement : Element
{
    public OptgroupElement(params Node[] children) : base(children) => SetTag("optgroup");
    public OptgroupElement(string textContent) : base(textContent) => SetTag("optgroup");

    public OptgroupElement Label(string label) { Attributes.Set("label", label); return this; }
}

public static class OptgroupExtensions
{
    public static OptgroupElement Optgroup(params Node[] children) => new(children);
    public static OptgroupElement Optgroup(string textContent) => new(textContent);
}
