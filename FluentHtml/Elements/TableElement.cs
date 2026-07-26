using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;table&gt; element.
/// </summary>
public sealed class TableElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TableElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public TableElement(params Node[] children) : base(children) => SetTag("table");

    /// <summary>
    /// Initializes a new instance of the <see cref="TableElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public TableElement(string textContent) : base(textContent) => SetTag("table");
}

/// <summary>
/// Factory methods for creating <see cref="TableElement"/> instances.
/// </summary>
public static class TableExtensions
{
    /// <summary>
    /// Creates a new &lt;table&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="TableElement"/>.</returns>
    public static TableElement Table(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;table&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="TableElement"/>.</returns>
    public static TableElement Table(string textContent) => new(textContent);
}
