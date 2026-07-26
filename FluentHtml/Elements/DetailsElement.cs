using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;details&gt; element.
/// </summary>
public sealed class DetailsElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DetailsElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public DetailsElement(params Node[] children) : base(children) => SetTag("details");

    /// <summary>
    /// Initializes a new instance of the <see cref="DetailsElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public DetailsElement(string textContent) : base(textContent) => SetTag("details");
}

/// <summary>
/// Factory methods for creating <see cref="DetailsElement"/> instances.
/// </summary>
public static class DetailsExtensions
{
    /// <summary>
    /// Creates a new &lt;details&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="DetailsElement"/>.</returns>
    public static DetailsElement Details(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;details&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="DetailsElement"/>.</returns>
    public static DetailsElement Details(string textContent) => new(textContent);
}
