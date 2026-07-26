using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap dropdown container component that wraps a toggle button and menu.
/// </summary>
public sealed class DropdownComponent : Element<DropdownComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the dropdown.</param>
    public DropdownComponent(params Node[] children) : base(children) { SetTag("div"); Class("dropdown"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownComponent"/> class.
    /// </summary>
    public DropdownComponent() { SetTag("div"); Class("dropdown"); }

    /// <summary>
    /// Makes the dropdown drop upward.
    /// </summary>
    /// <returns>The current <see cref="DropdownComponent"/> instance.</returns>
    public DropdownComponent Dropup() => Class("dropup");

    /// <summary>
    /// Makes the dropdown drop to the end (right in LTR).
    /// </summary>
    /// <returns>The current <see cref="DropdownComponent"/> instance.</returns>
    public DropdownComponent Dropend() => Class("dropend");

    /// <summary>
    /// Makes the dropdown drop to the start (left in LTR).
    /// </summary>
    /// <returns>The current <see cref="DropdownComponent"/> instance.</returns>
    public DropdownComponent Dropstart() => Class("dropstart");

    /// <summary>
    /// Centers the dropdown menu relative to its toggle.
    /// </summary>
    /// <returns>The current <see cref="DropdownComponent"/> instance.</returns>
    public DropdownComponent Center() => Class("dropdown-center");

    /// <summary>
    /// Centers an upward-opening dropdown menu relative to its toggle.
    /// </summary>
    /// <returns>The current <see cref="DropdownComponent"/> instance.</returns>
    public DropdownComponent DropupCenter() => Class("dropup-center");
}

/// <summary>
/// A Bootstrap dropdown toggle button component that controls the visibility of the dropdown menu.
/// </summary>
public sealed class DropdownToggleButtonComponent : Element<DropdownToggleButtonComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownToggleButtonComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the toggle button.</param>
    public DropdownToggleButtonComponent(string textContent) : base(textContent)
    {
        SetTag("button");
        Class("btn dropdown-toggle");
        Attributes.Set("type", "button");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownToggleButtonComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the toggle button.</param>
    public DropdownToggleButtonComponent(params Node[] children) : base(children)
    {
        SetTag("button");
        Class("btn dropdown-toggle");
        Attributes.Set("type", "button");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownToggleButtonComponent"/> class.
    /// </summary>
    public DropdownToggleButtonComponent()
    {
        SetTag("button");
        Class("btn dropdown-toggle");
        Attributes.Set("type", "button");
    }

    /// <summary>
    /// Sets the data-bs-toggle attribute for the toggle button.
    /// </summary>
    /// <param name="toggle">The toggle value.</param>
    /// <returns>The current <see cref="DropdownToggleButtonComponent"/> instance.</returns>
    public DropdownToggleButtonComponent DataToggle(string toggle) => Data("bs-toggle", toggle);

    /// <summary>
    /// Sets the data-bs-toggle attribute for the toggle button.
    /// </summary>
    /// <param name="toggle">The toggle value.</param>
    /// <returns>The current <see cref="DropdownToggleButtonComponent"/> instance.</returns>
    public DropdownToggleButtonComponent DataBsToggle(string toggle) => Data("bs-toggle", toggle);

    /// <summary>
    /// Sets the data-bs-target attribute to specify the target dropdown menu.
    /// </summary>
    /// <param name="target">The target selector (typically a CSS ID).</param>
    /// <returns>The current <see cref="DropdownToggleButtonComponent"/> instance.</returns>
    public DropdownToggleButtonComponent DataTarget(string target) => Data("bs-target", target);

    /// <summary>
    /// Sets the data-bs-target attribute to specify the target dropdown menu.
    /// </summary>
    /// <param name="target">The target selector (typically a CSS ID).</param>
    /// <returns>The current <see cref="DropdownToggleButtonComponent"/> instance.</returns>
    public DropdownToggleButtonComponent DataBsTarget(string target) => Data("bs-target", target);

    /// <summary>
    /// Sets the aria-expanded attribute to indicate whether the dropdown is expanded.
    /// </summary>
    /// <param name="expanded">True if the dropdown is expanded; otherwise false.</param>
    /// <returns>The current <see cref="DropdownToggleButtonComponent"/> instance.</returns>
    public DropdownToggleButtonComponent Expanded(bool expanded) { Attributes.Set("aria-expanded", expanded.ToString().ToLowerInvariant()); return this; }

    /// <summary>
    /// Applies the split button style, showing only the toggle caret.
    /// </summary>
    /// <returns>The current <see cref="DropdownToggleButtonComponent"/> instance.</returns>
    public DropdownToggleButtonComponent Split() => Class("dropdown-toggle-split");
}

/// <summary>
/// A Bootstrap dropdown menu component containing the dropdown items.
/// </summary>
public sealed class DropdownMenuComponent : Element<DropdownMenuComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownMenuComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the dropdown menu.</param>
    public DropdownMenuComponent(params Node[] children) : base(children) { SetTag("ul"); Class("dropdown-menu"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownMenuComponent"/> class.
    /// </summary>
    public DropdownMenuComponent() { SetTag("ul"); Class("dropdown-menu"); }

    /// <summary>
    /// Applies the dark dropdown menu style.
    /// </summary>
    /// <returns>The current <see cref="DropdownMenuComponent"/> instance.</returns>
    public DropdownMenuComponent Dark() => Class("dropdown-menu-dark");

    /// <summary>
    /// Aligns the dropdown menu to the end of its container.
    /// </summary>
    /// <returns>The current <see cref="DropdownMenuComponent"/> instance.</returns>
    public DropdownMenuComponent AlignEnd() => Class("dropdown-menu-end");

    /// <summary>
    /// Aligns the dropdown menu to the start of its container.
    /// </summary>
    /// <returns>The current <see cref="DropdownMenuComponent"/> instance.</returns>
    public DropdownMenuComponent AlignStart() => Class("dropdown-menu-start");

    /// <summary>
    /// Aligns the dropdown menu to the right of its container.
    /// </summary>
    /// <returns>The current <see cref="DropdownMenuComponent"/> instance.</returns>
    public DropdownMenuComponent AlignRight() => Class("dropdown-menu-end");

    /// <summary>
    /// Aligns the dropdown menu to the left of its container.
    /// </summary>
    /// <returns>The current <see cref="DropdownMenuComponent"/> instance.</returns>
    public DropdownMenuComponent AlignLeft() => Class("dropdown-menu-start");
}

/// <summary>
/// A Bootstrap dropdown item component rendered as a list item wrapper.
/// </summary>
public sealed class DropdownItemComponent : Element<DropdownItemComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownItemComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the dropdown item.</param>
    public DropdownItemComponent(params Node[] children) : base(children) { SetTag("li"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownItemComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the dropdown item.</param>
    public DropdownItemComponent(string textContent) : base(textContent) { SetTag("li"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownItemComponent"/> class.
    /// </summary>
    public DropdownItemComponent() { SetTag("li"); }
}

/// <summary>
/// A Bootstrap dropdown link item component rendered as a clickable anchor element.
/// </summary>
public sealed class DropdownLinkItemComponent : Element<DropdownLinkItemComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownLinkItemComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the dropdown link item.</param>
    public DropdownLinkItemComponent(params Node[] children) : base(children) { SetTag("a"); Class("dropdown-item"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownLinkItemComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the dropdown link item.</param>
    public DropdownLinkItemComponent(string textContent) : base(textContent) { SetTag("a"); Class("dropdown-item"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownLinkItemComponent"/> class.
    /// </summary>
    public DropdownLinkItemComponent() { SetTag("a"); Class("dropdown-item"); }

    /// <summary>
    /// Sets the href attribute for the dropdown link item.
    /// </summary>
    /// <param name="href">The URL target of the link.</param>
    /// <returns>The current <see cref="DropdownLinkItemComponent"/> instance.</returns>
    public DropdownLinkItemComponent Href(string href) { Attributes.Set("href", href); return this; }

    /// <summary>
    /// Marks this dropdown item as the active selection.
    /// </summary>
    /// <returns>The current <see cref="DropdownLinkItemComponent"/> instance.</returns>
    public DropdownLinkItemComponent Active() => Class("active");

    /// <summary>
    /// Disables this dropdown item, preventing user interaction.
    /// </summary>
    /// <returns>The current <see cref="DropdownLinkItemComponent"/> instance.</returns>
    public new DropdownLinkItemComponent Disabled() => Class("disabled");
}

/// <summary>
/// A Bootstrap dropdown header component for labeling groups of items.
/// </summary>
public sealed class DropdownHeaderComponent : Element<DropdownHeaderComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownHeaderComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the dropdown header.</param>
    public DropdownHeaderComponent(string textContent) : base(textContent) { SetTag("h6"); Class("dropdown-header"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownHeaderComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the dropdown header.</param>
    public DropdownHeaderComponent(params Node[] children) : base(children) { SetTag("h6"); Class("dropdown-header"); }
}

/// <summary>
/// A Bootstrap dropdown divider component for visually separating groups of items.
/// </summary>
public sealed class DropdownDividerComponent : Element<DropdownDividerComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownDividerComponent"/> class.
    /// </summary>
    public DropdownDividerComponent() { SetTag("hr"); Class("dropdown-divider"); }
}

/// <summary>
/// Extension methods for creating Bootstrap dropdown components.
/// </summary>
public static class DropdownExtensions
{
    /// <summary>
    /// Creates a new <see cref="DropdownComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="DropdownComponent"/> instance.</returns>
    public static DropdownComponent Dropdown(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="DropdownComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="DropdownComponent"/> instance.</returns>
    public static DropdownComponent Dropdown() => new();

    /// <summary>
    /// Creates a new <see cref="DropdownToggleButtonComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the toggle button.</param>
    /// <returns>A new <see cref="DropdownToggleButtonComponent"/> instance.</returns>
    public static DropdownToggleButtonComponent DropdownToggle(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new <see cref="DropdownToggleButtonComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="DropdownToggleButtonComponent"/> instance.</returns>
    public static DropdownToggleButtonComponent DropdownToggle(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="DropdownToggleButtonComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="DropdownToggleButtonComponent"/> instance.</returns>
    public static DropdownToggleButtonComponent DropdownToggle() => new();

    /// <summary>
    /// Creates a new <see cref="DropdownMenuComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="DropdownMenuComponent"/> instance.</returns>
    public static DropdownMenuComponent DropdownMenu(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="DropdownMenuComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="DropdownMenuComponent"/> instance.</returns>
    public static DropdownMenuComponent DropdownMenu() => new();

    /// <summary>
    /// Creates a new <see cref="DropdownLinkItemComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the dropdown item.</param>
    /// <returns>A new <see cref="DropdownLinkItemComponent"/> instance.</returns>
    public static DropdownLinkItemComponent DropdownItem(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new <see cref="DropdownLinkItemComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="DropdownLinkItemComponent"/> instance.</returns>
    public static DropdownLinkItemComponent DropdownItem(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="DropdownLinkItemComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="DropdownLinkItemComponent"/> instance.</returns>
    public static DropdownLinkItemComponent DropdownItem() => new();

    /// <summary>
    /// Creates a new <see cref="DropdownHeaderComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the dropdown header.</param>
    /// <returns>A new <see cref="DropdownHeaderComponent"/> instance.</returns>
    public static DropdownHeaderComponent DropdownHeader(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new <see cref="DropdownDividerComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="DropdownDividerComponent"/> instance.</returns>
    public static DropdownDividerComponent DropdownDivider() => new();
}
