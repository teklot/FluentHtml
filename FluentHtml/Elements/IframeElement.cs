using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class IframeElement : Element
{
    public IframeElement(params Node[] children) : base(children) => SetTag("iframe");
    public IframeElement(string textContent) : base(textContent) => SetTag("iframe");

    public IframeElement Src(string src) { Attributes.Set("src", src); return this; }
}

public static class IframeExtensions
{
    public static IframeElement Iframe(params Node[] children) => new(children);
    public static IframeElement Iframe(string textContent) => new(textContent);
}
