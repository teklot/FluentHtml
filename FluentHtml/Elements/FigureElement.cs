using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;figure&gt; element.
/// </summary>
public sealed class FigureElement : Element<FigureElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FigureElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public FigureElement(params Node[] children) : base(children) => SetTag("figure");

    /// <summary>
    /// Initializes a new instance of the <see cref="FigureElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public FigureElement(string textContent) : base(textContent) => SetTag("figure");
}

/// <summary>
/// Factory methods for creating <see cref="FigureElement"/> instances.
/// </summary>
public static class FigureExtensions
{
    /// <summary>
    /// Creates a new &lt;figure&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="FigureElement"/>.</returns>
    public static FigureElement Figure(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;figure&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="FigureElement"/>.</returns>
    public static FigureElement Figure(string textContent) => new(textContent);
}
