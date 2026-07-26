using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;fieldset&gt; element.
/// </summary>
public sealed class FieldsetElement : Element<FieldsetElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FieldsetElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public FieldsetElement(params Node[] children) : base(children) => SetTag("fieldset");

    /// <summary>
    /// Initializes a new instance of the <see cref="FieldsetElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public FieldsetElement(string textContent) : base(textContent) => SetTag("fieldset");
}

/// <summary>
/// Factory methods for creating <see cref="FieldsetElement"/> instances.
/// </summary>
public static class FieldsetExtensions
{
    /// <summary>
    /// Creates a new &lt;fieldset&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="FieldsetElement"/>.</returns>
    public static FieldsetElement Fieldset(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;fieldset&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="FieldsetElement"/>.</returns>
    public static FieldsetElement Fieldset(string textContent) => new(textContent);
}
