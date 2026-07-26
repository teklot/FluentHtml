using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;button&gt; element. Use the Button() factory methods to create instances.
/// </summary>
public sealed class ButtonElement : Element<ButtonElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public ButtonElement(params Node[] children) : base(children) => SetTag("button");

    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The button text.</param>
    public ButtonElement(string textContent) : base(textContent) => SetTag("button");

    /// <summary>
    /// Sets the type attribute for this button.
    /// </summary>
    /// <param name="type">The button type (e.g., "submit", "button", "reset").</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonElement Type(string type) { Attributes.Set("type", type); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="ButtonElement"/> instances.
/// </summary>
public static class ButtonExtensions
{
    /// <summary>
    /// Creates a new &lt;button&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="ButtonElement"/>.</returns>
    public static ButtonElement Button(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;button&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The button text.</param>
    /// <returns>A new <see cref="ButtonElement"/>.</returns>
    public static ButtonElement Button(string textContent) => new(textContent);
}
