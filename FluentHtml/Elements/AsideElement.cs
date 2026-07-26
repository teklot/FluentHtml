using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;aside&gt; element.
/// </summary>
public sealed class AsideElement : Element<AsideElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AsideElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public AsideElement(params Node[] children) : base(children) => SetTag("aside");

    /// <summary>
    /// Initializes a new instance of the <see cref="AsideElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public AsideElement(string textContent) : base(textContent) => SetTag("aside");
}

/// <summary>
/// Factory methods for creating <see cref="AsideElement"/> instances.
/// </summary>
public static class AsideExtensions
{
    /// <summary>
    /// Creates a new &lt;aside&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="AsideElement"/>.</returns>
    public static AsideElement Aside(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;aside&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="AsideElement"/>.</returns>
    public static AsideElement Aside(string textContent) => new(textContent);
}
