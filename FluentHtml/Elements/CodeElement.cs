using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;code&gt; element.
/// </summary>
public sealed class CodeElement : Element<CodeElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CodeElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public CodeElement(params Node[] children) : base(children) => SetTag("code");

    /// <summary>
    /// Initializes a new instance of the <see cref="CodeElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public CodeElement(string textContent) : base(textContent) => SetTag("code");
}

/// <summary>
/// Factory methods for creating <see cref="CodeElement"/> instances.
/// </summary>
public static class CodeExtensions
{
    /// <summary>
    /// Creates a new &lt;code&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="CodeElement"/>.</returns>
    public static CodeElement Code(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;code&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="CodeElement"/>.</returns>
    public static CodeElement Code(string textContent) => new(textContent);
}
