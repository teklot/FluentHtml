using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;template&gt; element.
/// </summary>
public sealed class TemplateElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TemplateElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public TemplateElement(params Node[] children) : base(children) => SetTag("template");

    /// <summary>
    /// Initializes a new instance of the <see cref="TemplateElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public TemplateElement(string textContent) : base(textContent) => SetTag("template");
}

/// <summary>
/// Factory methods for creating <see cref="TemplateElement"/> instances.
/// </summary>
public static class TemplateExtensions
{
    /// <summary>
    /// Creates a new &lt;template&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="TemplateElement"/>.</returns>
    public static TemplateElement Template(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;template&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="TemplateElement"/>.</returns>
    public static TemplateElement Template(string textContent) => new(textContent);
}
