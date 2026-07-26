using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;h4&gt; element.
/// </summary>
public sealed class Heading4Element : Element<Heading4Element>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Heading4Element"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public Heading4Element(params Node[] children) : base(children) => SetTag("h4");

    /// <summary>
    /// Initializes a new instance of the <see cref="Heading4Element"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public Heading4Element(string textContent) : base(textContent) => SetTag("h4");
}

/// <summary>
/// Factory methods for creating <see cref="Heading4Element"/> instances.
/// </summary>
public static class Heading4Extensions
{
    /// <summary>
    /// Creates a new &lt;h4&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="Heading4Element"/>.</returns>
    public static Heading4Element H4(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;h4&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="Heading4Element"/>.</returns>
    public static Heading4Element H4(string textContent) => new(textContent);
}
