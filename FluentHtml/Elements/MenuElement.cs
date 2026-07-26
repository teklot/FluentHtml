using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;menu&gt; element.
/// </summary>
public sealed class MenuElement : Element<MenuElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MenuElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public MenuElement(params Node[] children) : base(children) => SetTag("menu");

    /// <summary>
    /// Initializes a new instance of the <see cref="MenuElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public MenuElement(string textContent) : base(textContent) => SetTag("menu");
}

/// <summary>
/// Factory methods for creating <see cref="MenuElement"/> instances.
/// </summary>
public static class MenuExtensions
{
    /// <summary>
    /// Creates a new &lt;menu&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="MenuElement"/>.</returns>
    public static MenuElement Menu(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;menu&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="MenuElement"/>.</returns>
    public static MenuElement Menu(string textContent) => new(textContent);
}
