using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;img&gt; element. Use the <see cref="ImgExtensions.Img"/> factory method to create instances.
/// </summary>
public sealed class ImgElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImgElement"/> class. The element is self-closing.
    /// </summary>
    public ImgElement() => SetTag("img", selfClosing: true);

    /// <summary>
    /// Sets the src attribute for this image element.
    /// </summary>
    /// <param name="src">The image URL.</param>
    /// <returns>The current image for method chaining.</returns>
    public ImgElement Src(string src) { Attributes.Set("src", src); return this; }

    /// <summary>
    /// Sets the alt attribute for this image element.
    /// </summary>
    /// <param name="alt">The alternative text description.</param>
    /// <returns>The current image for method chaining.</returns>
    public ImgElement Alt(string alt) { Attributes.Set("alt", alt); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="ImgElement"/> instances.
/// </summary>
public static class ImgExtensions
{
    /// <summary>
    /// Creates a new &lt;img&gt; element.
    /// </summary>
    /// <returns>A new <see cref="ImgElement"/>.</returns>
    public static ImgElement Img() => new();
}