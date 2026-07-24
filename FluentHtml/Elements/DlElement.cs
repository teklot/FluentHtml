using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class DlElement : Element
{
    public DlElement(params Node[] children) : base(children) => SetTag("dl");
    public DlElement(string textContent) : base(textContent) => SetTag("dl");
}

public static class DlExtensions
{
    public static DlElement Dl(params Node[] children) => new(children);
    public static DlElement Dl(string textContent) => new(textContent);
}
