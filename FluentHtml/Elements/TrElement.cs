using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;tr&gt; element.
/// </summary>
public sealed class TrElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TrElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public TrElement(params Node[] children) : base(children) => SetTag("tr");

    /// <summary>
    /// Initializes a new instance of the <see cref="TrElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public TrElement(string textContent) : base(textContent) => SetTag("tr");
}

/// <summary>
/// Factory methods for creating <see cref="TrElement"/> instances.
/// </summary>
public static class TrExtensions
{
    /// <summary>
    /// Creates a new &lt;tr&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="TrElement"/>.</returns>
    public static TrElement Tr(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;tr&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="TrElement"/>.</returns>
    public static TrElement Tr(string textContent) => new(textContent);
}
