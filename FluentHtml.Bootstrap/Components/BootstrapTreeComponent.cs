using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap-styled tree navigation component.
/// Renders an expandable/collapsible tree with Bootstrap styling.
/// Supports HTMX lazy-loading of child nodes.
/// </summary>
public sealed class BootstrapTreeComponent : Element<BootstrapTreeComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BootstrapTreeComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public BootstrapTreeComponent(params Node[] children) : base(children) { SetTag("ul"); Class("list-unstyled"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="BootstrapTreeComponent"/> class.
    /// </summary>
    public BootstrapTreeComponent() { SetTag("ul"); Class("list-unstyled"); }

    /// <summary>
    /// Adds tree lines for visual hierarchy.
    /// </summary>
    /// <returns>The current <see cref="BootstrapTreeComponent"/> instance.</returns>
    public BootstrapTreeComponent TreeLines() => Class("tree-lines");
}

/// <summary>
/// A Bootstrap-styled tree node component for expandable nodes.
/// </summary>
public sealed class BootstrapTreeNodeComponent : Element<BootstrapTreeNodeComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BootstrapTreeNodeComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public BootstrapTreeNodeComponent(params Node[] children) : base(children) { SetTag("li"); Class("tree-node"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="BootstrapTreeNodeComponent"/> class.
    /// </summary>
    public BootstrapTreeNodeComponent() { SetTag("li"); Class("tree-node"); }
}

/// <summary>
/// A Bootstrap-styled tree toggle component for expanding/collapsing nodes.
/// Includes HTMX support for lazy-loading child content.
/// </summary>
public sealed class BootstrapTreeToggleComponent : Element<BootstrapTreeToggleComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BootstrapTreeToggleComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The toggle text.</param>
    public BootstrapTreeToggleComponent(string textContent) : base(textContent)
    {
        SetTag("button");
        Class("btn btn-link text-decoration-none text-start p-0 tree-toggle");
        Attributes.Set("type", "button");
        Attributes.Set("aria-expanded", "false");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BootstrapTreeToggleComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public BootstrapTreeToggleComponent(params Node[] children) : base(children)
    {
        SetTag("button");
        Class("btn btn-link text-decoration-none text-start p-0 tree-toggle");
        Attributes.Set("type", "button");
        Attributes.Set("aria-expanded", "false");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BootstrapTreeToggleComponent"/> class.
    /// </summary>
    public BootstrapTreeToggleComponent()
    {
        SetTag("button");
        Class("btn btn-link text-decoration-none text-start p-0 tree-toggle");
        Attributes.Set("type", "button");
        Attributes.Set("aria-expanded", "false");
    }

    /// <summary>
    /// Marks this toggle as expanded.
    /// </summary>
    /// <returns>The current <see cref="BootstrapTreeToggleComponent"/> instance.</returns>
    public BootstrapTreeToggleComponent Expanded() => Class("tree-toggle-expanded");

    /// <summary>
    /// Adds HTMX lazy-loading for child nodes.
    /// </summary>
    /// <param name="url">The hx-get URL to load child nodes.</param>
    /// <param name="target">The hx-target selector (default: "next .tree-children").</param>
    /// <returns>The current <see cref="BootstrapTreeToggleComponent"/> instance.</returns>
    public BootstrapTreeToggleComponent HxLoad(string url, string target = "next .tree-children")
    {
        Attributes.Set("hx-get", url);
        Attributes.Set("hx-target", target);
        Attributes.Set("hx-swap", "innerHTML");
        Attributes.Set("hx-trigger", "click once");
        return this;
    }
}

/// <summary>
/// A Bootstrap-styled tree leaf component for non-expandable nodes.
/// </summary>
public sealed class BootstrapTreeLeafComponent : Element<BootstrapTreeLeafComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BootstrapTreeLeafComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public BootstrapTreeLeafComponent(params Node[] children) : base(children) { SetTag("li"); Class("tree-leaf"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="BootstrapTreeLeafComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The leaf text.</param>
    public BootstrapTreeLeafComponent(string textContent) : base(textContent) { SetTag("li"); Class("tree-leaf"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="BootstrapTreeLeafComponent"/> class.
    /// </summary>
    public BootstrapTreeLeafComponent() { SetTag("li"); Class("tree-leaf"); }
}

/// <summary>
/// A Bootstrap-styled tree children container component.
/// Used to wrap child nodes for collapse/expand behavior.
/// </summary>
public sealed class BootstrapTreeChildrenComponent : Element<BootstrapTreeChildrenComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BootstrapTreeChildrenComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public BootstrapTreeChildrenComponent(params Node[] children) : base(children) { SetTag("ul"); Class("list-unstyled tree-children ps-3"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="BootstrapTreeChildrenComponent"/> class.
    /// </summary>
    public BootstrapTreeChildrenComponent() { SetTag("ul"); Class("list-unstyled tree-children ps-3"); }

    /// <summary>
    /// Makes the children container collapsed by default.
    /// </summary>
    /// <returns>The current <see cref="BootstrapTreeChildrenComponent"/> instance.</returns>
    public BootstrapTreeChildrenComponent Collapsed() => Class("collapse");
}

/// <summary>
/// Extension methods for creating Bootstrap-styled tree navigation components.
/// </summary>
public static class BootstrapTreeExtensions
{
    /// <summary>
    /// Creates a new <see cref="BootstrapTreeComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="BootstrapTreeComponent"/> instance.</returns>
    public static BootstrapTreeComponent BootstrapTree(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="BootstrapTreeComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="BootstrapTreeComponent"/> instance.</returns>
    public static BootstrapTreeComponent BootstrapTree() => new();

    /// <summary>
    /// Creates a new <see cref="BootstrapTreeNodeComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="BootstrapTreeNodeComponent"/> instance.</returns>
    public static BootstrapTreeNodeComponent BootstrapTreeNode(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="BootstrapTreeNodeComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="BootstrapTreeNodeComponent"/> instance.</returns>
    public static BootstrapTreeNodeComponent BootstrapTreeNode() => new();

    /// <summary>
    /// Creates a new <see cref="BootstrapTreeToggleComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The toggle text.</param>
    /// <returns>A new <see cref="BootstrapTreeToggleComponent"/> instance.</returns>
    public static BootstrapTreeToggleComponent BootstrapTreeToggle(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new <see cref="BootstrapTreeToggleComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="BootstrapTreeToggleComponent"/> instance.</returns>
    public static BootstrapTreeToggleComponent BootstrapTreeToggle(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="BootstrapTreeToggleComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="BootstrapTreeToggleComponent"/> instance.</returns>
    public static BootstrapTreeToggleComponent BootstrapTreeToggle() => new();

    /// <summary>
    /// Creates a new <see cref="BootstrapTreeLeafComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="BootstrapTreeLeafComponent"/> instance.</returns>
    public static BootstrapTreeLeafComponent BootstrapTreeLeaf(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="BootstrapTreeLeafComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The leaf text.</param>
    /// <returns>A new <see cref="BootstrapTreeLeafComponent"/> instance.</returns>
    public static BootstrapTreeLeafComponent BootstrapTreeLeaf(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="BootstrapTreeLeafComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="BootstrapTreeLeafComponent"/> instance.</returns>
    public static BootstrapTreeLeafComponent BootstrapTreeLeaf() => new();

    /// <summary>
    /// Creates a new <see cref="BootstrapTreeChildrenComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="BootstrapTreeChildrenComponent"/> instance.</returns>
    public static BootstrapTreeChildrenComponent BootstrapTreeChildren(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="BootstrapTreeChildrenComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="BootstrapTreeChildrenComponent"/> instance.</returns>
    public static BootstrapTreeChildrenComponent BootstrapTreeChildren() => new();
}
