using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class MapElement : Element
{
    public MapElement(params Node[] children) : base(children) => SetTag("map");
    public MapElement(string textContent) : base(textContent) => SetTag("map");
}

public static class MapExtensions
{
    public static MapElement Map(params Node[] children) => new(children);
    public static MapElement Map(string textContent) => new(textContent);
}
