using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;dd&gt; element.
/// </summary>
public sealed class DdElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DdElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public DdElement(params Node[] children) : base(children) => SetTag("dd");

    /// <summary>
    /// Initializes a new instance of the <see cref="DdElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public DdElement(string textContent) : base(textContent) => SetTag("dd");
}

/// <summary>
/// Factory methods for creating <see cref="DdElement"/> instances.
/// </summary>
public static class DdExtensions
{
    /// <summary>
    /// Creates a new &lt;dd&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="DdElement"/>.</returns>
    public static DdElement Dd(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;dd&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="DdElement"/>.</returns>
    public static DdElement Dd(string textContent) => new(textContent);
}
