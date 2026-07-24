using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class SupElement : Element
{
    public SupElement(params Node[] children) : base(children) => SetTag("sup");
    public SupElement(string textContent) : base(textContent) => SetTag("sup");
}

public static class SupExtensions
{
    public static SupElement Sup(params Node[] children) => new(children);
    public static SupElement Sup(string textContent) => new(textContent);
}
