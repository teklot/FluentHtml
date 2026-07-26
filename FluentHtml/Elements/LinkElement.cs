using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;link&gt; element.
/// </summary>
public sealed class LinkElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LinkElement"/> class. The element is self-closing.
    /// </summary>
    public LinkElement() => SetTag("link", selfClosing: true);

    /// <summary>
    /// Sets the rel attribute for this element.
    /// </summary>
    /// <param name="value">The rel value.</param>
    /// <returns>The current element for method chaining.</returns>
    public LinkElement Rel(string value) { Attributes.Set("rel", value); return this; }

    /// <summary>
    /// Sets the href attribute for this element.
    /// </summary>
    /// <param name="value">The href value.</param>
    /// <returns>The current element for method chaining.</returns>
    public LinkElement Href(string value) { Attributes.Set("href", value); return this; }

    /// <summary>
    /// Sets the type attribute for this element.
    /// </summary>
    /// <param name="value">The type value.</param>
    /// <returns>The current element for method chaining.</returns>
    public LinkElement Type(string value) { Attributes.Set("type", value); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="LinkElement"/> instances.
/// </summary>
public static class LinkExtensions
{
    /// <summary>
    /// Creates a new &lt;link&gt; element.
    /// </summary>
    /// <returns>A new <see cref="LinkElement"/>.</returns>
    public static LinkElement Link() => new();
}
