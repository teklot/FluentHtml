using FluentHtml.Elements;
using FluentHtml.Nodes;

namespace FluentHtml.Components;

/// <summary>
/// A standalone breadcrumb component that renders semantic <c>&lt;nav&gt;</c>, <c>&lt;ol&gt;</c>,
/// and <c>&lt;li&gt;</c> elements without any CSS framework dependency.
/// For Bootstrap-styled breadcrumbs, use the BreadcrumbComponent in the FluentHtml.Bootstrap package.
/// </summary>
public sealed class BreadcrumbComponent : Element<BreadcrumbComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbComponent"/> class with breadcrumb items.
    /// </summary>
    /// <param name="items">The breadcrumb items to include.</param>
    public BreadcrumbComponent(params Node[] items) : base(items) => SetTag("nav");
}

/// <summary>
/// A breadcrumb list component that renders as an <c>&lt;ol&gt;</c> element. Exposed so callers
/// can supply their own list element instead of relying on the factory's implicit wrapper.
/// </summary>
public sealed class BreadcrumbListComponent : Element<BreadcrumbListComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbListComponent"/> class with breadcrumb items.
    /// </summary>
    /// <param name="items">The breadcrumb items to include.</param>
    public BreadcrumbListComponent(params Node[] items) : base(items) => SetTag("ol");
}

/// <summary>
/// A breadcrumb item component that renders as an <c>&lt;li&gt;</c> element.
/// </summary>
public sealed class BreadcrumbItemComponent : Element<BreadcrumbItemComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbItemComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public BreadcrumbItemComponent(params Node[] children) : base(children) => SetTag("li");

    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbItemComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public BreadcrumbItemComponent(string textContent) : base(textContent) => SetTag("li");

    /// <summary>
    /// Marks this breadcrumb item as the active (current) item.
    /// </summary>
    /// <returns>The current <see cref="BreadcrumbItemComponent"/> for method chaining.</returns>
    public BreadcrumbItemComponent Active() => Class("active");

    /// <summary>
    /// Sets the <c>aria-current</c> attribute so assistive technology can identify this
    /// item as the current page. This is the framework-agnostic way to mark the active item.
    /// </summary>
    /// <param name="value">The aria-current value, typically "page".</param>
    /// <returns>The current <see cref="BreadcrumbItemComponent"/> for method chaining.</returns>
    public BreadcrumbItemComponent AriaCurrent(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Attributes.Set("aria-current", value);
        return this;
    }

    /// <summary>
    /// Sets a visual separator rendered inside this item, after its content. The separator is
    /// marked <c>aria-hidden</c> so screen readers skip it. An <c>&lt;ol&gt;</c> may only
    /// contain <c>&lt;li&gt;</c> elements, so the separator is nested rather than placed
    /// between items.
    /// </summary>
    /// <param name="separator">The separator node, typically a text or span node.</param>
    /// <returns>The current <see cref="BreadcrumbItemComponent"/> for method chaining.</returns>
    public BreadcrumbItemComponent Separator(Node separator)
    {
        ArgumentNullException.ThrowIfNull(separator);
        AddChild(new SpanElement(separator).Class("breadcrumb-separator").Aria("hidden", "true"));
        return this;
    }

    /// <summary>
    /// Sets a visual separator rendered inside this item using plain text.
    /// </summary>
    /// <param name="separator">The separator text, typically "/" or "&gt;".</param>
    /// <returns>The current <see cref="BreadcrumbItemComponent"/> for method chaining.</returns>
    public BreadcrumbItemComponent Separator(string separator)
    {
        ArgumentNullException.ThrowIfNull(separator);
        return Separator(new TextNode(separator));
    }
}

/// <summary>
/// Factory methods for creating breadcrumb components.
/// </summary>
public static class CoreBreadcrumbExtensions
{
    /// <summary>
    /// Creates a new <see cref="BreadcrumbComponent"/> containing an ordered list and the specified items.
    /// </summary>
    /// <param name="items">The breadcrumb items.</param>
    /// <returns>A new <see cref="BreadcrumbComponent"/> wrapping the items in <c>&lt;ol&gt;</c>.</returns>
    public static BreadcrumbComponent Breadcrumb(params BreadcrumbItemComponent[] items)
    {
        var ol = new OlElement(items.Cast<Node>().ToArray());
        return new BreadcrumbComponent(ol);
    }

    /// <summary>
    /// Creates a new <see cref="BreadcrumbListComponent"/> containing the specified items,
    /// for callers that need control over the list element itself.
    /// </summary>
    /// <param name="items">The breadcrumb items.</param>
    /// <returns>A new <see cref="BreadcrumbListComponent"/> instance.</returns>
    public static BreadcrumbListComponent BreadcrumbList(params BreadcrumbItemComponent[] items)
        => new(items.Cast<Node>().ToArray());

    /// <summary>
    /// Creates a <see cref="BreadcrumbComponent"/> wrapping an existing list element.
    /// </summary>
    /// <param name="list">The list element to wrap.</param>
    /// <returns>A new <see cref="BreadcrumbComponent"/> containing the list.</returns>
    public static BreadcrumbComponent Breadcrumb(BreadcrumbListComponent list)
    {
        ArgumentNullException.ThrowIfNull(list);
        return new BreadcrumbComponent(list);
    }

    /// <summary>
    /// Creates a new <see cref="BreadcrumbItemComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="BreadcrumbItemComponent"/> instance.</returns>
    public static BreadcrumbItemComponent BreadcrumbItem(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="BreadcrumbItemComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="BreadcrumbItemComponent"/> instance.</returns>
    public static BreadcrumbItemComponent BreadcrumbItem(string textContent) => new(textContent);
}
