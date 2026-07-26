using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap badge component for labeling and highlighting counts or statuses.
/// </summary>
public sealed class BadgeComponent : Element<BadgeComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BadgeComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the badge.</param>
    public BadgeComponent(params Node[] children) : base(children) { SetTag("span"); Class("badge"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadgeComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the badge.</param>
    public BadgeComponent(string textContent) : base(textContent) { SetTag("span"); Class("badge"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadgeComponent"/> class.
    /// </summary>
    public BadgeComponent() { SetTag("span"); Class("badge"); }

    /// <summary>
    /// Applies the primary background color.
    /// </summary>
    /// <returns>The current <see cref="BadgeComponent"/> instance.</returns>
    public BadgeComponent Primary() => Class("bg-primary");

    /// <summary>
    /// Applies the secondary background color.
    /// </summary>
    /// <returns>The current <see cref="BadgeComponent"/> instance.</returns>
    public BadgeComponent Secondary() => Class("bg-secondary");

    /// <summary>
    /// Applies the success background color.
    /// </summary>
    /// <returns>The current <see cref="BadgeComponent"/> instance.</returns>
    public BadgeComponent Success() => Class("bg-success");

    /// <summary>
    /// Applies the danger background color.
    /// </summary>
    /// <returns>The current <see cref="BadgeComponent"/> instance.</returns>
    public BadgeComponent Danger() => Class("bg-danger");

    /// <summary>
    /// Applies the warning background color with dark text.
    /// </summary>
    /// <returns>The current <see cref="BadgeComponent"/> instance.</returns>
    public BadgeComponent Warning() => Class("bg-warning text-dark");

    /// <summary>
    /// Applies the info background color with dark text.
    /// </summary>
    /// <returns>The current <see cref="BadgeComponent"/> instance.</returns>
    public BadgeComponent Info() => Class("bg-info text-dark");

    /// <summary>
    /// Applies the light background color with dark text.
    /// </summary>
    /// <returns>The current <see cref="BadgeComponent"/> instance.</returns>
    public BadgeComponent Light() => Class("bg-light text-dark");

    /// <summary>
    /// Applies the dark background color.
    /// </summary>
    /// <returns>The current <see cref="BadgeComponent"/> instance.</returns>
    public BadgeComponent Dark() => Class("bg-dark");

    /// <summary>
    /// Makes the badge pill-shaped with rounded corners.
    /// </summary>
    /// <returns>The current <see cref="BadgeComponent"/> instance.</returns>
    public BadgeComponent Pill() => Class("rounded-pill");
}

/// <summary>
/// A Bootstrap notification badge positioned as an overlay on another element.
/// </summary>
public sealed class NotificationBadgeComponent : Element<NotificationBadgeComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationBadgeComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the notification badge.</param>
    public NotificationBadgeComponent(string textContent) : base(textContent)
    {
        SetTag("span");
        Class("position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationBadgeComponent"/> class with default text "New".
    /// </summary>
    public NotificationBadgeComponent() : base("New")
    {
        SetTag("span");
        Class("position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger");
    }
}

/// <summary>
/// Extension methods for creating Bootstrap badge components.
/// </summary>
public static class BadgeExtensions
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

    /// <summary>
    /// Creates a new <see cref="NotificationBadgeComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the notification badge.</param>
    /// <returns>A new <see cref="NotificationBadgeComponent"/> instance.</returns>
    public static NotificationBadgeComponent NotificationBadge(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new <see cref="NotificationBadgeComponent"/> with default text.
    /// </summary>
    /// <returns>A new <see cref="NotificationBadgeComponent"/> instance.</returns>
    public static NotificationBadgeComponent NotificationBadge() => new();
}
