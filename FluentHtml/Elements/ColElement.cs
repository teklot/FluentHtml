using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;col&gt; element.
/// </summary>
public sealed class ColElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ColElement"/> class. The element is self-closing.
    /// </summary>
    public ColElement() => SetTag("col", selfClosing: true);

    /// <summary>
    /// Sets the span attribute for this element.
    /// </summary>
    /// <param name="value">The span value.</param>
    /// <returns>The current element for method chaining.</returns>
    public ColElement Span(int value) { Attributes.Set("span", value.ToString()); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="ColElement"/> instances.
/// </summary>
public static class ColExtensions
{
    /// <summary>
    /// Creates a new &lt;col&gt; element.
    /// </summary>
    /// <returns>A new <see cref="ColElement"/>.</returns>
    public static ColElement Col() => new();
}
