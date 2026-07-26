using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;tbody&gt; element.
/// </summary>
public sealed class TbodyElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TbodyElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public TbodyElement(params Node[] children) : base(children) => SetTag("tbody");

    /// <summary>
    /// Initializes a new instance of the <see cref="TbodyElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public TbodyElement(string textContent) : base(textContent) => SetTag("tbody");
}

/// <summary>
/// Factory methods for creating <see cref="TbodyElement"/> instances.
/// </summary>
public static class TbodyExtensions
{
    /// <summary>
    /// Creates a new &lt;tbody&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="TbodyElement"/>.</returns>
    public static TbodyElement Tbody(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;tbody&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="TbodyElement"/>.</returns>
    public static TbodyElement Tbody(string textContent) => new(textContent);
}
