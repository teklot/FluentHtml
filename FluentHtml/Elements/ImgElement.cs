using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class ImgElement : Element
{
    public ImgElement() => SetTag("img", selfClosing: true);

    public ImgElement Src(string src) { Attributes.Set("src", src); return this; }
    public ImgElement Alt(string alt) { Attributes.Set("alt", alt); return this; }
}

public static class ImgExtensions
{
    public static ImgElement Img() => new();
}
