using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;span&gt; element.
/// </summary>
public sealed class SpanElement : Element<SpanElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpanElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public SpanElement(params Node[] children) : base(children) => SetTag("span");

    /// <summary>
    /// Initializes a new instance of the <see cref="SpanElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public SpanElement(string textContent) : base(textContent) => SetTag("span");
}

/// <summary>
/// Factory methods for creating <see cref="SpanElement"/> instances.
/// </summary>
public static class SpanExtensions
{
    /// <summary>
    /// Creates a new &lt;span&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="SpanElement"/>.</returns>
    public static SpanElement Span(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;span&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="SpanElement"/>.</returns>
    public static SpanElement Span(string textContent) => new(textContent);
}
