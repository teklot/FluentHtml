using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;audio&gt; element.
/// </summary>
public sealed class AudioElement : Element<AudioElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AudioElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public AudioElement(params Node[] children) : base(children) => SetTag("audio");

    /// <summary>
    /// Initializes a new instance of the <see cref="AudioElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public AudioElement(string textContent) : base(textContent) => SetTag("audio");

    /// <summary>
    /// Sets the src attribute for this element.
    /// </summary>
    /// <param name="value">The src value.</param>
    /// <returns>The current element for method chaining.</returns>
    public AudioElement Src(string value) { Attributes.Set("src", value); return this; }

    /// <summary>
    /// Sets the controls attribute on this element.
    /// </summary>
    /// <returns>The current element for method chaining.</returns>
    public AudioElement Controls() { Attributes.SetBool("controls"); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="AudioElement"/> instances.
/// </summary>
public static class AudioExtensions
{
    /// <summary>
    /// Creates a new &lt;audio&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="AudioElement"/>.</returns>
    public static AudioElement Audio(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;audio&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="AudioElement"/>.</returns>
    public static AudioElement Audio(string textContent) => new(textContent);
}
