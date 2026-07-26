using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;meter&gt; element.
/// </summary>
public sealed class MeterElement : Element<MeterElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MeterElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public MeterElement(params Node[] children) : base(children) => SetTag("meter");

    /// <summary>
    /// Initializes a new instance of the <see cref="MeterElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public MeterElement(string textContent) : base(textContent) => SetTag("meter");

    /// <summary>
    /// Sets the value attribute for this element.
    /// </summary>
    /// <param name="value">The value value.</param>
    /// <returns>The current element for method chaining.</returns>
    public MeterElement Value(double value) { Attributes.Set("value", value.ToString()); return this; }

    /// <summary>
    /// Sets the min attribute for this element.
    /// </summary>
    /// <param name="value">The min value.</param>
    /// <returns>The current element for method chaining.</returns>
    public MeterElement Min(double value) { Attributes.Set("min", value.ToString()); return this; }

    /// <summary>
    /// Sets the max attribute for this element.
    /// </summary>
    /// <param name="value">The max value.</param>
    /// <returns>The current element for method chaining.</returns>
    public MeterElement Max(double value) { Attributes.Set("max", value.ToString()); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="MeterElement"/> instances.
/// </summary>
public static class MeterExtensions
{
    /// <summary>
    /// Creates a new &lt;meter&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="MeterElement"/>.</returns>
    public static MeterElement Meter(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;meter&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="MeterElement"/>.</returns>
    public static MeterElement Meter(string textContent) => new(textContent);
}
