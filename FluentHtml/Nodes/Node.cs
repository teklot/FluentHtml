namespace FluentHtml.Nodes;

public abstract class Node
{
    private readonly List<Node> _children = [];

    protected Node()
    {
    }

    protected Node(params Node[] children)
    {
        _children.AddRange(children);
    }

    protected Node(string textContent)
    {
        _children.Add(new TextNode(textContent ?? string.Empty));
    }

    public IReadOnlyList<Node> Children => _children;

    public void AddChild(Node child) => _children.Add(child);

    public void AddChildren(IEnumerable<Node> children) => _children.AddRange(children);

    public void AddText(string text) => _children.Add(new TextNode(text));
}
