using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;em&gt; element.
/// </summary>
public sealed class EmElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public EmElement(params Node[] children) : base(children) => SetTag("em");

    /// <summary>
    /// Initializes a new instance of the <see cref="EmElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public EmElement(string textContent) : base(textContent) => SetTag("em");
}

/// <summary>
/// Factory methods for creating <see cref="EmElement"/> instances.
/// </summary>
public static class EmExtensions
{
    /// <summary>
    /// Creates a new &lt;em&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="EmElement"/>.</returns>
    public static EmElement Em(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;em&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="EmElement"/>.</returns>
    public static EmElement Em(string textContent) => new(textContent);
}
