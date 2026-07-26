using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;video&gt; element.
/// </summary>
public sealed class VideoElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VideoElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public VideoElement(params Node[] children) : base(children) => SetTag("video");

    /// <summary>
    /// Initializes a new instance of the <see cref="VideoElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public VideoElement(string textContent) : base(textContent) => SetTag("video");

    /// <summary>
    /// Sets the src attribute for this element.
    /// </summary>
    /// <param name="value">The src value.</param>
    /// <returns>The current element for method chaining.</returns>
    public VideoElement Src(string value) { Attributes.Set("src", value); return this; }

    /// <summary>
    /// Sets the controls attribute on this element.
    /// </summary>
    /// <returns>The current element for method chaining.</returns>
    public VideoElement Controls() { Attributes.SetBool("controls"); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="VideoElement"/> instances.
/// </summary>
public static class VideoExtensions
{
    /// <summary>
    /// Creates a new &lt;video&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="VideoElement"/>.</returns>
    public static VideoElement Video(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;video&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="VideoElement"/>.</returns>
    public static VideoElement Video(string textContent) => new(textContent);
}
