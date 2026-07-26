using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;tfoot&gt; element.
/// </summary>
public sealed class TfootElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TfootElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public TfootElement(params Node[] children) : base(children) => SetTag("tfoot");

    /// <summary>
    /// Initializes a new instance of the <see cref="TfootElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public TfootElement(string textContent) : base(textContent) => SetTag("tfoot");
}

/// <summary>
/// Factory methods for creating <see cref="TfootElement"/> instances.
/// </summary>
public static class TfootExtensions
{
    /// <summary>
    /// Creates a new &lt;tfoot&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="TfootElement"/>.</returns>
    public static TfootElement Tfoot(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;tfoot&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="TfootElement"/>.</returns>
    public static TfootElement Tfoot(string textContent) => new(textContent);
}
