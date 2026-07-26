using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;datalist&gt; element.
/// </summary>
public sealed class DatalistElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DatalistElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public DatalistElement(params Node[] children) : base(children) => SetTag("datalist");

    /// <summary>
    /// Initializes a new instance of the <see cref="DatalistElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public DatalistElement(string textContent) : base(textContent) => SetTag("datalist");
}

/// <summary>
/// Factory methods for creating <see cref="DatalistElement"/> instances.
/// </summary>
public static class DatalistExtensions
{
    /// <summary>
    /// Creates a new &lt;datalist&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="DatalistElement"/>.</returns>
    public static DatalistElement Datalist(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;datalist&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="DatalistElement"/>.</returns>
    public static DatalistElement Datalist(string textContent) => new(textContent);
}
