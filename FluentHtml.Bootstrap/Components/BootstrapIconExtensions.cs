using FluentHtml.Components;
using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// Extension methods for creating Bootstrap Icons. These render <c>&lt;i&gt;</c> elements
/// with Bootstrap Icon CSS classes (e.g., <c>bi bi-house</c>).
/// </summary>
public static class BootstrapIconExtensions
{
    /// <summary>
    /// Creates a Bootstrap Icon element with the specified icon name.
    /// </summary>
    /// <param name="iconName">The Bootstrap Icon name (e.g., "house", "pencil", "trash").</param>
    /// <returns>A new <see cref="IconComponent"/> with Bootstrap Icon CSS classes.</returns>
    public static IconComponent BiIcon(string iconName)
    {
        return new IconComponent(iconName).Class($"bi bi-{iconName}");
    }

    /// <summary>
    /// Applies the Bootstrap Icon extra-small size class.
    /// </summary>
    /// <param name="icon">The icon element.</param>
    /// <returns>The icon for method chaining.</returns>
    public static IconComponent BiFs(this IconComponent icon) => icon.Class("bi");

    /// <summary>
    /// Applies a Bootstrap Icon with the specified size.
    /// </summary>
    /// <param name="icon">The icon element.</param>
    /// <param name="size">The Bootstrap font-size class (e.g., "fs-1", "fs-2", "fs-3", "fs-4", "fs-5").</param>
    /// <returns>The icon for method chaining.</returns>
    public static T BiSize<T>(this T icon, string size) where T : Element<T> => icon.Class(size);
}
