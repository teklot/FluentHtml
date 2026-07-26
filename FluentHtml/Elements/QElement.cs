using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;q&gt; element.
/// </summary>
public sealed class QElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="QElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public QElement(params Node[] children) : base(children) => SetTag("q");

    /// <summary>
    /// Initializes a new instance of the <see cref="QElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public QElement(string textContent) : base(textContent) => SetTag("q");

    /// <summary>
    /// Sets the cite attribute for this element.
    /// </summary>
    /// <param name="value">The cite value.</param>
    /// <returns>The current element for method chaining.</returns>
    public QElement Cite(string value) { Attributes.Set("cite", value); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="QElement"/> instances.
/// </summary>
public static class QExtensions
{
    /// <summary>
    /// Creates a new &lt;q&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="QElement"/>.</returns>
    public static QElement Q(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;q&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="QElement"/>.</returns>
    public static QElement Q(string textContent) => new(textContent);
}
