using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents a complete HTML document. Wraps a &lt;head&gt; and &lt;body&gt; element
/// inside an &lt;html&gt; element. The renderer auto-emits &lt;!DOCTYPE html&gt; when this
/// is the root node.
/// </summary>
/// <example>
/// Page(
///     Head(Title("My App")),
///     Body(H1("Hello World"))
/// )
/// </example>
public sealed class PageElement : Element<PageElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PageElement"/> class.
    /// </summary>
    /// <param name="head">The head element.</param>
    /// <param name="body">The body element.</param>
    public PageElement(HeadElement head, BodyElement body)
        : base(head, body) => SetTag("html");

    /// <summary>
    /// Sets the lang attribute for the html element.
    /// </summary>
    /// <param name="lang">The language code (e.g., "en", "fr").</param>
    /// <returns>The current page for method chaining.</returns>
    public PageElement Lang(string lang) { Attributes.Set("lang", lang); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="PageElement"/> instances.
/// </summary>
public static class PageExtensions
{
    /// <summary>
    /// Creates a complete HTML document from a head and body element.
    /// The renderer auto-emits &lt;!DOCTYPE html&gt; when this is the root node.
    /// </summary>
    /// <param name="head">The head element.</param>
    /// <param name="body">The body element.</param>
    /// <returns>A new <see cref="PageElement"/>.</returns>
    public static PageElement Page(HeadElement head, BodyElement body) => new(head, body);
}
