using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;label&gt; element.
/// </summary>
public sealed class LabelElement : Element<LabelElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LabelElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public LabelElement(params Node[] children) : base(children) => SetTag("label");

    /// <summary>
    /// Initializes a new instance of the <see cref="LabelElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public LabelElement(string textContent) : base(textContent) => SetTag("label");

    /// <summary>
    /// Sets the <c>for</c> attribute to link the label to another element by its ID.
    /// </summary>
    /// <param name="forId">The ID of the element this label describes.</param>
    /// <returns>The current element for method chaining.</returns>
    public LabelElement For(string forId) { Attributes.Set("for", forId); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="LabelElement"/> instances.
/// </summary>
public static class LabelExtensions
{
    /// <summary>
    /// Creates a new &lt;label&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="LabelElement"/>.</returns>
    public static LabelElement Label(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;label&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="LabelElement"/>.</returns>
    public static LabelElement Label(string textContent) => new(textContent);
}
