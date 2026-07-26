using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;track&gt; element.
/// </summary>
public sealed class TrackElement : Element<TrackElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TrackElement"/> class. The element is self-closing.
    /// </summary>
    public TrackElement() => SetTag("track", selfClosing: true);
}

/// <summary>
/// Factory methods for creating <see cref="TrackElement"/> instances.
/// </summary>
public static class TrackExtensions
{
    /// <summary>
    /// Creates a new &lt;track&gt; element.
    /// </summary>
    /// <returns>A new <see cref="TrackElement"/>.</returns>
    public static TrackElement Track() => new();
}
