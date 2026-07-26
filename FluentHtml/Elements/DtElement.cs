using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;dt&gt; element.
/// </summary>
public sealed class DtElement : Element<DtElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public DtElement(params Node[] children) : base(children) => SetTag("dt");

    /// <summary>
    /// Initializes a new instance of the <see cref="DtElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public DtElement(string textContent) : base(textContent) => SetTag("dt");
}

/// <summary>
/// Factory methods for creating <see cref="DtElement"/> instances.
/// </summary>
public static class DtExtensions
{
    /// <summary>
    /// Creates a new &lt;dt&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="DtElement"/>.</returns>
    public static DtElement Dt(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;dt&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="DtElement"/>.</returns>
    public static DtElement Dt(string textContent) => new(textContent);
}
