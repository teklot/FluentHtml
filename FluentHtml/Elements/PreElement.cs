using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;pre&gt; element.
/// </summary>
public sealed class PreElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PreElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public PreElement(params Node[] children) : base(children) => SetTag("pre");

    /// <summary>
    /// Initializes a new instance of the <see cref="PreElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public PreElement(string textContent) : base(textContent) => SetTag("pre");
}

/// <summary>
/// Factory methods for creating <see cref="PreElement"/> instances.
/// </summary>
public static class PreExtensions
{
    /// <summary>
    /// Creates a new &lt;pre&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="PreElement"/>.</returns>
    public static PreElement Pre(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;pre&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="PreElement"/>.</returns>
    public static PreElement Pre(string textContent) => new(textContent);
}
