using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;style&gt; element.
/// </summary>
public sealed class StyleElement : Element<StyleElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StyleElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public StyleElement(params Node[] children) : base(children) => SetTag("style");

    /// <summary>
    /// Initializes a new instance of the <see cref="StyleElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public StyleElement(string textContent) : base(textContent) => SetTag("style");
}

/// <summary>
/// Factory methods for creating <see cref="StyleElement"/> instances.
/// </summary>
public static class StyleExtensions
{
    /// <summary>
    /// Creates a new &lt;style&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="StyleElement"/>.</returns>
    public static StyleElement Style(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;style&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="StyleElement"/>.</returns>
    public static StyleElement Style(string textContent) => new(textContent);
}
