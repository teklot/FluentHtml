using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class DetailsElement : Element
{
    public DetailsElement(params Node[] children) : base(children) => SetTag("details");
    public DetailsElement(string textContent) : base(textContent) => SetTag("details");
}

public static class DetailsExtensions
{
    public static DetailsElement Details(params Node[] children) => new(children);
    public static DetailsElement Details(string textContent) => new(textContent);
}
