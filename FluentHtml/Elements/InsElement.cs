using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;ins&gt; element.
/// </summary>
public sealed class InsElement : Element<InsElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InsElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public InsElement(params Node[] children) : base(children) => SetTag("ins");

    /// <summary>
    /// Initializes a new instance of the <see cref="InsElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public InsElement(string textContent) : base(textContent) => SetTag("ins");

    /// <summary>
    /// Sets the cite attribute for this element.
    /// </summary>
    /// <param name="value">The cite value.</param>
    /// <returns>The current element for method chaining.</returns>
    public InsElement Cite(string value) { Attributes.Set("cite", value); return this; }

    /// <summary>
    /// Sets the datetime attribute for this element.
    /// </summary>
    /// <param name="value">The datetime value.</param>
    /// <returns>The current element for method chaining.</returns>
    public InsElement DateTime(string value) { Attributes.Set("datetime", value); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="InsElement"/> instances.
/// </summary>
public static class InsExtensions
{
    /// <summary>
    /// Creates a new &lt;ins&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="InsElement"/>.</returns>
    public static InsElement Ins(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;ins&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="InsElement"/>.</returns>
    public static InsElement Ins(string textContent) => new(textContent);
}
