using FluentHtml.Enums;
using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;form&gt; element. Use the Form() factory methods to create instances.
/// </summary>
public sealed class FormElement : Element<FormElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FormElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public FormElement(params Node[] children) : base(children) => SetTag("form");

    /// <summary>
    /// Initializes a new instance of the <see cref="FormElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The form text content.</param>
    public FormElement(string textContent) : base(textContent) => SetTag("form");

    /// <summary>
    /// Sets the action attribute for this form element.
    /// </summary>
    /// <param name="action">The URL to submit the form to.</param>
    /// <returns>The current form for method chaining.</returns>
    public FormElement Action(string action)
    {
        Ensure.NotEmpty(action, nameof(action));
        Attributes.Set("action", action);
        return this;
    }

    /// <summary>
    /// Sets the method attribute for this form element.
    /// </summary>
    /// <param name="method">The HTTP method (e.g., "get", "post").</param>
    /// <returns>The current form for method chaining.</returns>
    public FormElement Method(string method)
    {
        Ensure.NotEmpty(method, nameof(method));
        Attributes.Set("method", method);
        return this;
    }

    /// <summary>
    /// Sets the method attribute for this form element using a strongly-typed enum.
    /// </summary>
    /// <param name="method">The HTTP method.</param>
    /// <returns>The current form for method chaining.</returns>
    public FormElement Method(MethodType method) => Method(method.ToString().ToLower());
}

/// <summary>
/// Factory methods for creating <see cref="FormElement"/> instances.
/// </summary>
public static class FormExtensions
{
    /// <summary>
    /// Creates a new &lt;form&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="FormElement"/>.</returns>
    public static FormElement Form(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;form&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The form text content.</param>
    /// <returns>A new <see cref="FormElement"/>.</returns>
    public static FormElement Form(string textContent) => new(textContent);
}
