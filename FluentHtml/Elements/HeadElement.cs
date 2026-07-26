using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;head&gt; element.
/// </summary>
public sealed class HeadElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HeadElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public HeadElement(params Node[] children) : base(children) => SetTag("head");

    /// <summary>
    /// Initializes a new instance of the <see cref="HeadElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public HeadElement(string textContent) : base(textContent) => SetTag("head");
}

/// <summary>
/// Factory methods for creating <see cref="HeadElement"/> instances.
/// </summary>
public static class HeadExtensions
{
    /// <summary>
    /// Creates a new &lt;head&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="HeadElement"/>.</returns>
    public static HeadElement Head(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;head&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="HeadElement"/>.</returns>
    public static HeadElement Head(string textContent) => new(textContent);
}
