using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;sub&gt; element.
/// </summary>
public sealed class SubElement : Element<SubElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SubElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public SubElement(params Node[] children) : base(children) => SetTag("sub");

    /// <summary>
    /// Initializes a new instance of the <see cref="SubElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public SubElement(string textContent) : base(textContent) => SetTag("sub");
}

/// <summary>
/// Factory methods for creating <see cref="SubElement"/> instances.
/// </summary>
public static class SubExtensions
{
    /// <summary>
    /// Creates a new &lt;sub&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="SubElement"/>.</returns>
    public static SubElement Sub(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;sub&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="SubElement"/>.</returns>
    public static SubElement Sub(string textContent) => new(textContent);
}
