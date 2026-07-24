using FluentHtml.Elements;
using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

public sealed class NavbarComponent : Element
{
    public NavbarComponent(params Node[] children) : base(children) { SetTag("nav"); Class("navbar"); }

    public NavbarComponent(string textContent) : base(textContent) { SetTag("nav"); Class("navbar"); }

    public NavbarComponent() { SetTag("nav"); Class("navbar"); }

    public NavbarComponent ExpandSm() => (NavbarComponent)Class("navbar-expand-sm");

    public NavbarComponent ExpandMd() => (NavbarComponent)Class("navbar-expand-md");

    public NavbarComponent ExpandLg() => (NavbarComponent)Class("navbar-expand-lg");

    public NavbarComponent ExpandXl() => (NavbarComponent)Class("navbar-expand-xl");

    public NavbarComponent ExpandXxl() => (NavbarComponent)Class("navbar-expand-xxl");

    public NavbarComponent Light() => (NavbarComponent)Class("navbar-light");

    public NavbarComponent Dark() => (NavbarComponent)Class("navbar-dark");

    public NavbarComponent FixedTop() => (NavbarComponent)Class("fixed-top");

    public NavbarComponent FixedBottom() => (NavbarComponent)Class("fixed-bottom");

    public NavbarComponent StickyTop() => (NavbarComponent)Class("sticky-top");

    public NavbarComponent Container() => (NavbarComponent)Class("container");

    public NavbarComponent ContainerFluid() => (NavbarComponent)Class("container-fluid");
}

public sealed class NavbarBrandComponent : Element
{
    public NavbarBrandComponent(params Node[] children) : base(children) { SetTag("a"); Class("navbar-brand"); }

    public NavbarBrandComponent(string textContent) : base(textContent) { SetTag("a"); Class("navbar-brand"); }

    public NavbarBrandComponent() { SetTag("a"); Class("navbar-brand"); }

    public NavbarBrandComponent Href(string href) { Attributes.Set("href", href); return this; }
}

public sealed class NavbarNavComponent : Element
{
    public NavbarNavComponent(params Node[] children) : base(children) { SetTag("ul"); Class("navbar-nav"); }

    public NavbarNavComponent() { SetTag("ul"); Class("navbar-nav"); }
}

public sealed class NavbarNavItemComponent : Element
{
    public NavbarNavItemComponent(params Node[] children) : base(children) { SetTag("li"); Class("nav-item"); }

    public NavbarNavItemComponent() { SetTag("li"); Class("nav-item"); }
}

public sealed class NavbarCollapseComponent : Element
{
    public NavbarCollapseComponent(params Node[] children) : base(children) { SetTag("div"); Class("collapse"); Class("navbar-collapse"); }

    public NavbarCollapseComponent() { SetTag("div"); Class("collapse"); Class("navbar-collapse"); }
}

public sealed class NavbarTextComponent : Element
{
    public NavbarTextComponent(params Node[] children) : base(children) { SetTag("span"); Class("navbar-text"); }

    public NavbarTextComponent(string textContent) : base(textContent) { SetTag("span"); Class("navbar-text"); }
}

public sealed class NavbarTogglerComponent : Element
{
    public NavbarTogglerComponent() : base(new SpanElement().Class("navbar-toggler-icon")) { SetTag("button"); Class("navbar-toggler"); Attributes.Set("type", "button"); Attributes.Set("data-bs-toggle", "collapse"); }

    public NavbarTogglerComponent DataTarget(string target) => (NavbarTogglerComponent)Data("bs-target", target);

    public NavbarTogglerComponent Controls(string id) { Attributes.Set("aria-controls", id); return this; }

    public NavbarTogglerComponent Expanded(bool expanded)
    {
        Attributes.Set("aria-expanded", expanded.ToString().ToLowerInvariant());
        return this;
    }

    public NavbarTogglerComponent Label(string label) { Attributes.Set("aria-label", label); return this; }
}

public static class NavbarExtensions
{
    public static NavbarComponent Navbar(params Node[] children) => new(children);

    public static NavbarComponent Navbar() => new();

    public static NavbarBrandComponent NavbarBrand(params Node[] children) => new(children);

    public static NavbarBrandComponent NavbarBrand(string textContent) => new(textContent);

    public static NavbarNavComponent NavbarNav(params Node[] children) => new(children);

    public static NavbarNavComponent NavbarNav() => new();

    public static NavbarNavItemComponent NavbarNavItem(params Node[] children) => new(children);

    public static NavbarNavItemComponent NavbarNavItem() => new();

    public static NavbarCollapseComponent NavbarCollapse(params Node[] children) => new(children);

    public static NavbarCollapseComponent NavbarCollapse() => new();

    public static NavbarTextComponent NavbarText(params Node[] children) => new(children);

    public static NavbarTextComponent NavbarText(string textContent) => new(textContent);

    public static NavbarTogglerComponent NavbarToggler() => new();
}
