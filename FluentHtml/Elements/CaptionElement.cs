using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;caption&gt; element.
/// </summary>
public sealed class CaptionElement : Element<CaptionElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CaptionElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public CaptionElement(params Node[] children) : base(children) => SetTag("caption");

    /// <summary>
    /// Initializes a new instance of the <see cref="CaptionElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public CaptionElement(string textContent) : base(textContent) => SetTag("caption");
}

/// <summary>
/// Factory methods for creating <see cref="CaptionElement"/> instances.
/// </summary>
public static class CaptionExtensions
{
    /// <summary>
    /// Creates a new &lt;caption&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="CaptionElement"/>.</returns>
    public static CaptionElement Caption(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;caption&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="CaptionElement"/>.</returns>
    public static CaptionElement Caption(string textContent) => new(textContent);
}
