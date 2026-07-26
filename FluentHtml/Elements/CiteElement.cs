using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;cite&gt; element.
/// </summary>
public sealed class CiteElement : Element<CiteElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CiteElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public CiteElement(params Node[] children) : base(children) => SetTag("cite");

    /// <summary>
    /// Initializes a new instance of the <see cref="CiteElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public CiteElement(string textContent) : base(textContent) => SetTag("cite");
}

/// <summary>
/// Factory methods for creating <see cref="CiteElement"/> instances.
/// </summary>
public static class CiteExtensions
{
    /// <summary>
    /// Creates a new &lt;cite&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="CiteElement"/>.</returns>
    public static CiteElement Cite(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;cite&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="CiteElement"/>.</returns>
    public static CiteElement Cite(string textContent) => new(textContent);
}
