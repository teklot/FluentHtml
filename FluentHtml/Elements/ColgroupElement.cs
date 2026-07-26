using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;colgroup&gt; element.
/// </summary>
public sealed class ColgroupElement : Element<ColgroupElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ColgroupElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public ColgroupElement(params Node[] children) : base(children) => SetTag("colgroup");

    /// <summary>
    /// Initializes a new instance of the <see cref="ColgroupElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public ColgroupElement(string textContent) : base(textContent) => SetTag("colgroup");

    /// <summary>
    /// Sets the span attribute for this element.
    /// </summary>
    /// <param name="value">The span value.</param>
    /// <returns>The current element for method chaining.</returns>
    public ColgroupElement Span(int value) { Attributes.Set("span", value.ToString()); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="ColgroupElement"/> instances.
/// </summary>
public static class ColgroupExtensions
{
    /// <summary>
    /// Creates a new &lt;colgroup&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="ColgroupElement"/>.</returns>
    public static ColgroupElement Colgroup(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;colgroup&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="ColgroupElement"/>.</returns>
    public static ColgroupElement Colgroup(string textContent) => new(textContent);
}
