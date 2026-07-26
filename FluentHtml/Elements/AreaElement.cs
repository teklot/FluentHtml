using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;area&gt; element.
/// </summary>
public sealed class AreaElement : Element<AreaElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AreaElement"/> class. The element is self-closing.
    /// </summary>
    public AreaElement() => SetTag("area", selfClosing: true);
}

/// <summary>
/// Factory methods for creating <see cref="AreaElement"/> instances.
/// </summary>
public static class AreaExtensions
{
    /// <summary>
    /// Creates a new &lt;area&gt; element.
    /// </summary>
    /// <returns>A new <see cref="AreaElement"/>.</returns>
    public static AreaElement Area() => new();
}
