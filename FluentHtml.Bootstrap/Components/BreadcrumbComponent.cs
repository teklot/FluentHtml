using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap breadcrumb container component that wraps the breadcrumb list.
/// </summary>
public sealed class BreadcrumbComponent : Element<BreadcrumbComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the breadcrumb.</param>
    public BreadcrumbComponent(params Node[] children) : base(children) { SetTag("nav"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbComponent"/> class.
    /// </summary>
    public BreadcrumbComponent() { SetTag("nav"); }

    /// <summary>
    /// Sets the aria-label attribute for accessibility.
    /// </summary>
    /// <param name="label">The aria-label value.</param>
    /// <returns>The current <see cref="BreadcrumbComponent"/> instance.</returns>
    public BreadcrumbComponent AriaLabel(string label) { Attributes.Set("aria-label", label); return this; }
}

/// <summary>
/// A Bootstrap breadcrumb list component rendered as an ordered list.
/// </summary>
public sealed class BreadcrumbListComponent : Element<BreadcrumbListComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbListComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the breadcrumb list.</param>
    public BreadcrumbListComponent(params Node[] children) : base(children) { SetTag("ol"); Class("breadcrumb"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbListComponent"/> class.
    /// </summary>
    public BreadcrumbListComponent() { SetTag("ol"); Class("breadcrumb"); }

    /// <summary>
    /// Applies the small breadcrumb style.
    /// </summary>
    /// <returns>The current <see cref="BreadcrumbListComponent"/> instance.</returns>
    public BreadcrumbListComponent Small() => Class("breadcrumb-item");
}

/// <summary>
/// A Bootstrap breadcrumb item component representing a single item in the breadcrumb trail.
/// </summary>
public sealed class BreadcrumbItemComponent : Element<BreadcrumbItemComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbItemComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the breadcrumb item.</param>
    public BreadcrumbItemComponent(params Node[] children) : base(children) { SetTag("li"); Class("breadcrumb-item"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbItemComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the breadcrumb item.</param>
    public BreadcrumbItemComponent(string textContent) : base(textContent) { SetTag("li"); Class("breadcrumb-item"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbItemComponent"/> class.
    /// </summary>
    public BreadcrumbItemComponent() { SetTag("li"); Class("breadcrumb-item"); }

    /// <summary>
    /// Marks this breadcrumb item as the active (current) page.
    /// </summary>
    /// <returns>The current <see cref="BreadcrumbItemComponent"/> instance.</returns>
    public BreadcrumbItemComponent Active() => Class("active");

    /// <summary>
    /// Sets the aria-current attribute for the active breadcrumb item.
    /// </summary>
    /// <param name="value">The aria-current value (e.g., "page").</param>
    /// <returns>The current <see cref="BreadcrumbItemComponent"/> instance.</returns>
    public BreadcrumbItemComponent AriaCurrent(string value) { Attributes.Set("aria-current", value); return this; }
}

/// <summary>
/// A Bootstrap breadcrumb link component for navigable breadcrumb items.
/// </summary>
public sealed class BreadcrumbLinkComponent : Element<BreadcrumbLinkComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbLinkComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the breadcrumb link.</param>
    public BreadcrumbLinkComponent(params Node[] children) : base(children) => SetTag("a");

    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbLinkComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the breadcrumb link.</param>
    public BreadcrumbLinkComponent(string textContent) : base(textContent) => SetTag("a");

    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbLinkComponent"/> class.
    /// </summary>
    public BreadcrumbLinkComponent() => SetTag("a");

    /// <summary>
    /// Sets the href attribute for the breadcrumb link.
    /// </summary>
    /// <param name="href">The URL target of the link.</param>
    /// <returns>The current <see cref="BreadcrumbLinkComponent"/> instance.</returns>
    public BreadcrumbLinkComponent Href(string href) { Attributes.Set("href", href); return this; }
}

/// <summary>
/// Extension methods for creating Bootstrap breadcrumb components.
/// </summary>
public static class BreadcrumbExtensions
{
    /// <summary>
    /// Creates a new <see cref="BreadcrumbComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="BreadcrumbComponent"/> instance.</returns>
    public static BreadcrumbComponent Breadcrumb(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="BreadcrumbComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="BreadcrumbComponent"/> instance.</returns>
    public static BreadcrumbComponent Breadcrumb() => new();

    /// <summary>
    /// Creates a new <see cref="BreadcrumbListComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="BreadcrumbListComponent"/> instance.</returns>
    public static BreadcrumbListComponent BreadcrumbList(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="BreadcrumbListComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="BreadcrumbListComponent"/> instance.</returns>
    public static BreadcrumbListComponent BreadcrumbList() => new();

    /// <summary>
    /// Creates a new <see cref="BreadcrumbItemComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="BreadcrumbItemComponent"/> instance.</returns>
    public static BreadcrumbItemComponent BreadcrumbItem(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="BreadcrumbItemComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the breadcrumb item.</param>
    /// <returns>A new <see cref="BreadcrumbItemComponent"/> instance.</returns>
    public static BreadcrumbItemComponent BreadcrumbItem(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="BreadcrumbItemComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="BreadcrumbItemComponent"/> instance.</returns>
    public static BreadcrumbItemComponent BreadcrumbItem() => new();

    /// <summary>
    /// Creates a new <see cref="BreadcrumbLinkComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="BreadcrumbLinkComponent"/> instance.</returns>
    public static BreadcrumbLinkComponent BreadcrumbLink(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="BreadcrumbLinkComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the breadcrumb link.</param>
    /// <returns>A new <see cref="BreadcrumbLinkComponent"/> instance.</returns>
    public static BreadcrumbLinkComponent BreadcrumbLink(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="BreadcrumbLinkComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="BreadcrumbLinkComponent"/> instance.</returns>
    public static BreadcrumbLinkComponent BreadcrumbLink() => new();
}
