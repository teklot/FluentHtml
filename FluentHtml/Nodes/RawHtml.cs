namespace FluentHtml.Nodes;

/// <summary>
/// Represents raw HTML content that bypasses HTML encoding during rendering.
/// Use this sparingly for trusted HTML content that should not be escaped.
/// </summary>
public sealed class RawHtml : Node
{
    /// <summary>
    /// Gets the raw HTML content.
    /// </summary>
    public string Content { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RawHtml"/> class.
    /// </summary>
    /// <param name="content">The raw HTML content. Null values are treated as empty strings.</param>
    public RawHtml(string content)
    {
        Content = content ?? string.Empty;
    }
}