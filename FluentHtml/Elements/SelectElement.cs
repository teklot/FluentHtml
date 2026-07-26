using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;select&gt; element. Use the Select() factory methods to create instances.
/// </summary>
public sealed class SelectElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SelectElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes (typically &lt;option&gt; elements).</param>
    public SelectElement(params Node[] children) : base(children) => SetTag("select");

    /// <summary>
    /// Initializes a new instance of the <see cref="SelectElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The select text content.</param>
    public SelectElement(string textContent) : base(textContent) => SetTag("select");

    /// <summary>
    /// Sets the name attribute for this select element.
    /// </summary>
    /// <param name="name">The select name used for form submission.</param>
    /// <returns>The current select for method chaining.</returns>
    public SelectElement Name(string name) { Attributes.Set("name", name); return this; }

    /// <inheritdoc/>
    public new SelectElement Id(string id) { base.Id(id); return this; }
    /// <inheritdoc/>
    public new SelectElement Class(string className) { base.Class(className); return this; }
    /// <inheritdoc/>
    public new SelectElement Disabled() { base.Disabled(); return this; }
    /// <inheritdoc/>
    public new SelectElement Required() { base.Required(); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="SelectElement"/> instances.
/// </summary>
public static class SelectExtensions
{
    /// <summary>
    /// Creates a new &lt;select&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes (typically &lt;option&gt; elements).</param>
    /// <returns>A new <see cref="SelectElement"/>.</returns>
    public static SelectElement Select(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;select&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The select text content.</param>
    /// <returns>A new <see cref="SelectElement"/>.</returns>
    public static SelectElement Select(string textContent) => new(textContent);
}
