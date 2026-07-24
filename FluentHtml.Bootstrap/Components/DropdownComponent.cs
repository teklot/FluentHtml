using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

public sealed class DropdownComponent : Element
{
    public DropdownComponent(params Node[] children) : base(children) { SetTag("div"); Class("dropdown"); }

    public DropdownComponent() { SetTag("div"); Class("dropdown"); }

    public DropdownComponent Dropup() => (DropdownComponent)Class("dropup");

    public DropdownComponent Dropend() => (DropdownComponent)Class("dropend");

    public DropdownComponent Dropstart() => (DropdownComponent)Class("dropstart");

    public DropdownComponent Center() => (DropdownComponent)Class("dropdown-center");

    public DropdownComponent DropupCenter() => (DropdownComponent)Class("dropup-center");
}

public sealed class DropdownToggleButtonComponent : Element
{
    public DropdownToggleButtonComponent(string textContent) : base(textContent)
    {
        SetTag("button");
        Class("btn dropdown-toggle");
        Attributes.Set("type", "button");
    }

    public DropdownToggleButtonComponent(params Node[] children) : base(children)
    {
        SetTag("button");
        Class("btn dropdown-toggle");
        Attributes.Set("type", "button");
    }

    public DropdownToggleButtonComponent()
    {
        SetTag("button");
        Class("btn dropdown-toggle");
        Attributes.Set("type", "button");
    }

    public DropdownToggleButtonComponent DataToggle(string toggle) => (DropdownToggleButtonComponent)Data("bs-toggle", toggle);

    public DropdownToggleButtonComponent DataBsToggle(string toggle) => (DropdownToggleButtonComponent)Data("bs-toggle", toggle);

    public DropdownToggleButtonComponent DataTarget(string target) => (DropdownToggleButtonComponent)Data("bs-target", target);

    public DropdownToggleButtonComponent DataBsTarget(string target) => (DropdownToggleButtonComponent)Data("bs-target", target);

    public DropdownToggleButtonComponent Expanded(bool expanded) { Attributes.Set("aria-expanded", expanded.ToString().ToLowerInvariant()); return this; }

    public DropdownToggleButtonComponent Split() => (DropdownToggleButtonComponent)Class("dropdown-toggle-split");
}

public sealed class DropdownMenuComponent : Element
{
    public DropdownMenuComponent(params Node[] children) : base(children) { SetTag("ul"); Class("dropdown-menu"); }

    public DropdownMenuComponent() { SetTag("ul"); Class("dropdown-menu"); }

    public DropdownMenuComponent Dark() => (DropdownMenuComponent)Class("dropdown-menu-dark");

    public DropdownMenuComponent AlignEnd() => (DropdownMenuComponent)Class("dropdown-menu-end");

    public DropdownMenuComponent AlignStart() => (DropdownMenuComponent)Class("dropdown-menu-start");

    public DropdownMenuComponent AlignRight() => (DropdownMenuComponent)Class("dropdown-menu-end");

    public DropdownMenuComponent AlignLeft() => (DropdownMenuComponent)Class("dropdown-menu-start");
}

public sealed class DropdownItemComponent : Element
{
    public DropdownItemComponent(params Node[] children) : base(children) { SetTag("li"); }

    public DropdownItemComponent(string textContent) : base(textContent) { SetTag("li"); }

    public DropdownItemComponent() { SetTag("li"); }
}

public sealed class DropdownLinkItemComponent : Element
{
    public DropdownLinkItemComponent(params Node[] children) : base(children) { SetTag("a"); Class("dropdown-item"); }

    public DropdownLinkItemComponent(string textContent) : base(textContent) { SetTag("a"); Class("dropdown-item"); }

    public DropdownLinkItemComponent() { SetTag("a"); Class("dropdown-item"); }

    public DropdownLinkItemComponent Href(string href) { Attributes.Set("href", href); return this; }

    public DropdownLinkItemComponent Active() => (DropdownLinkItemComponent)Class("active");

    public new DropdownLinkItemComponent Disabled() => (DropdownLinkItemComponent)Class("disabled");
}

public sealed class DropdownHeaderComponent : Element
{
    public DropdownHeaderComponent(string textContent) : base(textContent) { SetTag("h6"); Class("dropdown-header"); }

    public DropdownHeaderComponent(params Node[] children) : base(children) { SetTag("h6"); Class("dropdown-header"); }
}

public sealed class DropdownDividerComponent : Element
{
    public DropdownDividerComponent() { SetTag("hr"); Class("dropdown-divider"); }
}

public static class DropdownExtensions
{
    public static DropdownComponent Dropdown(params Node[] children) => new(children);

    public static DropdownComponent Dropdown() => new();

    public static DropdownToggleButtonComponent DropdownToggle(string textContent) => new(textContent);

    public static DropdownToggleButtonComponent DropdownToggle(params Node[] children) => new(children);

    public static DropdownToggleButtonComponent DropdownToggle() => new();

    public static DropdownMenuComponent DropdownMenu(params Node[] children) => new(children);

    public static DropdownMenuComponent DropdownMenu() => new();

    public static DropdownLinkItemComponent DropdownItem(string textContent) => new(textContent);

    public static DropdownLinkItemComponent DropdownItem(params Node[] children) => new(children);

    public static DropdownLinkItemComponent DropdownItem() => new();

    public static DropdownHeaderComponent DropdownHeader(string textContent) => new(textContent);

    public static DropdownDividerComponent DropdownDivider() => new();
}
