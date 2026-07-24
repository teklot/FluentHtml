using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class ColgroupElement : Element
{
    public ColgroupElement(params Node[] children) : base(children) => SetTag("colgroup");
    public ColgroupElement(string textContent) : base(textContent) => SetTag("colgroup");
}

public static class ColgroupExtensions
{
    public static ColgroupElement Colgroup(params Node[] children) => new(children);
    public static ColgroupElement Colgroup(string textContent) => new(textContent);
}
