using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;optgroup&gt; element.
/// </summary>
public sealed class OptgroupElement : Element<OptgroupElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OptgroupElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public OptgroupElement(params Node[] children) : base(children) => SetTag("optgroup");

    /// <summary>
    /// Initializes a new instance of the <see cref="OptgroupElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public OptgroupElement(string textContent) : base(textContent) => SetTag("optgroup");

    /// <summary>
    /// Sets the label attribute for this element.
    /// </summary>
    /// <param name="value">The label value.</param>
    /// <returns>The current element for method chaining.</returns>
    public OptgroupElement Label(string value) { Attributes.Set("label", value); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="OptgroupElement"/> instances.
/// </summary>
public static class OptgroupExtensions
{
    /// <summary>
    /// Creates a new &lt;optgroup&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="OptgroupElement"/>.</returns>
    public static OptgroupElement Optgroup(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;optgroup&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="OptgroupElement"/>.</returns>
    public static OptgroupElement Optgroup(string textContent) => new(textContent);
}
