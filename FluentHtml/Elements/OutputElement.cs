using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;output&gt; element.
/// </summary>
public sealed class OutputElement : Element<OutputElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OutputElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public OutputElement(params Node[] children) : base(children) => SetTag("output");

    /// <summary>
    /// Initializes a new instance of the <see cref="OutputElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public OutputElement(string textContent) : base(textContent) => SetTag("output");
}

/// <summary>
/// Factory methods for creating <see cref="OutputElement"/> instances.
/// </summary>
public static class OutputExtensions
{
    /// <summary>
    /// Creates a new &lt;output&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="OutputElement"/>.</returns>
    public static OutputElement Output(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;output&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="OutputElement"/>.</returns>
    public static OutputElement Output(string textContent) => new(textContent);
}
