using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;section&gt; element.
/// </summary>
public sealed class SectionElement : Element<SectionElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SectionElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public SectionElement(params Node[] children) : base(children) => SetTag("section");

    /// <summary>
    /// Initializes a new instance of the <see cref="SectionElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public SectionElement(string textContent) : base(textContent) => SetTag("section");
}

/// <summary>
/// Factory methods for creating <see cref="SectionElement"/> instances.
/// </summary>
public static class SectionExtensions
{
    /// <summary>
    /// Creates a new &lt;section&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="SectionElement"/>.</returns>
    public static SectionElement Section(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;section&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="SectionElement"/>.</returns>
    public static SectionElement Section(string textContent) => new(textContent);
}
