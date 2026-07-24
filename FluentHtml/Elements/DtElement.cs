using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class DtElement : Element
{
    public DtElement(params Node[] children) : base(children) => SetTag("dt");
    public DtElement(string textContent) : base(textContent) => SetTag("dt");
}

public static class DtExtensions
{
    public static DtElement Dt(params Node[] children) => new(children);
    public static DtElement Dt(string textContent) => new(textContent);
}
