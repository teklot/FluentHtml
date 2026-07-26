using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;dfn&gt; element.
/// </summary>
public sealed class DfnElement : Element<DfnElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DfnElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public DfnElement(params Node[] children) : base(children) => SetTag("dfn");

    /// <summary>
    /// Initializes a new instance of the <see cref="DfnElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public DfnElement(string textContent) : base(textContent) => SetTag("dfn");
}

/// <summary>
/// Factory methods for creating <see cref="DfnElement"/> instances.
/// </summary>
public static class DfnExtensions
{
    /// <summary>
    /// Creates a new &lt;dfn&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="DfnElement"/>.</returns>
    public static DfnElement Dfn(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;dfn&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="DfnElement"/>.</returns>
    public static DfnElement Dfn(string textContent) => new(textContent);
}
