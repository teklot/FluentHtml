using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

public sealed class BreadcrumbComponent : Element
{
    public BreadcrumbComponent(params Node[] children) : base(children) { SetTag("nav"); }

    public BreadcrumbComponent() { SetTag("nav"); }

    public BreadcrumbComponent AriaLabel(string label) { Attributes.Set("aria-label", label); return this; }
}

public sealed class BreadcrumbListComponent : Element
{
    public BreadcrumbListComponent(params Node[] children) : base(children) { SetTag("ol"); Class("breadcrumb"); }

    public BreadcrumbListComponent() { SetTag("ol"); Class("breadcrumb"); }

    public BreadcrumbListComponent Small() => (BreadcrumbListComponent)Class("breadcrumb-item");
}

public sealed class BreadcrumbItemComponent : Element
{
    public BreadcrumbItemComponent(params Node[] children) : base(children) { SetTag("li"); Class("breadcrumb-item"); }

    public BreadcrumbItemComponent(string textContent) : base(textContent) { SetTag("li"); Class("breadcrumb-item"); }

    public BreadcrumbItemComponent() { SetTag("li"); Class("breadcrumb-item"); }

    public BreadcrumbItemComponent Active() => (BreadcrumbItemComponent)Class("active");

    public BreadcrumbItemComponent AriaCurrent(string value) { Attributes.Set("aria-current", value); return this; }
}

public sealed class BreadcrumbLinkComponent : Element
{
    public BreadcrumbLinkComponent(params Node[] children) : base(children) => SetTag("a");

    public BreadcrumbLinkComponent(string textContent) : base(textContent) => SetTag("a");

    public BreadcrumbLinkComponent() => SetTag("a");

    public BreadcrumbLinkComponent Href(string href) { Attributes.Set("href", href); return this; }
}

public static class BreadcrumbExtensions
{
    public static BreadcrumbComponent Breadcrumb(params Node[] children) => new(children);

    public static BreadcrumbComponent Breadcrumb() => new();

    public static BreadcrumbListComponent BreadcrumbList(params Node[] children) => new(children);

    public static BreadcrumbListComponent BreadcrumbList() => new();

    public static BreadcrumbItemComponent BreadcrumbItem(params Node[] children) => new(children);

    public static BreadcrumbItemComponent BreadcrumbItem(string textContent) => new(textContent);

    public static BreadcrumbItemComponent BreadcrumbItem() => new();

    public static BreadcrumbLinkComponent BreadcrumbLink(params Node[] children) => new(children);

    public static BreadcrumbLinkComponent BreadcrumbLink(string textContent) => new(textContent);

    public static BreadcrumbLinkComponent BreadcrumbLink() => new();
}
