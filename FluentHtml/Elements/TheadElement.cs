using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;thead&gt; element.
/// </summary>
public sealed class TheadElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TheadElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public TheadElement(params Node[] children) : base(children) => SetTag("thead");

    /// <summary>
    /// Initializes a new instance of the <see cref="TheadElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public TheadElement(string textContent) : base(textContent) => SetTag("thead");
}

/// <summary>
/// Factory methods for creating <see cref="TheadElement"/> instances.
/// </summary>
public static class TheadExtensions
{
    /// <summary>
    /// Creates a new &lt;thead&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="TheadElement"/>.</returns>
    public static TheadElement Thead(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;thead&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="TheadElement"/>.</returns>
    public static TheadElement Thead(string textContent) => new(textContent);
}
