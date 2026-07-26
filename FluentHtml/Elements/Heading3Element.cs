using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;h3&gt; element.
/// </summary>
public sealed class Heading3Element : Element<Heading3Element>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Heading3Element"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public Heading3Element(params Node[] children) : base(children) => SetTag("h3");

    /// <summary>
    /// Initializes a new instance of the <see cref="Heading3Element"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public Heading3Element(string textContent) : base(textContent) => SetTag("h3");
}

/// <summary>
/// Factory methods for creating <see cref="Heading3Element"/> instances.
/// </summary>
public static class Heading3Extensions
{
    /// <summary>
    /// Creates a new &lt;h3&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="Heading3Element"/>.</returns>
    public static Heading3Element H3(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;h3&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="Heading3Element"/>.</returns>
    public static Heading3Element H3(string textContent) => new(textContent);
}
