using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class DdElement : Element
{
    public DdElement(params Node[] children) : base(children) => SetTag("dd");
    public DdElement(string textContent) : base(textContent) => SetTag("dd");
}

public static class DdExtensions
{
    public static DdElement Dd(params Node[] children) => new(children);
    public static DdElement Dd(string textContent) => new(textContent);
}
