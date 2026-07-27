using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;meta&gt; element.
/// </summary>
public sealed class MetaElement : Element<MetaElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MetaElement"/> class. The element is self-closing.
    /// </summary>
    public MetaElement() => SetTag("meta", selfClosing: true);

    /// <summary>
    /// Sets the name attribute for this element.
    /// </summary>
    /// <param name="value">The name value.</param>
    /// <returns>The current element for method chaining.</returns>
    public MetaElement Name(string value)
    {
        Ensure.NotEmpty(value, nameof(value));
        Attributes.Set("name", value);
        return this;
    }

    /// <summary>
    /// Sets the content attribute for this element.
    /// </summary>
    /// <param name="value">The content value.</param>
    /// <returns>The current element for method chaining.</returns>
    public MetaElement Content(string value)
    {
        Ensure.NotNull(value, nameof(value));
        Attributes.Set("content", value);
        return this;
    }

    /// <summary>
    /// Sets the charset attribute for this element.
    /// </summary>
    /// <param name="value">The charset value.</param>
    /// <returns>The current element for method chaining.</returns>
    public MetaElement Charset(string value)
    {
        Ensure.NotEmpty(value, nameof(value));
        Attributes.Set("charset", value);
        return this;
    }
}

/// <summary>
/// Factory methods for creating <see cref="MetaElement"/> instances.
/// </summary>
public static class MetaExtensions
{
    /// <summary>
    /// Creates a new &lt;meta&gt; element.
    /// </summary>
    /// <returns>A new <see cref="MetaElement"/>.</returns>
    public static MetaElement Meta() => new();
}
