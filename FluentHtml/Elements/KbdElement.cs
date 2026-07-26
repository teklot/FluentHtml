using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;kbd&gt; element.
/// </summary>
public sealed class KbdElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="KbdElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public KbdElement(params Node[] children) : base(children) => SetTag("kbd");

    /// <summary>
    /// Initializes a new instance of the <see cref="KbdElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public KbdElement(string textContent) : base(textContent) => SetTag("kbd");
}

/// <summary>
/// Factory methods for creating <see cref="KbdElement"/> instances.
/// </summary>
public static class KbdExtensions
{
    /// <summary>
    /// Creates a new &lt;kbd&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="KbdElement"/>.</returns>
    public static KbdElement Kbd(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;kbd&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="KbdElement"/>.</returns>
    public static KbdElement Kbd(string textContent) => new(textContent);
}
