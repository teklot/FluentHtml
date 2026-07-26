using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;h1&gt; element.
/// </summary>
public sealed class Heading1Element : Element<Heading1Element>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Heading1Element"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public Heading1Element(params Node[] children) : base(children) => SetTag("h1");

    /// <summary>
    /// Initializes a new instance of the <see cref="Heading1Element"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public Heading1Element(string textContent) : base(textContent) => SetTag("h1");
}

/// <summary>
/// Factory methods for creating <see cref="Heading1Element"/> instances.
/// </summary>
public static class Heading1Extensions
{
    /// <summary>
    /// Creates a new &lt;h1&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="Heading1Element"/>.</returns>
    public static Heading1Element H1(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;h1&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="Heading1Element"/>.</returns>
    public static Heading1Element H1(string textContent) => new(textContent);
}
