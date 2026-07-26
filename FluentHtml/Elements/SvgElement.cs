using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;svg&gt; element.
/// </summary>
public sealed class SvgElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SvgElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public SvgElement(params Node[] children) : base(children) => SetTag("svg");

    /// <summary>
    /// Initializes a new instance of the <see cref="SvgElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public SvgElement(string textContent) : base(textContent) => SetTag("svg");
}

/// <summary>
/// Factory methods for creating <see cref="SvgElement"/> instances.
/// </summary>
public static class SvgExtensions
{
    /// <summary>
    /// Creates a new &lt;svg&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="SvgElement"/>.</returns>
    public static SvgElement Svg(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;svg&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="SvgElement"/>.</returns>
    public static SvgElement Svg(string textContent) => new(textContent);
}
