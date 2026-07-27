using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;script&gt; element.
/// </summary>
public sealed class ScriptElement : Element<ScriptElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScriptElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public ScriptElement(params Node[] children) : base(children) => SetTag("script");

    /// <summary>
    /// Initializes a new instance of the <see cref="ScriptElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public ScriptElement(string textContent) : base(textContent) => SetTag("script");

    /// <summary>
    /// Sets the src attribute for this element.
    /// </summary>
    /// <param name="value">The src value.</param>
    /// <returns>The current element for method chaining.</returns>
    public ScriptElement Src(string value)
    {
        Ensure.NotEmpty(value, nameof(value));
        Attributes.Set("src", value);
        return this;
    }

    /// <summary>
    /// Sets the defer attribute on this element.
    /// </summary>
    /// <returns>The current element for method chaining.</returns>
    public ScriptElement Defer() { Attributes.SetBool("defer"); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="ScriptElement"/> instances.
/// </summary>
public static class ScriptExtensions
{
    /// <summary>
    /// Creates a new &lt;script&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="ScriptElement"/>.</returns>
    public static ScriptElement Script(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;script&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="ScriptElement"/>.</returns>
    public static ScriptElement Script(string textContent) => new(textContent);
}
