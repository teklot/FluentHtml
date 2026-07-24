using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class VideoElement : Element
{
    public VideoElement(params Node[] children) : base(children) => SetTag("video");
    public VideoElement(string textContent) : base(textContent) => SetTag("video");

    public VideoElement Src(string src) { Attributes.Set("src", src); return this; }
    public VideoElement Controls() { Attributes.SetBool("controls"); return this; }
}

public static class VideoExtensions
{
    public static VideoElement Video(params Node[] children) => new(children);
    public static VideoElement Video(string textContent) => new(textContent);
}
