using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A responsive layout component that provides breakpoint-aware layout regions.
/// Mobile-first: sidebar becomes offcanvas on small screens.
/// </summary>
public sealed class ResponsiveLayoutComponent : Element<ResponsiveLayoutComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ResponsiveLayoutComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the layout.</param>
    public ResponsiveLayoutComponent(params Node[] children) : base(children) { SetTag("div"); Class("d-flex"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ResponsiveLayoutComponent"/> class.
    /// </summary>
    public ResponsiveLayoutComponent() { SetTag("div"); Class("d-flex"); }

    /// <summary>
    /// Makes the layout fill the viewport height.
    /// </summary>
    /// <returns>The current <see cref="ResponsiveLayoutComponent"/> instance.</returns>
    public ResponsiveLayoutComponent VH100() { Attributes.Set("style", "min-height:100vh"); return this; }
}

/// <summary>
/// A responsive layout header component.
/// </summary>
public sealed class LayoutHeaderComponent : Element<LayoutHeaderComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutHeaderComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the header.</param>
    public LayoutHeaderComponent(params Node[] children) : base(children) { SetTag("header"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutHeaderComponent"/> class.
    /// </summary>
    public LayoutHeaderComponent() { SetTag("header"); }
}

/// <summary>
/// A responsive layout sidebar container component.
/// </summary>
public sealed class LayoutSidebarComponent : Element<LayoutSidebarComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutSidebarComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the sidebar.</param>
    public LayoutSidebarComponent(params Node[] children) : base(children) { SetTag("aside"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutSidebarComponent"/> class.
    /// </summary>
    public LayoutSidebarComponent() { SetTag("aside"); }

    /// <summary>
    /// Sets a fixed width on the sidebar.
    /// </summary>
    /// <param name="width">The width value (e.g., "250px").</param>
    /// <returns>The current <see cref="LayoutSidebarComponent"/> instance.</returns>
    public LayoutSidebarComponent Width(string width) { Attributes.Set("style", $"width:{width}"); return this; }
}

/// <summary>
/// A responsive layout content component.
/// </summary>
public sealed class LayoutContentComponent : Element<LayoutContentComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutContentComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the content area.</param>
    public LayoutContentComponent(params Node[] children) : base(children) { SetTag("main"); Class("flex-grow-1"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutContentComponent"/> class.
    /// </summary>
    public LayoutContentComponent() { SetTag("main"); Class("flex-grow-1"); }
}

/// <summary>
/// A responsive layout footer component.
/// </summary>
public sealed class LayoutFooterComponent : Element<LayoutFooterComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutFooterComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the footer.</param>
    public LayoutFooterComponent(params Node[] children) : base(children) { SetTag("footer"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutFooterComponent"/> class.
    /// </summary>
    public LayoutFooterComponent() { SetTag("footer"); }
}

/// <summary>
/// Extension methods for creating responsive layout components.
/// </summary>
public static class LayoutExtensions
{
    /// <summary>
    /// Creates a new <see cref="ResponsiveLayoutComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="ResponsiveLayoutComponent"/> instance.</returns>
    public static ResponsiveLayoutComponent ResponsiveLayout(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="ResponsiveLayoutComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ResponsiveLayoutComponent"/> instance.</returns>
    public static ResponsiveLayoutComponent ResponsiveLayout() => new();

    /// <summary>
    /// Creates a new <see cref="LayoutHeaderComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="LayoutHeaderComponent"/> instance.</returns>
    public static LayoutHeaderComponent LayoutHeader(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="LayoutHeaderComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="LayoutHeaderComponent"/> instance.</returns>
    public static LayoutHeaderComponent LayoutHeader() => new();

    /// <summary>
    /// Creates a new <see cref="LayoutSidebarComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="LayoutSidebarComponent"/> instance.</returns>
    public static LayoutSidebarComponent LayoutSidebar(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="LayoutSidebarComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="LayoutSidebarComponent"/> instance.</returns>
    public static LayoutSidebarComponent LayoutSidebar() => new();

    /// <summary>
    /// Creates a new <see cref="LayoutContentComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="LayoutContentComponent"/> instance.</returns>
    public static LayoutContentComponent LayoutContent(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="LayoutContentComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="LayoutContentComponent"/> instance.</returns>
    public static LayoutContentComponent LayoutContent() => new();

    /// <summary>
    /// Creates a new <see cref="LayoutFooterComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="LayoutFooterComponent"/> instance.</returns>
    public static LayoutFooterComponent LayoutFooter(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="LayoutFooterComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="LayoutFooterComponent"/> instance.</returns>
    public static LayoutFooterComponent LayoutFooter() => new();
}
