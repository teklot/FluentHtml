using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class AbbrElement : Element
{
    public AbbrElement(params Node[] children) : base(children) => SetTag("abbr");
    public AbbrElement(string textContent) : base(textContent) => SetTag("abbr");
}

public static class AbbrExtensions
{
    public static AbbrElement Abbr(params Node[] children) => new(children);
    public static AbbrElement Abbr(string textContent) => new(textContent);
}
