using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;h6&gt; element.
/// </summary>
public sealed class Heading6Element : Element<Heading6Element>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Heading6Element"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public Heading6Element(params Node[] children) : base(children) => SetTag("h6");

    /// <summary>
    /// Initializes a new instance of the <see cref="Heading6Element"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public Heading6Element(string textContent) : base(textContent) => SetTag("h6");
}

/// <summary>
/// Factory methods for creating <see cref="Heading6Element"/> instances.
/// </summary>
public static class Heading6Extensions
{
    /// <summary>
    /// Creates a new &lt;h6&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="Heading6Element"/>.</returns>
    public static Heading6Element H6(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;h6&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="Heading6Element"/>.</returns>
    public static Heading6Element H6(string textContent) => new(textContent);
}
