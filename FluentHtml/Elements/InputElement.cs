using FluentHtml.Enums;
using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;input&gt; element. Use the <see cref="InputExtensions.Input"/> factory method to create instances.
/// </summary>
public sealed class InputElement : Element<InputElement>
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
    public InputElement Type(string type)
    {
        Ensure.NotEmpty(type, nameof(type));
        Attributes.Set("type", type);
        return this;
    }

    /// <summary>
    /// Sets the type attribute for this input element using a strongly-typed enum.
    /// </summary>
    /// <param name="type">The input type.</param>
    /// <returns>The current input for method chaining.</returns>
    public InputElement Type(InputType type) => Type(type.ToString().ToLower());

    /// <summary>
    /// Sets the value attribute for this input element.
    /// </summary>
    /// <param name="value">The input value.</param>
    /// <returns>The current input for method chaining.</returns>
    public InputElement Value(string value)
    {
        Ensure.NotNull(value, nameof(value));
        Attributes.Set("value", value);
        return this;
    }

    /// <summary>
    /// Sets the name attribute for this input element.
    /// </summary>
    /// <param name="name">The input name used for form submission.</param>
    /// <returns>The current input for method chaining.</returns>
    public InputElement Name(string name)
    {
        Ensure.NotEmpty(name, nameof(name));
        Attributes.Set("name", name);
        return this;
    }

    /// <summary>
    /// Sets the placeholder attribute for this input element.
    /// </summary>
    /// <param name="placeholder">The placeholder text.</param>
    /// <returns>The current input for method chaining.</returns>
    public InputElement Placeholder(string placeholder)
    {
        Ensure.NotNull(placeholder, nameof(placeholder));
        Attributes.Set("placeholder", placeholder);
        return this;
    }

    /// <summary>
    /// Sets the autocomplete attribute for this input element.
    /// </summary>
    /// <param name="autocomplete">The autocomplete setting.</param>
    /// <returns>The current input for method chaining.</returns>
    public InputElement AutoComplete(AutoComplete autocomplete) => AutoComplete(autocomplete.ToString().ToLower());

    /// <summary>
    /// Sets the autocomplete attribute for this input element.
    /// </summary>
    /// <param name="autocomplete">The autocomplete value (e.g., "on", "off").</param>
    /// <returns>The current input for method chaining.</returns>
    public InputElement AutoComplete(string autocomplete)
    {
        Ensure.NotEmpty(autocomplete, nameof(autocomplete));
        Attributes.Set("autocomplete", autocomplete);
        return this;
    }
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
