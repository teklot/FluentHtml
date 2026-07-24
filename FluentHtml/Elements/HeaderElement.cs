using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class HeaderElement : Element
{
    public HeaderElement(params Node[] children) : base(children) => SetTag("header");
    public HeaderElement(string textContent) : base(textContent) => SetTag("header");
}

public static class HeaderExtensions
{
    public static HeaderElement Header(params Node[] children) => new(children);
    public static HeaderElement Header(string textContent) => new(textContent);
}
