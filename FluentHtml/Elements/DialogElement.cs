using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;dialog&gt; element.
/// </summary>
public sealed class DialogElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DialogElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public DialogElement(params Node[] children) : base(children) => SetTag("dialog");

    /// <summary>
    /// Initializes a new instance of the <see cref="DialogElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public DialogElement(string textContent) : base(textContent) => SetTag("dialog");
}

/// <summary>
/// Factory methods for creating <see cref="DialogElement"/> instances.
/// </summary>
public static class DialogExtensions
{
    /// <summary>
    /// Creates a new &lt;dialog&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="DialogElement"/>.</returns>
    public static DialogElement Dialog(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;dialog&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="DialogElement"/>.</returns>
    public static DialogElement Dialog(string textContent) => new(textContent);
}
