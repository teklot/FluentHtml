using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class HtmlElement : Element
{
    public HtmlElement(params Node[] children) : base(children) => SetTag("html");
    public HtmlElement(string textContent) : base(textContent) => SetTag("html");
}

public static class HtmlExtensions
{
    public static HtmlElement Html(params Node[] children) => new(children);
    public static HtmlElement Html(string textContent) => new(textContent);
}
