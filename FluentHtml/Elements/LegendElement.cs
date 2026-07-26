using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;legend&gt; element.
/// </summary>
public sealed class LegendElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LegendElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public LegendElement(params Node[] children) : base(children) => SetTag("legend");

    /// <summary>
    /// Initializes a new instance of the <see cref="LegendElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public LegendElement(string textContent) : base(textContent) => SetTag("legend");
}

/// <summary>
/// Factory methods for creating <see cref="LegendElement"/> instances.
/// </summary>
public static class LegendExtensions
{
    /// <summary>
    /// Creates a new &lt;legend&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="LegendElement"/>.</returns>
    public static LegendElement Legend(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;legend&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="LegendElement"/>.</returns>
    public static LegendElement Legend(string textContent) => new(textContent);
}
