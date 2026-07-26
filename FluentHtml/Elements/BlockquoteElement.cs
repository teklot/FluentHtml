using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;blockquote&gt; element.
/// </summary>
public sealed class BlockquoteElement : Element<BlockquoteElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BlockquoteElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public BlockquoteElement(params Node[] children) : base(children) => SetTag("blockquote");

    /// <summary>
    /// Initializes a new instance of the <see cref="BlockquoteElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public BlockquoteElement(string textContent) : base(textContent) => SetTag("blockquote");

    /// <summary>
    /// Sets the cite attribute for this element.
    /// </summary>
    /// <param name="value">The cite value.</param>
    /// <returns>The current element for method chaining.</returns>
    public BlockquoteElement Cite(string value) { Attributes.Set("cite", value); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="BlockquoteElement"/> instances.
/// </summary>
public static class BlockquoteExtensions
{
    /// <summary>
    /// Creates a new &lt;blockquote&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="BlockquoteElement"/>.</returns>
    public static BlockquoteElement Blockquote(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;blockquote&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="BlockquoteElement"/>.</returns>
    public static BlockquoteElement Blockquote(string textContent) => new(textContent);
}
