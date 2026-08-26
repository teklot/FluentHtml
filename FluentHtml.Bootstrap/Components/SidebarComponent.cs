using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap sidebar component for vertical navigation.
/// Collapsible on mobile using offcanvas pattern.
/// </summary>
public sealed class SidebarComponent : Element<SidebarComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the sidebar.</param>
    public SidebarComponent(params Node[] children) : base(children) { SetTag("nav"); Class("d-flex flex-column flex-shrink-0 p-3"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarComponent"/> class.
    /// </summary>
    public SidebarComponent() { SetTag("nav"); Class("d-flex flex-column flex-shrink-0 p-3"); }

    /// <summary>
    /// Sets a fixed width on the sidebar.
    /// </summary>
    /// <param name="width">The width value (e.g., "280px").</param>
    /// <returns>The current <see cref="SidebarComponent"/> instance.</returns>
    public SidebarComponent Width(string width) { Attributes.Set("style", $"width:{width}"); return this; }

    /// <summary>
    /// Sets a minimum height on the sidebar.
    /// </summary>
    /// <param name="height">The minimum height value (e.g., "100vh").</param>
    /// <returns>The current <see cref="SidebarComponent"/> instance.</returns>
    public SidebarComponent MinHeight(string height) { Attributes.Set("style", $"min-height:{height}"); return this; }
}

/// <summary>
/// A Bootstrap sidebar brand component.
/// </summary>
public sealed class SidebarBrandComponent : Element<SidebarBrandComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarBrandComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the brand.</param>
    public SidebarBrandComponent(params Node[] children) : base(children) { SetTag("a"); Class("d-flex align-items-center mb-3 mb-md-0 text-dark text-decoration-none"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarBrandComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The brand text.</param>
    public SidebarBrandComponent(string textContent) : base(textContent) { SetTag("a"); Class("d-flex align-items-center mb-3 mb-md-0 text-dark text-decoration-none"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarBrandComponent"/> class.
    /// </summary>
    public SidebarBrandComponent() { SetTag("a"); Class("d-flex align-items-center mb-3 mb-md-0 text-dark text-decoration-none"); }

    /// <summary>
    /// Sets the href attribute for the brand link.
    /// </summary>
    /// <param name="href">The URL target of the link.</param>
    /// <returns>The current <see cref="SidebarBrandComponent"/> instance.</returns>
    public SidebarBrandComponent Href(string href) { Attributes.Set("href", href); return this; }
}

/// <summary>
/// A Bootstrap sidebar navigation list component.
/// </summary>
public sealed class SidebarNavComponent : Element<SidebarNavComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarNavComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the nav.</param>
    public SidebarNavComponent(params Node[] children) : base(children) { SetTag("ul"); Class("nav nav-pills flex-column mb-auto"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarNavComponent"/> class.
    /// </summary>
    public SidebarNavComponent() { SetTag("ul"); Class("nav nav-pills flex-column mb-auto"); }
}

/// <summary>
/// A Bootstrap sidebar nav item component.
/// </summary>
public sealed class SidebarNavItemComponent : Element<SidebarNavItemComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarNavItemComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public SidebarNavItemComponent(params Node[] children) : base(children) { SetTag("li"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarNavItemComponent"/> class.
    /// </summary>
    public SidebarNavItemComponent() { SetTag("li"); }
}

/// <summary>
/// A Bootstrap sidebar nav link component.
/// </summary>
public sealed class SidebarNavLinkComponent : Element<SidebarNavLinkComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarNavLinkComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public SidebarNavLinkComponent(params Node[] children) : base(children) { SetTag("a"); Class("nav-link"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarNavLinkComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The link text.</param>
    public SidebarNavLinkComponent(string textContent) : base(textContent) { SetTag("a"); Class("nav-link"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarNavLinkComponent"/> class.
    /// </summary>
    public SidebarNavLinkComponent() { SetTag("a"); Class("nav-link"); }

    /// <summary>
    /// Sets the href attribute for the nav link.
    /// </summary>
    /// <param name="href">The URL target of the link.</param>
    /// <returns>The current <see cref="SidebarNavLinkComponent"/> instance.</returns>
    public SidebarNavLinkComponent Href(string href) { Attributes.Set("href", href); return this; }

    /// <summary>
    /// Marks this nav link as the active item.
    /// </summary>
    /// <returns>The current <see cref="SidebarNavLinkComponent"/> instance.</returns>
    public SidebarNavLinkComponent Active() => Class("active");

    /// <summary>
    /// Adds HTMX attributes for partial loading.
    /// </summary>
    /// <param name="url">The hx-get URL.</param>
    /// <param name="target">The hx-target selector.</param>
    /// <returns>The current <see cref="SidebarNavLinkComponent"/> instance.</returns>
    public SidebarNavLinkComponent HxNav(string url, string target = "#main-content")
    {
        Attributes.Set("hx-get", url);
        Attributes.Set("hx-target", target);
        Attributes.Set("hx-push-url", "true");
        Attributes.Set("hx-swap", "innerHTML");
        return this;
    }
}

/// <summary>
/// A Bootstrap sidebar section component for grouping nav items.
/// </summary>
public sealed class SidebarSectionComponent : Element<SidebarSectionComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarSectionComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the section.</param>
    public SidebarSectionComponent(params Node[] children) : base(children) { SetTag("div"); Class("mb-1"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarSectionComponent"/> class.
    /// </summary>
    public SidebarSectionComponent() { SetTag("div"); Class("mb-1"); }
}

/// <summary>
/// A Bootstrap sidebar section heading component.
/// </summary>
public sealed class SidebarSectionHeadingComponent : Element<SidebarSectionHeadingComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarSectionHeadingComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The heading text.</param>
    public SidebarSectionHeadingComponent(string textContent) : base(textContent) { SetTag("small"); Class("text-muted text-uppercase fw-bold"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarSectionHeadingComponent"/> class.
    /// </summary>
    public SidebarSectionHeadingComponent() { SetTag("small"); Class("text-muted text-uppercase fw-bold"); }
}

/// <summary>
/// A Bootstrap sidebar divider component.
/// </summary>
public sealed class SidebarDividerComponent : Element<SidebarDividerComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SidebarDividerComponent"/> class.
    /// </summary>
    public SidebarDividerComponent() { SetTag("hr"); Class("my-2"); }
}

/// <summary>
/// Extension methods for creating Bootstrap sidebar components.
/// </summary>
public static class SidebarExtensions
{
    /// <summary>
    /// Creates a new <see cref="SidebarComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="SidebarComponent"/> instance.</returns>
    public static SidebarComponent Sidebar(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="SidebarComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="SidebarComponent"/> instance.</returns>
    public static SidebarComponent Sidebar() => new();

    /// <summary>
    /// Creates a new <see cref="SidebarBrandComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="SidebarBrandComponent"/> instance.</returns>
    public static SidebarBrandComponent SidebarBrand(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="SidebarBrandComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The brand text.</param>
    /// <returns>A new <see cref="SidebarBrandComponent"/> instance.</returns>
    public static SidebarBrandComponent SidebarBrand(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="SidebarBrandComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="SidebarBrandComponent"/> instance.</returns>
    public static SidebarBrandComponent SidebarBrand() => new();

    /// <summary>
    /// Creates a new <see cref="SidebarNavComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="SidebarNavComponent"/> instance.</returns>
    public static SidebarNavComponent SidebarNav(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="SidebarNavComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="SidebarNavComponent"/> instance.</returns>
    public static SidebarNavComponent SidebarNav() => new();

    /// <summary>
    /// Creates a new <see cref="SidebarNavItemComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="SidebarNavItemComponent"/> instance.</returns>
    public static SidebarNavItemComponent SidebarNavItem(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="SidebarNavItemComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="SidebarNavItemComponent"/> instance.</returns>
    public static SidebarNavItemComponent SidebarNavItem() => new();

    /// <summary>
    /// Creates a new <see cref="SidebarNavLinkComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="SidebarNavLinkComponent"/> instance.</returns>
    public static SidebarNavLinkComponent SidebarNavLink(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="SidebarNavLinkComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The link text.</param>
    /// <returns>A new <see cref="SidebarNavLinkComponent"/> instance.</returns>
    public static SidebarNavLinkComponent SidebarNavLink(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="SidebarNavLinkComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="SidebarNavLinkComponent"/> instance.</returns>
    public static SidebarNavLinkComponent SidebarNavLink() => new();

    /// <summary>
    /// Creates a new <see cref="SidebarSectionComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="SidebarSectionComponent"/> instance.</returns>
    public static SidebarSectionComponent SidebarSection(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="SidebarSectionComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="SidebarSectionComponent"/> instance.</returns>
    public static SidebarSectionComponent SidebarSection() => new();

    /// <summary>
    /// Creates a new <see cref="SidebarSectionHeadingComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The heading text.</param>
    /// <returns>A new <see cref="SidebarSectionHeadingComponent"/> instance.</returns>
    public static SidebarSectionHeadingComponent SidebarSectionHeading(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="SidebarSectionHeadingComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="SidebarSectionHeadingComponent"/> instance.</returns>
    public static SidebarSectionHeadingComponent SidebarSectionHeading() => new();

    /// <summary>
    /// Creates a new <see cref="SidebarDividerComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="SidebarDividerComponent"/> instance.</returns>
    public static SidebarDividerComponent SidebarDivider() => new();
}
