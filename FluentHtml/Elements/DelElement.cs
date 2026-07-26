using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;del&gt; element.
/// </summary>
public sealed class DelElement : Element<DelElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DelElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public DelElement(params Node[] children) : base(children) => SetTag("del");

    /// <summary>
    /// Initializes a new instance of the <see cref="DelElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public DelElement(string textContent) : base(textContent) => SetTag("del");

    /// <summary>
    /// Sets the cite attribute for this element.
    /// </summary>
    /// <param name="value">The cite value.</param>
    /// <returns>The current element for method chaining.</returns>
    public DelElement Cite(string value) { Attributes.Set("cite", value); return this; }

    /// <summary>
    /// Sets the datetime attribute for this element.
    /// </summary>
    /// <param name="value">The datetime value.</param>
    /// <returns>The current element for method chaining.</returns>
    public DelElement DateTime(string value) { Attributes.Set("datetime", value); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="DelElement"/> instances.
/// </summary>
public static class DelExtensions
{
    /// <summary>
    /// Creates a new &lt;del&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="DelElement"/>.</returns>
    public static DelElement Del(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;del&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="DelElement"/>.</returns>
    public static DelElement Del(string textContent) => new(textContent);
}
