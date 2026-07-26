using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;picture&gt; element.
/// </summary>
public sealed class PictureElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PictureElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public PictureElement(params Node[] children) : base(children) => SetTag("picture");

    /// <summary>
    /// Initializes a new instance of the <see cref="PictureElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public PictureElement(string textContent) : base(textContent) => SetTag("picture");
}

/// <summary>
/// Factory methods for creating <see cref="PictureElement"/> instances.
/// </summary>
public static class PictureExtensions
{
    /// <summary>
    /// Creates a new &lt;picture&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="PictureElement"/>.</returns>
    public static PictureElement Picture(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;picture&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="PictureElement"/>.</returns>
    public static PictureElement Picture(string textContent) => new(textContent);
}
