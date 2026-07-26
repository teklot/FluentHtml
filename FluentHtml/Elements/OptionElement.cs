using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;option&gt; element.
/// </summary>
public sealed class OptionElement : Element<OptionElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OptionElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public OptionElement(params Node[] children) : base(children) => SetTag("option");

    /// <summary>
    /// Initializes a new instance of the <see cref="OptionElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public OptionElement(string textContent) : base(textContent) => SetTag("option");

    /// <summary>
    /// Sets the value attribute for this element.
    /// </summary>
    /// <param name="value">The value value.</param>
    /// <returns>The current element for method chaining.</returns>
    public OptionElement Value(string value) { Attributes.Set("value", value); return this; }

    /// <summary>
    /// Sets the selected attribute on this element.
    /// </summary>
    /// <returns>The current element for method chaining.</returns>
    public OptionElement Selected() { Attributes.SetBool("selected"); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="OptionElement"/> instances.
/// </summary>
public static class OptionExtensions
{
    /// <summary>
    /// Creates a new &lt;option&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="OptionElement"/>.</returns>
    public static OptionElement Option(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;option&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="OptionElement"/>.</returns>
    public static OptionElement Option(string textContent) => new(textContent);
}
