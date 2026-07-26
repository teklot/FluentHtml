using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;body&gt; element.
/// </summary>
public sealed class BodyElement : Element<BodyElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BodyElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public BodyElement(params Node[] children) : base(children) => SetTag("body");

    /// <summary>
    /// Initializes a new instance of the <see cref="BodyElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public BodyElement(string textContent) : base(textContent) => SetTag("body");
}

/// <summary>
/// Factory methods for creating <see cref="BodyElement"/> instances.
/// </summary>
public static class BodyExtensions
{
    /// <summary>
    /// Creates a new &lt;body&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="BodyElement"/>.</returns>
    public static BodyElement Body(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;body&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="BodyElement"/>.</returns>
    public static BodyElement Body(string textContent) => new(textContent);
}
