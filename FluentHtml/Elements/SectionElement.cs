using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class SectionElement : Element
{
    public SectionElement(params Node[] children) : base(children) => SetTag("section");
    public SectionElement(string textContent) : base(textContent) => SetTag("section");
}

public static class SectionExtensions
{
    public static SectionElement Section(params Node[] children) => new(children);
    public static SectionElement Section(string textContent) => new(textContent);
}
