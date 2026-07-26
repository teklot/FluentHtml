using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;summary&gt; element.
/// </summary>
public sealed class SummaryElement : Element<SummaryElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SummaryElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public SummaryElement(params Node[] children) : base(children) => SetTag("summary");

    /// <summary>
    /// Initializes a new instance of the <see cref="SummaryElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public SummaryElement(string textContent) : base(textContent) => SetTag("summary");
}

/// <summary>
/// Factory methods for creating <see cref="SummaryElement"/> instances.
/// </summary>
public static class SummaryExtensions
{
    /// <summary>
    /// Creates a new &lt;summary&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="SummaryElement"/>.</returns>
    public static SummaryElement Summary(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;summary&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="SummaryElement"/>.</returns>
    public static SummaryElement Summary(string textContent) => new(textContent);
}
