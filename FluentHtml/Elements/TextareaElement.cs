using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;textarea&gt; element. Use the Textarea() factory methods to create instances.
/// </summary>
public sealed class TextareaElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextareaElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public TextareaElement(params Node[] children) : base(children) => SetTag("textarea");

    /// <summary>
    /// Initializes a new instance of the <see cref="TextareaElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The textarea text content.</param>
    public TextareaElement(string textContent) : base(textContent) => SetTag("textarea");

    /// <summary>
    /// Sets the rows attribute for this textarea element.
    /// </summary>
    /// <param name="rows">The number of visible text lines.</param>
    /// <returns>The current textarea for method chaining.</returns>
    public TextareaElement Rows(int rows) { Attributes.Set("rows", rows.ToString()); return this; }

    /// <summary>
    /// Sets the cols attribute for this textarea element.
    /// </summary>
    /// <param name="cols">The visible width in average character widths.</param>
    /// <returns>The current textarea for method chaining.</returns>
    public TextareaElement Cols(int cols) { Attributes.Set("cols", cols.ToString()); return this; }

    /// <summary>
    /// Sets the name attribute for this textarea element.
    /// </summary>
    /// <param name="name">The textarea name used for form submission.</param>
    /// <returns>The current textarea for method chaining.</returns>
    public TextareaElement Name(string name) { Attributes.Set("name", name); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="TextareaElement"/> instances.
/// </summary>
public static class TextareaExtensions
{
    /// <summary>
    /// Creates a new &lt;textarea&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="TextareaElement"/>.</returns>
    public static TextareaElement Textarea(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;textarea&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The textarea text content.</param>
    /// <returns>A new <see cref="TextareaElement"/>.</returns>
    public static TextareaElement Textarea(string textContent) => new(textContent);
}