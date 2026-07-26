using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;canvas&gt; element.
/// </summary>
public sealed class CanvasElement : Element<CanvasElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CanvasElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public CanvasElement(params Node[] children) : base(children) => SetTag("canvas");

    /// <summary>
    /// Initializes a new instance of the <see cref="CanvasElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public CanvasElement(string textContent) : base(textContent) => SetTag("canvas");

    /// <summary>
    /// Sets the width attribute for this element.
    /// </summary>
    /// <param name="value">The width value.</param>
    /// <returns>The current element for method chaining.</returns>
    public CanvasElement Width(int value) { Attributes.Set("width", value.ToString()); return this; }

    /// <summary>
    /// Sets the height attribute for this element.
    /// </summary>
    /// <param name="value">The height value.</param>
    /// <returns>The current element for method chaining.</returns>
    public CanvasElement Height(int value) { Attributes.Set("height", value.ToString()); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="CanvasElement"/> instances.
/// </summary>
public static class CanvasExtensions
{
    /// <summary>
    /// Creates a new &lt;canvas&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="CanvasElement"/>.</returns>
    public static CanvasElement Canvas(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;canvas&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="CanvasElement"/>.</returns>
    public static CanvasElement Canvas(string textContent) => new(textContent);
}
