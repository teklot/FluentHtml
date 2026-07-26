using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;a&gt; element. Use the A() factory methods to create instances.
/// </summary>
public sealed class AnchorElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AnchorElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public AnchorElement(params Node[] children) : base(children) => SetTag("a");

    /// <summary>
    /// Initializes a new instance of the <see cref="AnchorElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The link text.</param>
    public AnchorElement(string textContent) : base(textContent) => SetTag("a");

    /// <summary>
    /// Sets the href attribute for this anchor element.
    /// </summary>
    /// <param name="href">The URL to link to.</param>
    /// <returns>The current anchor for method chaining.</returns>
    public AnchorElement Href(string href) { Attributes.Set("href", href); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="AnchorElement"/> instances.
/// </summary>
public static class AnchorExtensions
{
    /// <summary>
    /// Creates a new &lt;a&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="AnchorElement"/>.</returns>
    public static AnchorElement A(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;a&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The link text.</param>
    /// <returns>A new <see cref="AnchorElement"/>.</returns>
    public static AnchorElement A(string textContent) => new(textContent);
}
