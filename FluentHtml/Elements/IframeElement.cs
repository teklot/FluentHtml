using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;iframe&gt; element.
/// </summary>
public sealed class IframeElement : Element<IframeElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IframeElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public IframeElement(params Node[] children) : base(children) => SetTag("iframe");

    /// <summary>
    /// Initializes a new instance of the <see cref="IframeElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public IframeElement(string textContent) : base(textContent) => SetTag("iframe");

    /// <summary>
    /// Sets the src attribute for this element.
    /// </summary>
    /// <param name="value">The src value.</param>
    /// <returns>The current element for method chaining.</returns>
    public IframeElement Src(string value) { Attributes.Set("src", value); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="IframeElement"/> instances.
/// </summary>
public static class IframeExtensions
{
    /// <summary>
    /// Creates a new &lt;iframe&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="IframeElement"/>.</returns>
    public static IframeElement Iframe(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;iframe&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="IframeElement"/>.</returns>
    public static IframeElement Iframe(string textContent) => new(textContent);
}
