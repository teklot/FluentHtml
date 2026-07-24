using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

public sealed class PaginationComponent : Element
{
    public PaginationComponent(params Node[] children) : base(children) { SetTag("nav"); }

    public PaginationComponent() { SetTag("nav"); }

    public PaginationComponent AriaLabel(string label) { Attributes.Set("aria-label", label); return this; }
}

public sealed class PaginationListComponent : Element
{
    public PaginationListComponent(params Node[] children) : base(children) { SetTag("ul"); Class("pagination"); }

    public PaginationListComponent() { SetTag("ul"); Class("pagination"); }

    public PaginationListComponent Small() => (PaginationListComponent)Class("pagination-sm");

    public PaginationListComponent Large() => (PaginationListComponent)Class("pagination-lg");

    public PaginationListComponent JustifyCenter() => (PaginationListComponent)Class("justify-content-center");

    public PaginationListComponent JustifyEnd() => (PaginationListComponent)Class("justify-content-end");

    public PaginationListComponent JustifyBetween() => (PaginationListComponent)Class("justify-content-between");
}

public sealed class PageItemComponent : Element
{
    public PageItemComponent(params Node[] children) : base(children) { SetTag("li"); Class("page-item"); }

    public PageItemComponent() { SetTag("li"); Class("page-item"); }

    public PageItemComponent Active() => (PageItemComponent)Class("active");

    public new PageItemComponent Disabled() => (PageItemComponent)Class("disabled");
}

public sealed class PageLinkComponent : Element
{
    public PageLinkComponent(params Node[] children) : base(children) { SetTag("a"); Class("page-link"); }

    public PageLinkComponent(string textContent) : base(textContent) { SetTag("a"); Class("page-link"); }

    public PageLinkComponent() { SetTag("a"); Class("page-link"); }

    public PageLinkComponent Href(string href) { Attributes.Set("href", href); return this; }

    public PageLinkComponent AriaLabel(string label) { Attributes.Set("aria-label", label); return this; }
}

public static class PaginationExtensions
{
    public static PaginationComponent Pagination(params Node[] children) => new(children);

    public static PaginationComponent Pagination() => new();

    public static PaginationListComponent PaginationList(params Node[] children) => new(children);

    public static PaginationListComponent PaginationList() => new();

    public static PageItemComponent PageItem(params Node[] children) => new(children);

    public static PageItemComponent PageItem() => new();

    public static PageLinkComponent PageLink(params Node[] children) => new(children);

    public static PageLinkComponent PageLink(string textContent) => new(textContent);

    public static PageLinkComponent PageLink() => new();
}
