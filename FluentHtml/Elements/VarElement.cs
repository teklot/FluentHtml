using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;var&gt; element.
/// </summary>
public sealed class VarElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VarElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public VarElement(params Node[] children) : base(children) => SetTag("var");

    /// <summary>
    /// Initializes a new instance of the <see cref="VarElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public VarElement(string textContent) : base(textContent) => SetTag("var");
}

/// <summary>
/// Factory methods for creating <see cref="VarElement"/> instances.
/// </summary>
public static class VarExtensions
{
    /// <summary>
    /// Creates a new &lt;var&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="VarElement"/>.</returns>
    public static VarElement Var(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;var&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="VarElement"/>.</returns>
    public static VarElement Var(string textContent) => new(textContent);
}
