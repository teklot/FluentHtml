using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;input&gt; element. Use the <see cref="InputExtensions.Input"/> factory method to create instances.
/// </summary>
public sealed class InputElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InputElement"/> class. The element is self-closing.
    /// </summary>
    public InputElement() => SetTag("input", selfClosing: true);

    /// <summary>
    /// Sets the type attribute for this input element.
    /// </summary>
    /// <param name="type">The input type (e.g., "text", "email", "password", "checkbox").</param>
    /// <returns>The current input for method chaining.</returns>
    public InputElement Type(string type) { Attributes.Set("type", type); return this; }

    /// <summary>
    /// Sets the value attribute for this input element.
    /// </summary>
    /// <param name="value">The input value.</param>
    /// <returns>The current input for method chaining.</returns>
    public InputElement Value(string value) { Attributes.Set("value", value); return this; }

    /// <summary>
    /// Sets the name attribute for this input element.
    /// </summary>
    /// <param name="name">The input name used for form submission.</param>
    /// <returns>The current input for method chaining.</returns>
    public InputElement Name(string name) { Attributes.Set("name", name); return this; }

    /// <summary>
    /// Sets the placeholder attribute for this input element.
    /// </summary>
    /// <param name="placeholder">The placeholder text.</param>
    /// <returns>The current input for method chaining.</returns>
    public InputElement Placeholder(string placeholder) { Attributes.Set("placeholder", placeholder); return this; }

    /// <inheritdoc/>
    public new InputElement Id(string id) { base.Id(id); return this; }
    /// <inheritdoc/>
    public new InputElement Class(string className) { base.Class(className); return this; }
    /// <inheritdoc/>
    public new InputElement Required() { base.Required(); return this; }
    /// <inheritdoc/>
    public new InputElement Disabled() { base.Disabled(); return this; }
    /// <inheritdoc/>
    public new InputElement ReadOnly() { base.ReadOnly(); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="InputElement"/> instances.
/// </summary>
public static class InputExtensions
{
    /// <summary>
    /// Creates a new &lt;input&gt; element.
    /// </summary>
    /// <returns>A new <see cref="InputElement"/>.</returns>
    public static InputElement Input() => new();
}
