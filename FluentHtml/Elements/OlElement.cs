using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;ol&gt; element.
/// </summary>
public sealed class OlElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OlElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public OlElement(params Node[] children) : base(children) => SetTag("ol");

    /// <summary>
    /// Initializes a new instance of the <see cref="OlElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public OlElement(string textContent) : base(textContent) => SetTag("ol");
}

/// <summary>
/// Factory methods for creating <see cref="OlElement"/> instances.
/// </summary>
public static class OlExtensions
{
    /// <summary>
    /// Creates a new &lt;ol&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="OlElement"/>.</returns>
    public static OlElement Ol(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;ol&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="OlElement"/>.</returns>
    public static OlElement Ol(string textContent) => new(textContent);
}
