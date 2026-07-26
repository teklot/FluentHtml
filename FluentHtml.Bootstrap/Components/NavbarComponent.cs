using FluentHtml.Elements;
using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap navbar component for creating responsive navigation headers.
/// </summary>
public sealed class NavbarComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the navbar.</param>
    public NavbarComponent(params Node[] children) : base(children) { SetTag("nav"); Class("navbar"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the navbar.</param>
    public NavbarComponent(string textContent) : base(textContent) { SetTag("nav"); Class("navbar"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarComponent"/> class.
    /// </summary>
    public NavbarComponent() { SetTag("nav"); Class("navbar"); }

    /// <summary>
    /// Expands the navbar at the small breakpoint.
    /// </summary>
    /// <returns>The current <see cref="NavbarComponent"/> instance.</returns>
    public NavbarComponent ExpandSm() => (NavbarComponent)Class("navbar-expand-sm");

    /// <summary>
    /// Expands the navbar at the medium breakpoint.
    /// </summary>
    /// <returns>The current <see cref="NavbarComponent"/> instance.</returns>
    public NavbarComponent ExpandMd() => (NavbarComponent)Class("navbar-expand-md");

    /// <summary>
    /// Expands the navbar at the large breakpoint.
    /// </summary>
    /// <returns>The current <see cref="NavbarComponent"/> instance.</returns>
    public NavbarComponent ExpandLg() => (NavbarComponent)Class("navbar-expand-lg");

    /// <summary>
    /// Expands the navbar at the extra-large breakpoint.
    /// </summary>
    /// <returns>The current <see cref="NavbarComponent"/> instance.</returns>
    public NavbarComponent ExpandXl() => (NavbarComponent)Class("navbar-expand-xl");

    /// <summary>
    /// Expands the navbar at the double extra-large breakpoint.
    /// </summary>
    /// <returns>The current <see cref="NavbarComponent"/> instance.</returns>
    public NavbarComponent ExpandXxl() => (NavbarComponent)Class("navbar-expand-xxl");

    /// <summary>
    /// Applies the light navbar color scheme.
    /// </summary>
    /// <returns>The current <see cref="NavbarComponent"/> instance.</returns>
    public NavbarComponent Light() => (NavbarComponent)Class("navbar-light");

    /// <summary>
    /// Applies the dark navbar color scheme.
    /// </summary>
    /// <returns>The current <see cref="NavbarComponent"/> instance.</returns>
    public NavbarComponent Dark() => (NavbarComponent)Class("navbar-dark");

    /// <summary>
    /// Fixes the navbar to the top of the viewport.
    /// </summary>
    /// <returns>The current <see cref="NavbarComponent"/> instance.</returns>
    public NavbarComponent FixedTop() => (NavbarComponent)Class("fixed-top");

    /// <summary>
    /// Fixes the navbar to the bottom of the viewport.
    /// </summary>
    /// <returns>The current <see cref="NavbarComponent"/> instance.</returns>
    public NavbarComponent FixedBottom() => (NavbarComponent)Class("fixed-bottom");

    /// <summary>
    /// Makes the navbar stick to the top of its containing element when scrolling.
    /// </summary>
    /// <returns>The current <see cref="NavbarComponent"/> instance.</returns>
    public NavbarComponent StickyTop() => (NavbarComponent)Class("sticky-top");

    /// <summary>
    /// Wraps navbar content in a fixed-width container.
    /// </summary>
    /// <returns>The current <see cref="NavbarComponent"/> instance.</returns>
    public NavbarComponent Container() => (NavbarComponent)Class("container");

    /// <summary>
    /// Wraps navbar content in a full-width container.
    /// </summary>
    /// <returns>The current <see cref="NavbarComponent"/> instance.</returns>
    public NavbarComponent ContainerFluid() => (NavbarComponent)Class("container-fluid");
}

/// <summary>
/// A Bootstrap navbar brand component for displaying the site logo or name.
/// </summary>
public sealed class NavbarBrandComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarBrandComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the navbar brand.</param>
    public NavbarBrandComponent(params Node[] children) : base(children) { SetTag("a"); Class("navbar-brand"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarBrandComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the navbar brand.</param>
    public NavbarBrandComponent(string textContent) : base(textContent) { SetTag("a"); Class("navbar-brand"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarBrandComponent"/> class.
    /// </summary>
    public NavbarBrandComponent() { SetTag("a"); Class("navbar-brand"); }

    /// <summary>
    /// Sets the href attribute for the navbar brand link.
    /// </summary>
    /// <param name="href">The URL target of the link.</param>
    /// <returns>The current <see cref="NavbarBrandComponent"/> instance.</returns>
    public NavbarBrandComponent Href(string href) { Attributes.Set("href", href); return this; }
}

/// <summary>
/// A Bootstrap navbar navigation list component.
/// </summary>
public sealed class NavbarNavComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarNavComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the navbar nav.</param>
    public NavbarNavComponent(params Node[] children) : base(children) { SetTag("ul"); Class("navbar-nav"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarNavComponent"/> class.
    /// </summary>
    public NavbarNavComponent() { SetTag("ul"); Class("navbar-nav"); }
}

/// <summary>
/// A Bootstrap navbar nav item component representing a single navigation entry.
/// </summary>
public sealed class NavbarNavItemComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarNavItemComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the navbar nav item.</param>
    public NavbarNavItemComponent(params Node[] children) : base(children) { SetTag("li"); Class("nav-item"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarNavItemComponent"/> class.
    /// </summary>
    public NavbarNavItemComponent() { SetTag("li"); Class("nav-item"); }
}

/// <summary>
/// A Bootstrap navbar collapse component that contains collapsible content toggled by the navbar toggler.
/// </summary>
public sealed class NavbarCollapseComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarCollapseComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the navbar collapse.</param>
    public NavbarCollapseComponent(params Node[] children) : base(children) { SetTag("div"); Class("collapse"); Class("navbar-collapse"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarCollapseComponent"/> class.
    /// </summary>
    public NavbarCollapseComponent() { SetTag("div"); Class("collapse"); Class("navbar-collapse"); }
}

/// <summary>
/// A Bootstrap navbar text component for displaying non-interactive text in the navbar.
/// </summary>
public sealed class NavbarTextComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarTextComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the navbar text.</param>
    public NavbarTextComponent(params Node[] children) : base(children) { SetTag("span"); Class("navbar-text"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarTextComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the navbar text.</param>
    public NavbarTextComponent(string textContent) : base(textContent) { SetTag("span"); Class("navbar-text"); }
}

/// <summary>
/// A Bootstrap navbar toggler component that controls the collapse of the navbar on small viewports.
/// </summary>
public sealed class NavbarTogglerComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavbarTogglerComponent"/> class with a toggler icon.
    /// </summary>
    public NavbarTogglerComponent() : base(new SpanElement().Class("navbar-toggler-icon")) { SetTag("button"); Class("navbar-toggler"); Attributes.Set("type", "button"); Attributes.Set("data-bs-toggle", "collapse"); }

    /// <summary>
    /// Sets the data-bs-target attribute to specify the collapsible element to toggle.
    /// </summary>
    /// <param name="target">The target selector (typically a CSS ID).</param>
    /// <returns>The current <see cref="NavbarTogglerComponent"/> instance.</returns>
    public NavbarTogglerComponent DataTarget(string target) => (NavbarTogglerComponent)Data("bs-target", target);

    /// <summary>
    /// Sets the aria-controls attribute to reference the collapsible element.
    /// </summary>
    /// <param name="id">The ID of the collapsible element controlled by this toggler.</param>
    /// <returns>The current <see cref="NavbarTogglerComponent"/> instance.</returns>
    public NavbarTogglerComponent Controls(string id) { Attributes.Set("aria-controls", id); return this; }

    /// <summary>
    /// Sets the aria-expanded attribute to indicate whether the navbar is expanded.
    /// </summary>
    /// <param name="expanded">True if the navbar is expanded; otherwise false.</param>
    /// <returns>The current <see cref="NavbarTogglerComponent"/> instance.</returns>
    public NavbarTogglerComponent Expanded(bool expanded)
    {
        Attributes.Set("aria-expanded", expanded.ToString().ToLowerInvariant());
        return this;
    }

    /// <summary>
    /// Sets the aria-label attribute for accessibility.
    /// </summary>
    /// <param name="label">The aria-label text for the toggler button.</param>
    /// <returns>The current <see cref="NavbarTogglerComponent"/> instance.</returns>
    public NavbarTogglerComponent Label(string label) { Attributes.Set("aria-label", label); return this; }
}

/// <summary>
/// Extension methods for creating Bootstrap navbar components.
/// </summary>
public static class NavbarExtensions
{
    /// <summary>
    /// Creates a new <see cref="NavbarComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="NavbarComponent"/> instance.</returns>
    public static NavbarComponent Navbar(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="NavbarComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="NavbarComponent"/> instance.</returns>
    public static NavbarComponent Navbar() => new();

    /// <summary>
    /// Creates a new <see cref="NavbarBrandComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="NavbarBrandComponent"/> instance.</returns>
    public static NavbarBrandComponent NavbarBrand(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="NavbarBrandComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the brand.</param>
    /// <returns>A new <see cref="NavbarBrandComponent"/> instance.</returns>
    public static NavbarBrandComponent NavbarBrand(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new <see cref="NavbarNavComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="NavbarNavComponent"/> instance.</returns>
    public static NavbarNavComponent NavbarNav(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="NavbarNavComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="NavbarNavComponent"/> instance.</returns>
    public static NavbarNavComponent NavbarNav() => new();

    /// <summary>
    /// Creates a new <see cref="NavbarNavItemComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="NavbarNavItemComponent"/> instance.</returns>
    public static NavbarNavItemComponent NavbarNavItem(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="NavbarNavItemComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="NavbarNavItemComponent"/> instance.</returns>
    public static NavbarNavItemComponent NavbarNavItem() => new();

    /// <summary>
    /// Creates a new <see cref="NavbarCollapseComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="NavbarCollapseComponent"/> instance.</returns>
    public static NavbarCollapseComponent NavbarCollapse(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="NavbarCollapseComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="NavbarCollapseComponent"/> instance.</returns>
    public static NavbarCollapseComponent NavbarCollapse() => new();

    /// <summary>
    /// Creates a new <see cref="NavbarTextComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="NavbarTextComponent"/> instance.</returns>
    public static NavbarTextComponent NavbarText(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="NavbarTextComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="NavbarTextComponent"/> instance.</returns>
    public static NavbarTextComponent NavbarText(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new <see cref="NavbarTogglerComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="NavbarTogglerComponent"/> instance.</returns>
    public static NavbarTogglerComponent NavbarToggler() => new();
}
