using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;footer&gt; element.
/// </summary>
public sealed class FooterElement : Element<FooterElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FooterElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public FooterElement(params Node[] children) : base(children) => SetTag("footer");

    /// <summary>
    /// Initializes a new instance of the <see cref="FooterElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public FooterElement(string textContent) : base(textContent) => SetTag("footer");
}

/// <summary>
/// Factory methods for creating <see cref="FooterElement"/> instances.
/// </summary>
public static class FooterExtensions
{
    /// <summary>
    /// Creates a new &lt;footer&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="FooterElement"/>.</returns>
    public static FooterElement Footer(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;footer&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="FooterElement"/>.</returns>
    public static FooterElement Footer(string textContent) => new(textContent);
}
