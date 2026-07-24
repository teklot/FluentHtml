using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class DfnElement : Element
{
    public DfnElement(params Node[] children) : base(children) => SetTag("dfn");
    public DfnElement(string textContent) : base(textContent) => SetTag("dfn");
}

public static class DfnExtensions
{
    public static DfnElement Dfn(params Node[] children) => new(children);
    public static DfnElement Dfn(string textContent) => new(textContent);
}
