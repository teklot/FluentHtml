using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class CaptionElement : Element
{
    public CaptionElement(params Node[] children) : base(children) => SetTag("caption");
    public CaptionElement(string textContent) : base(textContent) => SetTag("caption");
}

public static class CaptionExtensions
{
    public static CaptionElement Caption(params Node[] children) => new(children);
    public static CaptionElement Caption(string textContent) => new(textContent);
}
