using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap pagination container component that wraps the pagination list.
/// </summary>
public sealed class PaginationComponent : Element<PaginationComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PaginationComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the pagination.</param>
    public PaginationComponent(params Node[] children) : base(children) { SetTag("nav"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="PaginationComponent"/> class.
    /// </summary>
    public PaginationComponent() { SetTag("nav"); }

    /// <summary>
    /// Sets the aria-label attribute for accessibility.
    /// </summary>
    /// <param name="label">The aria-label value (e.g., "Page navigation").</param>
    /// <returns>The current <see cref="PaginationComponent"/> instance.</returns>
    public PaginationComponent AriaLabel(string label) { Attributes.Set("aria-label", label); return this; }
}

/// <summary>
/// A Bootstrap pagination list component rendered as an unordered list.
/// </summary>
public sealed class PaginationListComponent : Element<PaginationListComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PaginationListComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the pagination list.</param>
    public PaginationListComponent(params Node[] children) : base(children) { SetTag("ul"); Class("pagination"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="PaginationListComponent"/> class.
    /// </summary>
    public PaginationListComponent() { SetTag("ul"); Class("pagination"); }

    /// <summary>
    /// Applies the small pagination style.
    /// </summary>
    /// <returns>The current <see cref="PaginationListComponent"/> instance.</returns>
    public PaginationListComponent Small() => Class("pagination-sm");

    /// <summary>
    /// Applies the large pagination style.
    /// </summary>
    /// <returns>The current <see cref="PaginationListComponent"/> instance.</returns>
    public PaginationListComponent Large() => Class("pagination-lg");

    /// <summary>
    /// Centers the pagination items.
    /// </summary>
    /// <returns>The current <see cref="PaginationListComponent"/> instance.</returns>
    public PaginationListComponent JustifyCenter() => Class("justify-content-center");

    /// <summary>
    /// Aligns the pagination items to the end.
    /// </summary>
    /// <returns>The current <see cref="PaginationListComponent"/> instance.</returns>
    public PaginationListComponent JustifyEnd() => Class("justify-content-end");

    /// <summary>
    /// Distributes pagination items with space between them.
    /// </summary>
    /// <returns>The current <see cref="PaginationListComponent"/> instance.</returns>
    public PaginationListComponent JustifyBetween() => Class("justify-content-between");
}

/// <summary>
/// A Bootstrap page item component representing a single pagination item.
/// </summary>
public sealed class PageItemComponent : Element<PageItemComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PageItemComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the page item.</param>
    public PageItemComponent(params Node[] children) : base(children) { SetTag("li"); Class("page-item"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageItemComponent"/> class.
    /// </summary>
    public PageItemComponent() { SetTag("li"); Class("page-item"); }

    /// <summary>
    /// Marks this page item as the active (current) page.
    /// </summary>
    /// <returns>The current <see cref="PageItemComponent"/> instance.</returns>
    public PageItemComponent Active() => Class("active");

    /// <summary>
    /// Disables this page item, preventing user interaction.
    /// </summary>
    /// <returns>The current <see cref="PageItemComponent"/> instance.</returns>
    public new PageItemComponent Disabled() => Class("disabled");
}

/// <summary>
/// A Bootstrap page link component for navigating between pages.
/// </summary>
public sealed class PageLinkComponent : Element<PageLinkComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PageLinkComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the page link.</param>
    public PageLinkComponent(params Node[] children) : base(children) { SetTag("a"); Class("page-link"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageLinkComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the page link (e.g., page number).</param>
    public PageLinkComponent(string textContent) : base(textContent) { SetTag("a"); Class("page-link"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageLinkComponent"/> class.
    /// </summary>
    public PageLinkComponent() { SetTag("a"); Class("page-link"); }

    /// <summary>
    /// Sets the href attribute for the page link.
    /// </summary>
    /// <param name="href">The URL target of the link.</param>
    /// <returns>The current <see cref="PageLinkComponent"/> instance.</returns>
    public PageLinkComponent Href(string href) { Attributes.Set("href", href); return this; }

    /// <summary>
    /// Sets the aria-label attribute for accessibility.
    /// </summary>
    /// <param name="label">The aria-label value (e.g., "Go to next page").</param>
    /// <returns>The current <see cref="PageLinkComponent"/> instance.</returns>
    public PageLinkComponent AriaLabel(string label) { Attributes.Set("aria-label", label); return this; }
}

/// <summary>
/// Extension methods for creating Bootstrap pagination components.
/// </summary>
public static class PaginationExtensions
{
    /// <summary>
    /// Creates a new <see cref="PaginationComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="PaginationComponent"/> instance.</returns>
    public static PaginationComponent Pagination(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="PaginationComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="PaginationComponent"/> instance.</returns>
    public static PaginationComponent Pagination() => new();

    /// <summary>
    /// Creates a new <see cref="PaginationListComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="PaginationListComponent"/> instance.</returns>
    public static PaginationListComponent PaginationList(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="PaginationListComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="PaginationListComponent"/> instance.</returns>
    public static PaginationListComponent PaginationList() => new();

    /// <summary>
    /// Creates a new <see cref="PageItemComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="PageItemComponent"/> instance.</returns>
    public static PageItemComponent PageItem(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="PageItemComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="PageItemComponent"/> instance.</returns>
    public static PageItemComponent PageItem() => new();

    /// <summary>
    /// Creates a new <see cref="PageLinkComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="PageLinkComponent"/> instance.</returns>
    public static PageLinkComponent PageLink(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="PageLinkComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the page link.</param>
    /// <returns>A new <see cref="PageLinkComponent"/> instance.</returns>
    public static PageLinkComponent PageLink(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="PageLinkComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="PageLinkComponent"/> instance.</returns>
    public static PageLinkComponent PageLink() => new();
}
