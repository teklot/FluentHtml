using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;strong&gt; element.
/// </summary>
public sealed class StrongElement : Element<StrongElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StrongElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public StrongElement(params Node[] children) : base(children) => SetTag("strong");

    /// <summary>
    /// Initializes a new instance of the <see cref="StrongElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public StrongElement(string textContent) : base(textContent) => SetTag("strong");
}

/// <summary>
/// Factory methods for creating <see cref="StrongElement"/> instances.
/// </summary>
public static class StrongExtensions
{
    /// <summary>
    /// Creates a new &lt;strong&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="StrongElement"/>.</returns>
    public static StrongElement Strong(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;strong&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="StrongElement"/>.</returns>
    public static StrongElement Strong(string textContent) => new(textContent);
}
