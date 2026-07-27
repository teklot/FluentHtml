namespace FluentHtml.Nodes;

/// <summary>
/// Represents a text node in the component tree. Text content is HTML-encoded during rendering.
/// </summary>
public sealed class TextNode : Node
{
    /// <summary>
    /// Gets the text content of this node.
    /// </summary>
    public string Content { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TextNode"/> class.
    /// </summary>
    /// <param name="content">The text content. Null values are treated as empty strings.</param>
    public TextNode(string content)
    {
        Content = content ?? string.Empty;
    }
}
