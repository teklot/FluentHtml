using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class StyleElement : Element
{
    public StyleElement(params Node[] children) : base(children) => SetTag("style");
    public StyleElement(string textContent) : base(new RawHtml(textContent ?? string.Empty)) => SetTag("style");
}

public static class StyleExtensions
{
    public static StyleElement Style(params Node[] children) => new(children);
    public static StyleElement Style(string textContent) => new(textContent);
}
