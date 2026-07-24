using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

public sealed class BadgeComponent : Element
{
    public BadgeComponent(params Node[] children) : base(children) { SetTag("span"); Class("badge"); }

    public BadgeComponent(string textContent) : base(textContent) { SetTag("span"); Class("badge"); }

    public BadgeComponent() { SetTag("span"); Class("badge"); }

    public BadgeComponent Primary() => (BadgeComponent)Class("bg-primary");

    public BadgeComponent Secondary() => (BadgeComponent)Class("bg-secondary");

    public BadgeComponent Success() => (BadgeComponent)Class("bg-success");

    public BadgeComponent Danger() => (BadgeComponent)Class("bg-danger");

    public BadgeComponent Warning() => (BadgeComponent)Class("bg-warning text-dark");

    public BadgeComponent Info() => (BadgeComponent)Class("bg-info text-dark");

    public BadgeComponent Light() => (BadgeComponent)Class("bg-light text-dark");

    public BadgeComponent Dark() => (BadgeComponent)Class("bg-dark");

    public BadgeComponent Pill() => (BadgeComponent)Class("rounded-pill");
}

public sealed class NotificationBadgeComponent : Element
{
    public NotificationBadgeComponent(string textContent) : base(textContent)
    {
        SetTag("span");
        Class("position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger");
    }

    public NotificationBadgeComponent() : base("New")
    {
        SetTag("span");
        Class("position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger");
    }
}

public static class BadgeExtensions
{
    public static BadgeComponent Badge(params Node[] children) => new(children);

    public static BadgeComponent Badge(string textContent) => new(textContent);

    public static BadgeComponent Badge() => new();

    public static NotificationBadgeComponent NotificationBadge(string textContent) => new(textContent);

    public static NotificationBadgeComponent NotificationBadge() => new();
}
