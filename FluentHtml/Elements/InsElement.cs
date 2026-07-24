using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class InsElement : Element
{
    public InsElement(params Node[] children) : base(children) => SetTag("ins");
    public InsElement(string textContent) : base(textContent) => SetTag("ins");
}

public static class InsExtensions
{
    public static InsElement Ins(params Node[] children) => new(children);
    public static InsElement Ins(string textContent) => new(textContent);
}
