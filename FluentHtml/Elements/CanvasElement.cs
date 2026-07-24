using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class CanvasElement : Element
{
    public CanvasElement(params Node[] children) : base(children) => SetTag("canvas");
    public CanvasElement(string textContent) : base(textContent) => SetTag("canvas");

    public CanvasElement Width(int width) { Attributes.Set("width", width.ToString()); return this; }
    public CanvasElement Height(int height) { Attributes.Set("height", height.ToString()); return this; }
}

public static class CanvasExtensions
{
    public static CanvasElement Canvas(params Node[] children) => new(children);
    public static CanvasElement Canvas(string textContent) => new(textContent);
}
