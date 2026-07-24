using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class PictureElement : Element
{
    public PictureElement(params Node[] children) : base(children) => SetTag("picture");
    public PictureElement(string textContent) : base(textContent) => SetTag("picture");
}

public static class PictureExtensions
{
    public static PictureElement Picture(params Node[] children) => new(children);
    public static PictureElement Picture(string textContent) => new(textContent);
}
