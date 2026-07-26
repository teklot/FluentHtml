using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;header&gt; element.
/// </summary>
public sealed class HeaderElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HeaderElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public HeaderElement(params Node[] children) : base(children) => SetTag("header");

    /// <summary>
    /// Initializes a new instance of the <see cref="HeaderElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public HeaderElement(string textContent) : base(textContent) => SetTag("header");
}

/// <summary>
/// Factory methods for creating <see cref="HeaderElement"/> instances.
/// </summary>
public static class HeaderExtensions
{
    /// <summary>
    /// Creates a new &lt;header&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="HeaderElement"/>.</returns>
    public static HeaderElement Header(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;header&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="HeaderElement"/>.</returns>
    public static HeaderElement Header(string textContent) => new(textContent);
}
