namespace FluentHtml.Nodes;

public sealed class RawHtml : Node
{
    public string Content { get; }

    public RawHtml(string content)
    {
        Content = content ?? string.Empty;
    }
}
