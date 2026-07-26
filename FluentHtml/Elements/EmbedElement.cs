using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;embed&gt; element.
/// </summary>
public sealed class EmbedElement : Element<EmbedElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmbedElement"/> class. The element is self-closing.
    /// </summary>
    public EmbedElement() => SetTag("embed", selfClosing: true);

    /// <summary>
    /// Sets the src attribute for this element.
    /// </summary>
    /// <param name="value">The src value.</param>
    /// <returns>The current element for method chaining.</returns>
    public EmbedElement Src(string value) { Attributes.Set("src", value); return this; }

    /// <summary>
    /// Sets the type attribute for this element.
    /// </summary>
    /// <param name="value">The type value.</param>
    /// <returns>The current element for method chaining.</returns>
    public EmbedElement Type(string value) { Attributes.Set("type", value); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="EmbedElement"/> instances.
/// </summary>
public static class EmbedExtensions
{
    /// <summary>
    /// Creates a new &lt;embed&gt; element.
    /// </summary>
    /// <returns>A new <see cref="EmbedElement"/>.</returns>
    public static EmbedElement Embed() => new();
}
