using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;li&gt; element.
/// </summary>
public sealed class LiElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LiElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public LiElement(params Node[] children) : base(children) => SetTag("li");

    /// <summary>
    /// Initializes a new instance of the <see cref="LiElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public LiElement(string textContent) : base(textContent) => SetTag("li");
}

/// <summary>
/// Factory methods for creating <see cref="LiElement"/> instances.
/// </summary>
public static class LiExtensions
{
    /// <summary>
    /// Creates a new &lt;li&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="LiElement"/>.</returns>
    public static LiElement Li(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;li&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="LiElement"/>.</returns>
    public static LiElement Li(string textContent) => new(textContent);
}
