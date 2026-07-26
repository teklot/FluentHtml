using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;html&gt; element.
/// </summary>
public sealed class HtmlElement : Element<HtmlElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HtmlElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public HtmlElement(params Node[] children) : base(children) => SetTag("html");

    /// <summary>
    /// Initializes a new instance of the <see cref="HtmlElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public HtmlElement(string textContent) : base(textContent) => SetTag("html");
}

/// <summary>
/// Factory methods for creating <see cref="HtmlElement"/> instances.
/// </summary>
public static class HtmlExtensions
{
    /// <summary>
    /// Creates a new &lt;html&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="HtmlElement"/>.</returns>
    public static HtmlElement Html(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;html&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="HtmlElement"/>.</returns>
    public static HtmlElement Html(string textContent) => new(textContent);
}
