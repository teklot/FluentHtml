using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class LiElement : Element
{
    public LiElement(params Node[] children) : base(children) => SetTag("li");
    public LiElement(string textContent) : base(textContent) => SetTag("li");
}

public static class LiExtensions
{
    public static LiElement Li(params Node[] children) => new(children);
    public static LiElement Li(string textContent) => new(textContent);
}
