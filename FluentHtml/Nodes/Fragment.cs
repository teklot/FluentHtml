namespace FluentHtml.Nodes;

/// <summary>
/// Groups multiple sibling nodes without a wrapper element. Fragments produce no
/// enclosing HTML tag during rendering, only their children are rendered.
/// </summary>
public sealed class Fragment : Node
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Fragment"/> class with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the fragment.</param>
    public Fragment(params Node[] children)
        : base(children)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Fragment"/> class with a text content child.
    /// </summary>
    /// <param name="textContent">The text content to add as a child text node.</param>
    public Fragment(string textContent)
        : base(textContent)
    {
    }
}
