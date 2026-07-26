using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;main&gt; element.
/// </summary>
public sealed class MainElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public MainElement(params Node[] children) : base(children) => SetTag("main");

    /// <summary>
    /// Initializes a new instance of the <see cref="MainElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public MainElement(string textContent) : base(textContent) => SetTag("main");
}

/// <summary>
/// Factory methods for creating <see cref="MainElement"/> instances.
/// </summary>
public static class MainExtensions
{
    /// <summary>
    /// Creates a new &lt;main&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="MainElement"/>.</returns>
    public static MainElement Main(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;main&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="MainElement"/>.</returns>
    public static MainElement Main(string textContent) => new(textContent);
}
