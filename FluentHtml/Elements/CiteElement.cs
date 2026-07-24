using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class CiteElement : Element
{
    public CiteElement(params Node[] children) : base(children) => SetTag("cite");
    public CiteElement(string textContent) : base(textContent) => SetTag("cite");
}

public static class CiteExtensions
{
    public static CiteElement Cite(params Node[] children) => new(children);
    public static CiteElement Cite(string textContent) => new(textContent);
}
