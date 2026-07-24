namespace FluentHtml.Nodes;

public sealed class TextNode : Node
{
    public string Content { get; }

    public TextNode(string content)
    {
        Content = content ?? string.Empty;
    }
}
