using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;dl&gt; element.
/// </summary>
public sealed class DlElement : Element<DlElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DlElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public DlElement(params Node[] children) : base(children) => SetTag("dl");

    /// <summary>
    /// Initializes a new instance of the <see cref="DlElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public DlElement(string textContent) : base(textContent) => SetTag("dl");
}

/// <summary>
/// Factory methods for creating <see cref="DlElement"/> instances.
/// </summary>
public static class DlExtensions
{
    /// <summary>
    /// Creates a new &lt;dl&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="DlElement"/>.</returns>
    public static DlElement Dl(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;dl&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="DlElement"/>.</returns>
    public static DlElement Dl(string textContent) => new(textContent);
}
