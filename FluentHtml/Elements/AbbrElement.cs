using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;abbr&gt; element.
/// </summary>
public sealed class AbbrElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AbbrElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public AbbrElement(params Node[] children) : base(children) => SetTag("abbr");

    /// <summary>
    /// Initializes a new instance of the <see cref="AbbrElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public AbbrElement(string textContent) : base(textContent) => SetTag("abbr");
}

/// <summary>
/// Factory methods for creating <see cref="AbbrElement"/> instances.
/// </summary>
public static class AbbrExtensions
{
    /// <summary>
    /// Creates a new &lt;abbr&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="AbbrElement"/>.</returns>
    public static AbbrElement Abbr(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;abbr&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="AbbrElement"/>.</returns>
    public static AbbrElement Abbr(string textContent) => new(textContent);
}
