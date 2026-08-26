using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A responsive split layout component with two panels.
/// Stacks vertically on mobile, side-by-side on desktop.
/// </summary>
public sealed class SplitLayoutComponent : Element<SplitLayoutComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SplitLayoutComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include (typically two panel elements).</param>
    public SplitLayoutComponent(params Node[] children) : base(children) { SetTag("div"); Class("d-flex flex-column flex-md-row"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="SplitLayoutComponent"/> class.
    /// </summary>
    public SplitLayoutComponent() { SetTag("div"); Class("d-flex flex-column flex-md-row"); }
}

/// <summary>
/// A split layout panel component.
/// </summary>
public sealed class SplitPanelComponent : Element<SplitPanelComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SplitPanelComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the panel.</param>
    public SplitPanelComponent(params Node[] children) : base(children) { SetTag("div"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="SplitPanelComponent"/> class.
    /// </summary>
    public SplitPanelComponent() { SetTag("div"); }

    /// <summary>
    /// Makes the panel fill available width.
    /// </summary>
    /// <returns>The current <see cref="SplitPanelComponent"/> instance.</returns>
    public SplitPanelComponent FlexGrow1() => Class("flex-grow-1");

    /// <summary>
    /// Sets a fixed width on the panel (desktop).
    /// </summary>
    /// <param name="width">The width value (e.g., "300px", "25%").</param>
    /// <returns>The current <see cref="SplitPanelComponent"/> instance.</returns>
    public SplitPanelComponent Width(string width) { Attributes.Set("style", $"width:{width}"); return this; }

    /// <summary>
    /// Sets a fixed height on the panel (mobile stacking).
    /// </summary>
    /// <param name="height">The height value (e.g., "50vh").</param>
    /// <returns>The current <see cref="SplitPanelComponent"/> instance.</returns>
    public SplitPanelComponent Height(string height) { Attributes.Set("style", $"height:{height}"); return this; }

    /// <summary>
    /// Adds a border to the panel.
    /// </summary>
    /// <param name="side">The border side ("start", "end", "top", "bottom").</param>
    /// <returns>The current <see cref="SplitPanelComponent"/> instance.</returns>
    public SplitPanelComponent Border(string side = "end") => Class($"border-{side}");
}

/// <summary>
/// A split layout divider component.
/// </summary>
public sealed class SplitDividerComponent : Element<SplitDividerComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SplitDividerComponent"/> class.
    /// </summary>
    public SplitDividerComponent() { SetTag("div"); Class("d-none d-md-block bg-border"); Attributes.Set("style", "width:1px"); }
}

/// <summary>
/// Extension methods for creating split layout components.
/// </summary>
public static class SplitLayoutExtensions
{
    /// <summary>
    /// Creates a new <see cref="SplitLayoutComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="SplitLayoutComponent"/> instance.</returns>
    public static SplitLayoutComponent SplitLayout(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="SplitLayoutComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="SplitLayoutComponent"/> instance.</returns>
    public static SplitLayoutComponent SplitLayout() => new();

    /// <summary>
    /// Creates a new <see cref="SplitPanelComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="SplitPanelComponent"/> instance.</returns>
    public static SplitPanelComponent SplitPanel(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="SplitPanelComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="SplitPanelComponent"/> instance.</returns>
    public static SplitPanelComponent SplitPanel() => new();

    /// <summary>
    /// Creates a new <see cref="SplitDividerComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="SplitDividerComponent"/> instance.</returns>
    public static SplitDividerComponent SplitDivider() => new();
}
