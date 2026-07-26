using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;wbr&gt; element.
/// </summary>
public sealed class WbrElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WbrElement"/> class. The element is self-closing.
    /// </summary>
    public WbrElement() => SetTag("wbr", selfClosing: true);
}

/// <summary>
/// Factory methods for creating <see cref="WbrElement"/> instances.
/// </summary>
public static class WbrExtensions
{
    /// <summary>
    /// Creates a new &lt;wbr&gt; element.
    /// </summary>
    /// <returns>A new <see cref="WbrElement"/>.</returns>
    public static WbrElement Wbr() => new();
}
