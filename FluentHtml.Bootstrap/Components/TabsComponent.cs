using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap nav tabs container component. Contains tab navigation items.
/// </summary>
public sealed class TabsComponent : Element<TabsComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TabsComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the tabs.</param>
    public TabsComponent(params Node[] children) : base(children) { SetTag("ul"); Class("nav nav-tabs"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="TabsComponent"/> class.
    /// </summary>
    public TabsComponent() { SetTag("ul"); Class("nav nav-tabs"); }

    /// <summary>
    /// Uses pill-style tabs instead of underline-style tabs.
    /// </summary>
    /// <returns>The current <see cref="TabsComponent"/> instance.</returns>
    public TabsComponent Pills() => Class("nav-pills");

    /// <summary>
    /// Makes the tabs fill the available width.
    /// </summary>
    /// <returns>The current <see cref="TabsComponent"/> instance.</returns>
    public TabsComponent Fill() => Class("nav-fill");

    /// <summary>
    /// Justifies the tabs with equal width.
    /// </summary>
    /// <returns>The current <see cref="TabsComponent"/> instance.</returns>
    public TabsComponent Justified() => Class("nav-justified");

    /// <summary>
    /// Enables vertical tabs.
    /// </summary>
    /// <returns>The current <see cref="TabsComponent"/> instance.</returns>
    public TabsComponent Vertical() => Class("flex-column");
}

/// <summary>
/// A Bootstrap tab navigation item component.
/// </summary>
public sealed class TabItemComponent : Element<TabItemComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TabItemComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public TabItemComponent(params Node[] children) : base(children) { SetTag("li"); Class("nav-item"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="TabItemComponent"/> class.
    /// </summary>
    public TabItemComponent() { SetTag("li"); Class("nav-item"); }
}

/// <summary>
/// A Bootstrap tab navigation link component.
/// </summary>
public sealed class TabLinkComponent : Element<TabLinkComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TabLinkComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public TabLinkComponent(params Node[] children) : base(children)
    {
        SetTag("a");
        Class("nav-link");
        Attributes.Set("data-bs-toggle", "tab");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TabLinkComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The tab link text.</param>
    public TabLinkComponent(string textContent) : base(textContent)
    {
        SetTag("a");
        Class("nav-link");
        Attributes.Set("data-bs-toggle", "tab");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TabLinkComponent"/> class.
    /// </summary>
    public TabLinkComponent()
    {
        SetTag("a");
        Class("nav-link");
        Attributes.Set("data-bs-toggle", "tab");
    }

    /// <summary>
    /// Sets this tab link as the active tab.
    /// </summary>
    /// <returns>The current <see cref="TabLinkComponent"/> instance.</returns>
    public TabLinkComponent Active() => Class("active");
}

/// <summary>
/// A Bootstrap tab content container component.
/// </summary>
public sealed class TabContentComponent : Element<TabContentComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TabContentComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public TabContentComponent(params Node[] children) : base(children) { SetTag("div"); Class("tab-content"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="TabContentComponent"/> class.
    /// </summary>
    public TabContentComponent() { SetTag("div"); Class("tab-content"); }
}

/// <summary>
/// A Bootstrap tab pane component containing the tab's content.
/// </summary>
public sealed class TabPaneComponent : Element<TabPaneComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TabPaneComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public TabPaneComponent(params Node[] children) : base(children) { SetTag("div"); Class("tab-pane fade"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="TabPaneComponent"/> class.
    /// </summary>
    public TabPaneComponent() { SetTag("div"); Class("tab-pane fade"); }

    /// <summary>
    /// Makes this tab pane the active (visible) tab.
    /// </summary>
    /// <returns>The current <see cref="TabPaneComponent"/> instance.</returns>
    public TabPaneComponent Active() => Class("active");

    /// <summary>
    /// Shows this tab pane (use with Active for the initially visible tab).
    /// </summary>
    /// <returns>The current <see cref="TabPaneComponent"/> instance.</returns>
    public TabPaneComponent Show() => Class("show");
}

/// <summary>
/// Extension methods for creating Bootstrap tab components.
/// </summary>
public static class TabExtensions
{
    /// <summary>
    /// Creates a new <see cref="TabsComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="TabsComponent"/> instance.</returns>
    public static TabsComponent Tabs(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="TabsComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="TabsComponent"/> instance.</returns>
    public static TabsComponent Tabs() => new();

    /// <summary>
    /// Creates a new <see cref="TabItemComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="TabItemComponent"/> instance.</returns>
    public static TabItemComponent TabItem(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="TabItemComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="TabItemComponent"/> instance.</returns>
    public static TabItemComponent TabItem() => new();

    /// <summary>
    /// Creates a new <see cref="TabLinkComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="TabLinkComponent"/> instance.</returns>
    public static TabLinkComponent TabLink(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="TabLinkComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The tab link text.</param>
    /// <returns>A new <see cref="TabLinkComponent"/> instance.</returns>
    public static TabLinkComponent TabLink(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="TabLinkComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="TabLinkComponent"/> instance.</returns>
    public static TabLinkComponent TabLink() => new();

    /// <summary>
    /// Creates a new <see cref="TabContentComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="TabContentComponent"/> instance.</returns>
    public static TabContentComponent TabContent(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="TabContentComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="TabContentComponent"/> instance.</returns>
    public static TabContentComponent TabContent() => new();

    /// <summary>
    /// Creates a new <see cref="TabPaneComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="TabPaneComponent"/> instance.</returns>
    public static TabPaneComponent TabPane(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="TabPaneComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="TabPaneComponent"/> instance.</returns>
    public static TabPaneComponent TabPane() => new();
}
