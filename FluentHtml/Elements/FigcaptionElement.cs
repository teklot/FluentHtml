using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;figcaption&gt; element.
/// </summary>
public sealed class FigcaptionElement : Element<FigcaptionElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FigcaptionElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public FigcaptionElement(params Node[] children) : base(children) => SetTag("figcaption");

    /// <summary>
    /// Initializes a new instance of the <see cref="FigcaptionElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public FigcaptionElement(string textContent) : base(textContent) => SetTag("figcaption");
}

/// <summary>
/// Factory methods for creating <see cref="FigcaptionElement"/> instances.
/// </summary>
public static class FigcaptionExtensions
{
    /// <summary>
    /// Creates a new &lt;figcaption&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="FigcaptionElement"/>.</returns>
    public static FigcaptionElement Figcaption(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;figcaption&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="FigcaptionElement"/>.</returns>
    public static FigcaptionElement Figcaption(string textContent) => new(textContent);
}
