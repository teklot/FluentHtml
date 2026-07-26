using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;div&gt; element.
/// </summary>
public sealed class DivElement : Element<DivElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DivElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public DivElement(params Node[] children) : base(children) => SetTag("div");

    /// <summary>
    /// Initializes a new instance of the <see cref="DivElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public DivElement(string textContent) : base(textContent) => SetTag("div");
}

/// <summary>
/// Factory methods for creating <see cref="DivElement"/> instances.
/// </summary>
public static class DivExtensions
{
    /// <summary>
    /// Creates a new &lt;div&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="DivElement"/>.</returns>
    public static DivElement Div(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;div&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="DivElement"/>.</returns>
    public static DivElement Div(string textContent) => new(textContent);
}
