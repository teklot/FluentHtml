namespace FluentHtml.Nodes;

/// <summary>
/// Abstract base class for all nodes in the FluentHtml component tree.
/// Nodes represent the fundamental building blocks of an HTML document structure.
/// </summary>
public abstract class Node
{
    private readonly List<Node> _children = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class with no children.
    /// </summary>
    protected Node()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes to add.</param>
    protected Node(params Node[] children)
    {
        _children.AddRange(children);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class with a text content child.
    /// </summary>
    /// <param name="textContent">The text content to add as a child text node.</param>
    protected Node(string textContent)
    {
        _children.Add(new TextNode(textContent ?? string.Empty));
    }

    /// <summary>
    /// Gets the list of child nodes.
    /// </summary>
    public IReadOnlyList<Node> Children => _children;

    /// <summary>
    /// Adds a child node to this node.
    /// </summary>
    /// <param name="child">The node to add as a child.</param>
    public void AddChild(Node child) => _children.Add(child);

    /// <summary>
    /// Adds multiple child nodes to this node.
    /// </summary>
    /// <param name="children">The nodes to add as children.</param>
    public void AddChildren(IEnumerable<Node> children) => _children.AddRange(children);

    /// <summary>
    /// Adds a text content child to this node.
    /// </summary>
    /// <param name="text">The text content to add.</param>
    public void AddText(string text) => _children.Add(new TextNode(text));
}
