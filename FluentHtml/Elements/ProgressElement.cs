using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;progress&gt; element.
/// </summary>
public sealed class ProgressElement : Element<ProgressElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public ProgressElement(params Node[] children) : base(children) => SetTag("progress");

    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public ProgressElement(string textContent) : base(textContent) => SetTag("progress");

    /// <summary>
    /// Sets the value attribute for this element.
    /// </summary>
    /// <param name="value">The value value.</param>
    /// <returns>The current element for method chaining.</returns>
    public ProgressElement Value(double value) { Attributes.Set("value", value.ToString()); return this; }

    /// <summary>
    /// Sets the max attribute for this element.
    /// </summary>
    /// <param name="value">The max value.</param>
    /// <returns>The current element for method chaining.</returns>
    public ProgressElement Max(double value) { Attributes.Set("max", value.ToString()); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="ProgressElement"/> instances.
/// </summary>
public static class ProgressExtensions
{
    /// <summary>
    /// Creates a new &lt;progress&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="ProgressElement"/>.</returns>
    public static ProgressElement Progress(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;progress&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="ProgressElement"/>.</returns>
    public static ProgressElement Progress(string textContent) => new(textContent);
}
