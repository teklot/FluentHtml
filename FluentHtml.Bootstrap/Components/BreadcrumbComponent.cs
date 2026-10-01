using FluentHtml.Components;
using FluentHtml.Elements;
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
    /// Applies a reduced font size to the breadcrumb.
    /// </summary>
    /// <returns>The current <see cref="BreadcrumbListComponent"/> instance.</returns>
    public BreadcrumbListComponent Small() => Style("--bs-breadcrumb-font-size: 0.875rem;");

    /// <summary>
    /// Sets a custom separator between breadcrumb items, overriding the default divider.
    /// </summary>
    /// <param name="separator">The separator to display between items (e.g. ">" or "/").</param>
    /// <returns>The current <see cref="BreadcrumbListComponent"/> instance.</returns>
    public BreadcrumbListComponent Separator(string separator)
    {
        ArgumentNullException.ThrowIfNull(separator);
        return Style($"--bs-breadcrumb-divider: '{separator}';");
    }
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
    /// <param name="url">The URL target of the link.</param>
    /// <returns>The current <see cref="BreadcrumbLinkComponent"/> instance.</returns>
    public BreadcrumbLinkComponent Href(string url) { Attributes.Set("href", url); return this; }

    /// <summary>
    /// Issues an HTMX GET request when the breadcrumb link is clicked.
    /// </summary>
    /// <param name="url">The endpoint to request.</param>
    /// <returns>The current <see cref="BreadcrumbLinkComponent"/> instance.</returns>
    public BreadcrumbLinkComponent HxGet(string url)
    {
        ArgumentNullException.ThrowIfNull(url);
        Attributes.Set("hx-get", url);
        Attributes.Set("hx-push-url", "true");
        Attributes.Set("hx-swap", "outerHTML");
        return this;
    }

    /// <summary>
    /// Sets the HTMX swap target for the breadcrumb link.
    /// </summary>
    /// <param name="selector">The target selector.</param>
    /// <returns>The current <see cref="BreadcrumbLinkComponent"/> instance.</returns>
    public BreadcrumbLinkComponent Target(string selector)
    {
        ArgumentNullException.ThrowIfNull(selector);
        Attributes.Set("hx-target", selector);
        return this;
    }

    /// <summary>
    /// Sets the HTMX swap style for the breadcrumb link.
    /// </summary>
    /// <param name="swapStyle">The swap style.</param>
    /// <returns>The current <see cref="BreadcrumbLinkComponent"/> instance.</returns>
    public BreadcrumbLinkComponent Swap(string swapStyle)
    {
        ArgumentNullException.ThrowIfNull(swapStyle);
        Attributes.Set("hx-swap", swapStyle);
        return this;
    }
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

    /// <summary>
    /// Creates a new <see cref="BreadcrumbCollapseComponent"/> that keeps the first
    /// <paramref name="keepVisible"/> items visible and collapses the rest behind a toggle.
    /// </summary>
    /// <param name="keepVisible">The number of leading items to keep visible.</param>
    /// <param name="items">The breadcrumb items in order.</param>
    /// <returns>A new <see cref="BreadcrumbCollapseComponent"/> instance.</returns>
    public static BreadcrumbCollapseComponent BreadcrumbCollapse(int keepVisible, params BreadcrumbItemComponent[] items)
        => new(keepVisible, items);
}

/// <summary>
/// A Bootstrap breadcrumb list that keeps a fixed number of leading items visible and collapses
/// the remaining items behind a toggle. Bootstrap has no built-in breadcrumb overflow, so the
/// collapsed items are wrapped in a Bootstrap collapse region and a minimal stylesheet handles
/// the flex layout.
/// </summary>
public sealed class BreadcrumbCollapseComponent : Component
{
    private const string DefaultToggleLabel = "...";

    private readonly int _keepVisible;
    private readonly BreadcrumbItemComponent[] _items;
    private string _toggleLabel = DefaultToggleLabel;
    private string? _separator;

    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbCollapseComponent"/> class.
    /// </summary>
    /// <param name="keepVisible">The number of leading items to keep visible.</param>
    /// <param name="items">The breadcrumb items in order.</param>
    public BreadcrumbCollapseComponent(int keepVisible, params BreadcrumbItemComponent[] items)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(keepVisible);
        ArgumentNullException.ThrowIfNull(items);
        _keepVisible = keepVisible;
        _items = items;
    }

    /// <summary>
    /// Sets the label shown on the toggle that reveals the collapsed items.
    /// </summary>
    /// <param name="label">The toggle label.</param>
    /// <returns>The current instance for method chaining.</returns>
    public BreadcrumbCollapseComponent ToggleLabel(string label)
    {
        ArgumentNullException.ThrowIfNull(label);
        _toggleLabel = label;
        return this;
    }

    /// <summary>
    /// Sets a custom separator between breadcrumb items.
    /// </summary>
    /// <param name="separator">The separator to display between items.</param>
    /// <returns>The current instance for method chaining.</returns>
    public BreadcrumbCollapseComponent Separator(string separator)
    {
        ArgumentNullException.ThrowIfNull(separator);
        _separator = separator;
        return this;
    }

    /// <inheritdoc/>
    public override Node Render()
    {
        var visibleCount = Math.Min(_keepVisible, _items.Length);
        var visible = _items.Take(visibleCount).Cast<Node>().ToArray();
        var collapsed = _items.Skip(visibleCount).Cast<Node>().ToArray();

        var list = new BreadcrumbListComponent();
        if (_separator is not null)
            list.Separator(_separator);

        list.AddChildren(visible);

        if (collapsed.Length == 0)
            return new Fragment(new StyleElement(BreadcrumbCollapseStyles.Css), list);

        var groupId = "breadcrumb-collapse-" + Guid.NewGuid().ToString("N")[..8];

        // Bootstrap supports multi-target collapse via a class selector, so each collapsed
        // <li> carries the collapse classes. That keeps every <li> a direct child of the <ol>,
        // which is what Bootstrap's flex layout expects, and needs no custom JavaScript.
        for (var i = 0; i < collapsed.Length; i++)
        {
            if (collapsed[i] is BreadcrumbItemComponent item)
                item.Class("collapse breadcrumb-collapsed").Id($"{groupId}-{i + 1}");
        }

        var toggle = new AnchorElement(_toggleLabel)
            .Class("breadcrumb-toggle")
            .Href($"#{groupId}-1")
            .Data("bs-toggle", "collapse")
            .Data("bs-target", ".breadcrumb-collapsed")
            .Aria("expanded", "false")
            .Aria("controls", groupId);

        list.AddChild(new BreadcrumbItemComponent(toggle).Class("breadcrumb-toggle-item"));
        list.AddChildren(collapsed);

        return new Fragment(new StyleElement(BreadcrumbCollapseStyles.Css), list);
    }
}

/// <summary>
/// Minimal stylesheet for the collapsible breadcrumb list.
/// </summary>
internal static class BreadcrumbCollapseStyles
{
    public const string Css = """
        .breadcrumb-collapsed { display: none; }
        .breadcrumb-collapsed.show { display: flex; }
        .breadcrumb-toggle { cursor: pointer; }
        .breadcrumb-toggle-item:has(~ .breadcrumb-collapsed.show) { display: none; }
        """;
}
