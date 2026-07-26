using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;object&gt; element.
/// </summary>
public sealed class ObjectElement : Element<ObjectElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public ObjectElement(params Node[] children) : base(children) => SetTag("object");

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public ObjectElement(string textContent) : base(textContent) => SetTag("object");

    /// <summary>
    /// Sets the data attribute for this element.
    /// </summary>
    /// <param name="value">The data value.</param>
    /// <returns>The current element for method chaining.</returns>
    public ObjectElement Data(string value) { Attributes.Set("data", value); return this; }

    /// <summary>
    /// Sets the type attribute for this element.
    /// </summary>
    /// <param name="value">The type value.</param>
    /// <returns>The current element for method chaining.</returns>
    public ObjectElement Type(string value) { Attributes.Set("type", value); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="ObjectElement"/> instances.
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Creates a new &lt;object&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="ObjectElement"/>.</returns>
    public static ObjectElement Object(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;object&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="ObjectElement"/>.</returns>
    public static ObjectElement Object(string textContent) => new(textContent);
}
