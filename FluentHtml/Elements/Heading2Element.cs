using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;h2&gt; element.
/// </summary>
public sealed class Heading2Element : Element<Heading2Element>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Heading2Element"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public Heading2Element(params Node[] children) : base(children) => SetTag("h2");

    /// <summary>
    /// Initializes a new instance of the <see cref="Heading2Element"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public Heading2Element(string textContent) : base(textContent) => SetTag("h2");
}

/// <summary>
/// Factory methods for creating <see cref="Heading2Element"/> instances.
/// </summary>
public static class Heading2Extensions
{
    /// <summary>
    /// Creates a new &lt;h2&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="Heading2Element"/>.</returns>
    public static Heading2Element H2(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;h2&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="Heading2Element"/>.</returns>
    public static Heading2Element H2(string textContent) => new(textContent);
}
