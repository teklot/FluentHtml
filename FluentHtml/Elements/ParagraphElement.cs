using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;p&gt; element.
/// </summary>
public sealed class ParagraphElement : Element<ParagraphElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ParagraphElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public ParagraphElement(params Node[] children) : base(children) => SetTag("p");

    /// <summary>
    /// Initializes a new instance of the <see cref="ParagraphElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public ParagraphElement(string textContent) : base(textContent) => SetTag("p");
}

/// <summary>
/// Factory methods for creating <see cref="ParagraphElement"/> instances.
/// </summary>
public static class ParagraphExtensions
{
    /// <summary>
    /// Creates a new &lt;p&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="ParagraphElement"/>.</returns>
    public static ParagraphElement P(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;p&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="ParagraphElement"/>.</returns>
    public static ParagraphElement P(string textContent) => new(textContent);
}
