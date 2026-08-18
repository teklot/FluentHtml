using FluentHtml.Nodes;

namespace FluentHtml.Components;

/// <summary>
/// A framework-agnostic icon component that renders an <c>&lt;i&gt;</c> element.
/// The icon name is stored as a <c>data-icon</c> attribute. Concrete icon sets
/// (Bootstrap Icons, Font Awesome, etc.) add CSS classes via fluent methods or extension methods.
/// </summary>
public sealed class IconComponent : Element<IconComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IconComponent"/> class with the specified icon name.
    /// </summary>
    /// <param name="iconName">The icon identifier (e.g., "house", "user", "check").</param>
    public IconComponent(string iconName) : base()
    {
        SetTag("i");
        Attributes.Set("data-icon", iconName);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IconComponent"/> class.
    /// </summary>
    public IconComponent() : base()
    {
        SetTag("i");
    }
}

/// <summary>
/// Factory methods for creating <see cref="IconComponent"/> instances.
/// </summary>
public static class IconExtensions
{
    /// <summary>
    /// Creates a new <see cref="IconComponent"/> with the specified icon name.
    /// </summary>
    /// <param name="iconName">The icon identifier.</param>
    /// <returns>A new <see cref="IconComponent"/> instance.</returns>
    public static IconComponent Icon(string iconName) => new(iconName);

    /// <summary>
    /// Creates a new empty <see cref="IconComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="IconComponent"/> instance.</returns>
    public static IconComponent Icon() => new();
}
