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
