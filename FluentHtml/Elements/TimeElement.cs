using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;time&gt; element.
/// </summary>
public sealed class TimeElement : Element<TimeElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TimeElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public TimeElement(params Node[] children) : base(children) => SetTag("time");

    /// <summary>
    /// Initializes a new instance of the <see cref="TimeElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public TimeElement(string textContent) : base(textContent) => SetTag("time");

    /// <summary>
    /// Sets the datetime attribute for this element.
    /// </summary>
    /// <param name="value">The datetime value.</param>
    /// <returns>The current element for method chaining.</returns>
    public TimeElement DateTime(string value) { Attributes.Set("datetime", value); return this; }
}

/// <summary>
/// Factory methods for creating <see cref="TimeElement"/> instances.
/// </summary>
public static class TimeExtensions
{
    /// <summary>
    /// Creates a new &lt;time&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="TimeElement"/>.</returns>
    public static TimeElement Time(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;time&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="TimeElement"/>.</returns>
    public static TimeElement Time(string textContent) => new(textContent);
}
