using FluentHtml.Nodes;

namespace FluentHtml.Components;

/// <summary>
/// A framework-agnostic tree navigation component.
/// Renders an expandable/collapsible tree structure.
/// </summary>
public sealed class TreeComponent : Element<TreeComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TreeComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public TreeComponent(params Node[] children) : base(children) { SetTag("ul"); Class("list-unstyled"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="TreeComponent"/> class.
    /// </summary>
    public TreeComponent() { SetTag("ul"); Class("list-unstyled"); }

    /// <summary>
    /// Adds left padding for nested tree indentation.
    /// </summary>
    /// <returns>The current <see cref="TreeComponent"/> instance.</returns>
    public TreeComponent Indent() => Class("tree-children ps-3");

    /// <summary>
    /// Makes the tree children container collapsed by default.
    /// </summary>
    /// <returns>The current <see cref="TreeComponent"/> instance.</returns>
    public TreeComponent Collapsed() => Class("collapse");
}

/// <summary>
/// A framework-agnostic tree node component representing a single expandable node.
/// </summary>
public sealed class TreeNodeComponent : Element<TreeNodeComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TreeNodeComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public TreeNodeComponent(params Node[] children) : base(children) { SetTag("li"); Class("tree-node"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="TreeNodeComponent"/> class.
    /// </summary>
    public TreeNodeComponent() { SetTag("li"); Class("tree-node"); }
}

/// <summary>
/// A framework-agnostic tree toggle component for expanding/collapsing nodes.
/// </summary>
public sealed class TreeToggleComponent : Element<TreeToggleComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TreeToggleComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public TreeToggleComponent(params Node[] children) : base(children) { SetTag("button"); Class("btn btn-link text-decoration-none text-start p-0 tree-toggle"); Attributes.Set("type", "button"); Attributes.Set("aria-expanded", "false"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="TreeToggleComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The toggle text.</param>
    public TreeToggleComponent(string textContent) : base(textContent) { SetTag("button"); Class("btn btn-link text-decoration-none text-start p-0 tree-toggle"); Attributes.Set("type", "button"); Attributes.Set("aria-expanded", "false"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="TreeToggleComponent"/> class.
    /// </summary>
    public TreeToggleComponent() { SetTag("button"); Class("btn btn-link text-decoration-none text-start p-0 tree-toggle"); Attributes.Set("type", "button"); Attributes.Set("aria-expanded", "false"); }

    /// <summary>
    /// Marks this toggle as expanded.
    /// </summary>
    /// <returns>The current <see cref="TreeToggleComponent"/> instance.</returns>
    public TreeToggleComponent Expanded() { Attributes.Set("aria-expanded", "true"); return this; }
}

/// <summary>
/// A framework-agnostic tree leaf component representing a non-expandable node.
/// </summary>
public sealed class TreeLeafComponent : Element<TreeLeafComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TreeLeafComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public TreeLeafComponent(params Node[] children) : base(children) { SetTag("li"); Class("tree-leaf"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="TreeLeafComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The leaf text.</param>
    public TreeLeafComponent(string textContent) : base(textContent) { SetTag("li"); Class("tree-leaf"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="TreeLeafComponent"/> class.
    /// </summary>
    public TreeLeafComponent() { SetTag("li"); Class("tree-leaf"); }
}

/// <summary>
/// Extension methods for creating framework-agnostic tree navigation components.
/// </summary>
public static class CoreTreeExtensions
{
    /// <summary>
    /// Creates a new <see cref="TreeComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="TreeComponent"/> instance.</returns>
    public static TreeComponent Tree(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="TreeComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="TreeComponent"/> instance.</returns>
    public static TreeComponent Tree() => new();

    /// <summary>
    /// Creates a new <see cref="TreeNodeComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="TreeNodeComponent"/> instance.</returns>
    public static TreeNodeComponent TreeNode(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="TreeNodeComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="TreeNodeComponent"/> instance.</returns>
    public static TreeNodeComponent TreeNode() => new();

    /// <summary>
    /// Creates a new <see cref="TreeToggleComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="TreeToggleComponent"/> instance.</returns>
    public static TreeToggleComponent TreeToggle(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="TreeToggleComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The toggle text.</param>
    /// <returns>A new <see cref="TreeToggleComponent"/> instance.</returns>
    public static TreeToggleComponent TreeToggle(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="TreeToggleComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="TreeToggleComponent"/> instance.</returns>
    public static TreeToggleComponent TreeToggle() => new();

    /// <summary>
    /// Creates a new <see cref="TreeLeafComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="TreeLeafComponent"/> instance.</returns>
    public static TreeLeafComponent TreeLeaf(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="TreeLeafComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The leaf text.</param>
    /// <returns>A new <see cref="TreeLeafComponent"/> instance.</returns>
    public static TreeLeafComponent TreeLeaf(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="TreeLeafComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="TreeLeafComponent"/> instance.</returns>
    public static TreeLeafComponent TreeLeaf() => new();
}
