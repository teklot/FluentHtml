using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;map&gt; element.
/// </summary>
public sealed class MapElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MapElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public MapElement(params Node[] children) : base(children) => SetTag("map");

    /// <summary>
    /// Initializes a new instance of the <see cref="MapElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public MapElement(string textContent) : base(textContent) => SetTag("map");

    /// <summary>
    /// Sets the name attribute for this element.
    /// </summary>
    /// <param name="value">The name value.</param>
    /// <returns>The current element for method chaining.</returns>
    public MapElement Name(string value) { Attributes.Set("name", value); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="MapElement"/> instances.
/// </summary>
public static class MapExtensions
{
    /// <summary>
    /// Creates a new &lt;map&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="MapElement"/>.</returns>
    public static MapElement Map(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;map&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="MapElement"/>.</returns>
    public static MapElement Map(string textContent) => new(textContent);
}
