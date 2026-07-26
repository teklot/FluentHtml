using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;th&gt; element.
/// </summary>
public sealed class ThElement : Element<ThElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ThElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public ThElement(params Node[] children) : base(children) => SetTag("th");

    /// <summary>
    /// Initializes a new instance of the <see cref="ThElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public ThElement(string textContent) : base(textContent) => SetTag("th");

    /// <summary>
    /// Sets the colspan attribute for this element.
    /// </summary>
    /// <param name="value">The colspan value.</param>
    /// <returns>The current element for method chaining.</returns>
    public ThElement ColSpan(int value) { Attributes.Set("colspan", value.ToString()); return this; }

    /// <summary>
    /// Sets the rowspan attribute for this element.
    /// </summary>
    /// <param name="value">The rowspan value.</param>
    /// <returns>The current element for method chaining.</returns>
    public ThElement RowSpan(int value) { Attributes.Set("rowspan", value.ToString()); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="ThElement"/> instances.
/// </summary>
public static class ThExtensions
{
    /// <summary>
    /// Creates a new &lt;th&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="ThElement"/>.</returns>
    public static ThElement Th(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;th&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="ThElement"/>.</returns>
    public static ThElement Th(string textContent) => new(textContent);
}
