using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class TrElement : Element
{
    public TrElement(params Node[] children) : base(children) => SetTag("tr");
    public TrElement(string textContent) : base(textContent) => SetTag("tr");
}

public static class TrExtensions
{
    public static TrElement Tr(params Node[] children) => new(children);
    public static TrElement Tr(string textContent) => new(textContent);
}
