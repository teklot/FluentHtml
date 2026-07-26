using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;td&gt; element.
/// </summary>
public sealed class TdElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TdElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public TdElement(params Node[] children) : base(children) => SetTag("td");

    /// <summary>
    /// Initializes a new instance of the <see cref="TdElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public TdElement(string textContent) : base(textContent) => SetTag("td");

    /// <summary>
    /// Sets the colspan attribute for this element.
    /// </summary>
    /// <param name="value">The colspan value.</param>
    /// <returns>The current element for method chaining.</returns>
    public TdElement ColSpan(int value) { Attributes.Set("colspan", value.ToString()); return this; }

    /// <summary>
    /// Sets the rowspan attribute for this element.
    /// </summary>
    /// <param name="value">The rowspan value.</param>
    /// <returns>The current element for method chaining.</returns>
    public TdElement RowSpan(int value) { Attributes.Set("rowspan", value.ToString()); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="TdElement"/> instances.
/// </summary>
public static class TdExtensions
{
    /// <summary>
    /// Creates a new &lt;td&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="TdElement"/>.</returns>
    public static TdElement Td(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;td&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="TdElement"/>.</returns>
    public static TdElement Td(string textContent) => new(textContent);
}
