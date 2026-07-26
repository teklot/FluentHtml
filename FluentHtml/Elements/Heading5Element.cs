using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;h5&gt; element.
/// </summary>
public sealed class Heading5Element : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Heading5Element"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public Heading5Element(params Node[] children) : base(children) => SetTag("h5");

    /// <summary>
    /// Initializes a new instance of the <see cref="Heading5Element"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public Heading5Element(string textContent) : base(textContent) => SetTag("h5");
}

/// <summary>
/// Factory methods for creating <see cref="Heading5Element"/> instances.
/// </summary>
public static class Heading5Extensions
{
    /// <summary>
    /// Creates a new &lt;h5&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="Heading5Element"/>.</returns>
    public static Heading5Element H5(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;h5&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="Heading5Element"/>.</returns>
    public static Heading5Element H5(string textContent) => new(textContent);
}
