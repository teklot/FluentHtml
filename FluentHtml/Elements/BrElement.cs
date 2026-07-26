using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;br&gt; element.
/// </summary>
public sealed class BrElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BrElement"/> class. The element is self-closing.
    /// </summary>
    public BrElement() => SetTag("br", selfClosing: true);
}

/// <summary>
/// Factory methods for creating <see cref="BrElement"/> instances.
/// </summary>
public static class BrExtensions
{
    /// <summary>
    /// Creates a new &lt;br&gt; element.
    /// </summary>
    /// <returns>A new <see cref="BrElement"/>.</returns>
    public static BrElement Br() => new();
}
