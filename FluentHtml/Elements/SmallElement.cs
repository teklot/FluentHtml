using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;small&gt; element.
/// </summary>
public sealed class SmallElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SmallElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public SmallElement(params Node[] children) : base(children) => SetTag("small");

    /// <summary>
    /// Initializes a new instance of the <see cref="SmallElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public SmallElement(string textContent) : base(textContent) => SetTag("small");
}

/// <summary>
/// Factory methods for creating <see cref="SmallElement"/> instances.
/// </summary>
public static class SmallExtensions
{
    /// <summary>
    /// Creates a new &lt;small&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="SmallElement"/>.</returns>
    public static SmallElement Small(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;small&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="SmallElement"/>.</returns>
    public static SmallElement Small(string textContent) => new(textContent);
}
