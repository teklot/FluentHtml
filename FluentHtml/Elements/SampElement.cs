using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;samp&gt; element.
/// </summary>
public sealed class SampElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SampElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public SampElement(params Node[] children) : base(children) => SetTag("samp");

    /// <summary>
    /// Initializes a new instance of the <see cref="SampElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public SampElement(string textContent) : base(textContent) => SetTag("samp");
}

/// <summary>
/// Factory methods for creating <see cref="SampElement"/> instances.
/// </summary>
public static class SampExtensions
{
    /// <summary>
    /// Creates a new &lt;samp&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="SampElement"/>.</returns>
    public static SampElement Samp(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;samp&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="SampElement"/>.</returns>
    public static SampElement Samp(string textContent) => new(textContent);
}
