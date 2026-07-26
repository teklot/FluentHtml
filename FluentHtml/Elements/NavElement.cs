using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;nav&gt; element.
/// </summary>
public sealed class NavElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public NavElement(params Node[] children) : base(children) => SetTag("nav");

    /// <summary>
    /// Initializes a new instance of the <see cref="NavElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public NavElement(string textContent) : base(textContent) => SetTag("nav");
}

/// <summary>
/// Factory methods for creating <see cref="NavElement"/> instances.
/// </summary>
public static class NavExtensions
{
    /// <summary>
    /// Creates a new &lt;nav&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="NavElement"/>.</returns>
    public static NavElement Nav(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;nav&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="NavElement"/>.</returns>
    public static NavElement Nav(string textContent) => new(textContent);
}
