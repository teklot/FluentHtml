using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;ul&gt; element.
/// </summary>
public sealed class UlElement : Element<UlElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UlElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public UlElement(params Node[] children) : base(children) => SetTag("ul");

    /// <summary>
    /// Initializes a new instance of the <see cref="UlElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public UlElement(string textContent) : base(textContent) => SetTag("ul");
}

/// <summary>
/// Factory methods for creating <see cref="UlElement"/> instances.
/// </summary>
public static class UlExtensions
{
    /// <summary>
    /// Creates a new &lt;ul&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="UlElement"/>.</returns>
    public static UlElement Ul(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;ul&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="UlElement"/>.</returns>
    public static UlElement Ul(string textContent) => new(textContent);
}
