using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;mark&gt; element.
/// </summary>
public sealed class MarkElement : Element<MarkElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarkElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public MarkElement(params Node[] children) : base(children) => SetTag("mark");

    /// <summary>
    /// Initializes a new instance of the <see cref="MarkElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public MarkElement(string textContent) : base(textContent) => SetTag("mark");
}

/// <summary>
/// Factory methods for creating <see cref="MarkElement"/> instances.
/// </summary>
public static class MarkExtensions
{
    /// <summary>
    /// Creates a new &lt;mark&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="MarkElement"/>.</returns>
    public static MarkElement Mark(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;mark&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="MarkElement"/>.</returns>
    public static MarkElement Mark(string textContent) => new(textContent);
}
