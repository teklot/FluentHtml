using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;title&gt; element.
/// </summary>
public sealed class TitleElement : Element<TitleElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TitleElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public TitleElement(params Node[] children) : base(children) => SetTag("title");

    /// <summary>
    /// Initializes a new instance of the <see cref="TitleElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public TitleElement(string textContent) : base(textContent) => SetTag("title");
}

/// <summary>
/// Factory methods for creating <see cref="TitleElement"/> instances.
/// </summary>
public static class TitleExtensions
{
    /// <summary>
    /// Creates a new &lt;title&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="TitleElement"/>.</returns>
    public static TitleElement Title(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;title&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="TitleElement"/>.</returns>
    public static TitleElement Title(string textContent) => new(textContent);
}
