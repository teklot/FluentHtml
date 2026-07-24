using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class TitleElement : Element
{
    public TitleElement(params Node[] children) : base(children) => SetTag("title");
    public TitleElement(string textContent) : base(textContent) => SetTag("title");
}

public static class TitleExtensions
{
    public static TitleElement Title(params Node[] children) => new(children);
    public static TitleElement Title(string textContent) => new(textContent);
}
