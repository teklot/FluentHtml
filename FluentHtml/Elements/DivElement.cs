using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;div&gt; element.
/// </summary>
public sealed class DivElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DivElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public DivElement(params Node[] children) : base(children) => SetTag("div");

    /// <inheritdoc/>
    public new DivElement Id(string id) { base.Id(id); return this; }
    /// <inheritdoc/>
    public new DivElement Class(string className) { base.Class(className); return this; }
    /// <inheritdoc/>
    public new DivElement Style(string style) { base.Style(style); return this; }
    /// <inheritdoc/>
    public new DivElement Data(string key, string value) { base.Data(key, value); return this; }
    /// <inheritdoc/>
    public new DivElement Aria(string key, string value) { base.Aria(key, value); return this; }
    /// <inheritdoc/>
    public new DivElement Role(string role) { base.Role(role); return this; }
    /// <inheritdoc/>
    public new DivElement Hidden() { base.Hidden(); return this; }
    /// <inheritdoc/>
    public new DivElement Disabled() { base.Disabled(); return this; }
    /// <inheritdoc/>
    public new DivElement Required() { base.Required(); return this; }
    /// <inheritdoc/>
    public new DivElement ReadOnly() { base.ReadOnly(); return this; }
    /// <inheritdoc/>
    public new DivElement Custom(string name, string value) { base.Custom(name, value); return this; }
    /// <inheritdoc/>
    public new DivElement On(string eventName, string handler) { base.On(eventName, handler); return this; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="DivElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public DivElement(string textContent) : base(textContent) => SetTag("div");
}

/// <summary>
/// Factory methods for creating <see cref="DivElement"/> instances.
/// </summary>
public static class DivExtensions
{
    /// <summary>
    /// Creates a new &lt;div&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="DivElement"/>.</returns>
    public static DivElement Div(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;div&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="DivElement"/>.</returns>
    public static DivElement Div(string textContent) => new(textContent);
}
