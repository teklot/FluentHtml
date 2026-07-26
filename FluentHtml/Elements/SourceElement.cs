using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;source&gt; element.
/// </summary>
public sealed class SourceElement : Element<SourceElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SourceElement"/> class. The element is self-closing.
    /// </summary>
    public SourceElement() => SetTag("source", selfClosing: true);

    /// <summary>
    /// Sets the src attribute for this element.
    /// </summary>
    /// <param name="value">The src value.</param>
    /// <returns>The current element for method chaining.</returns>
    public SourceElement Src(string value) { Attributes.Set("src", value); return this; }

    /// <summary>
    /// Sets the type attribute for this element.
    /// </summary>
    /// <param name="value">The type value.</param>
    /// <returns>The current element for method chaining.</returns>
    public SourceElement Type(string value) { Attributes.Set("type", value); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="SourceElement"/> instances.
/// </summary>
public static class SourceExtensions
{
    /// <summary>
    /// Creates a new &lt;source&gt; element.
    /// </summary>
    /// <returns>A new <see cref="SourceElement"/>.</returns>
    public static SourceElement Source() => new();
}
