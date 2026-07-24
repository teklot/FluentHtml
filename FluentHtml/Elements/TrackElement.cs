using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class TrackElement : Element
{
    public TrackElement() => SetTag("track", selfClosing: true);
}

public static class TrackExtensions
{
    public static TrackElement Track() => new();
}
