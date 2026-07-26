using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;sup&gt; element.
/// </summary>
public sealed class SupElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SupElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public SupElement(params Node[] children) : base(children) => SetTag("sup");

    /// <summary>
    /// Initializes a new instance of the <see cref="SupElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public SupElement(string textContent) : base(textContent) => SetTag("sup");
}

/// <summary>
/// Factory methods for creating <see cref="SupElement"/> instances.
/// </summary>
public static class SupExtensions
{
    /// <summary>
    /// Creates a new &lt;sup&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="SupElement"/>.</returns>
    public static SupElement Sup(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;sup&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="SupElement"/>.</returns>
    public static SupElement Sup(string textContent) => new(textContent);
}
