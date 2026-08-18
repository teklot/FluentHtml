using FluentHtml.Nodes;

namespace FluentHtml.Components;

/// <summary>
/// A standalone badge component that renders a semantic <c>&lt;span&gt;</c> element.
/// This is the framework-agnostic version. For Bootstrap-styled badges, use
/// the BadgeComponent in the FluentHtml.Bootstrap package.
/// </summary>
public sealed class BadgeComponent : Element<BadgeComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BadgeComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the badge.</param>
    public BadgeComponent(params Node[] children) : base(children) => SetTag("span");

    /// <summary>
    /// Initializes a new instance of the <see cref="BadgeComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the badge.</param>
    public BadgeComponent(string textContent) : base(textContent) => SetTag("span");

    /// <summary>
    /// Initializes a new instance of the <see cref="BadgeComponent"/> class.
    /// </summary>
    public BadgeComponent() => SetTag("span");
}

/// <summary>
/// Factory methods for creating <see cref="BadgeComponent"/> instances.
/// </summary>
public static class CoreBadgeExtensions
{
    /// <summary>
    /// Creates a new <see cref="BadgeComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="BadgeComponent"/> instance.</returns>
    public static BadgeComponent Badge(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="BadgeComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the badge.</param>
    /// <returns>A new <see cref="BadgeComponent"/> instance.</returns>
    public static BadgeComponent Badge(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="BadgeComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="BadgeComponent"/> instance.</returns>
    public static BadgeComponent Badge() => new();
}
