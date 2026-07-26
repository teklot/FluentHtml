using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;article&gt; element.
/// </summary>
public sealed class ArticleElement : Element<ArticleElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ArticleElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public ArticleElement(params Node[] children) : base(children) => SetTag("article");

    /// <summary>
    /// Initializes a new instance of the <see cref="ArticleElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public ArticleElement(string textContent) : base(textContent) => SetTag("article");
}

/// <summary>
/// Factory methods for creating <see cref="ArticleElement"/> instances.
/// </summary>
public static class ArticleExtensions
{
    /// <summary>
    /// Creates a new &lt;article&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="ArticleElement"/>.</returns>
    public static ArticleElement Article(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;article&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="ArticleElement"/>.</returns>
    public static ArticleElement Article(string textContent) => new(textContent);
}
