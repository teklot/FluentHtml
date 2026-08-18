using Markdig;
using FluentHtml.Nodes;

namespace FluentHtml.Components;

/// <summary>
/// A component that renders Markdown content as HTML using the Markdig parser.
/// </summary>
public sealed class MarkdownComponent : Component<string>
{
    private static readonly MarkdownPipeline Pipeline = new MarkdownPipelineBuilder()
        .UsePipeTables()
        .Build();

    private readonly string? _tableClass;

    /// <summary>
    /// Initializes a new instance of the <see cref="MarkdownComponent"/> class with the specified Markdown content.
    /// </summary>
    /// <param name="markdown">The Markdown string to render.</param>
    /// <param name="tableClass">Optional CSS class to apply to any &lt;table&gt; elements in the output.</param>
    public MarkdownComponent(string markdown, string? tableClass = null) : base(markdown)
    {
        _tableClass = tableClass;
    }

    /// <inheritdoc/>
    protected override Node Build(string data)
    {
        if (string.IsNullOrEmpty(data))
            return new TextNode(string.Empty);

        var html = Markdig.Markdown.ToHtml(data, Pipeline);
        if (_tableClass is not null)
            html = html.Replace("<table>", $"<table class=\"{_tableClass}\">");
        return new RawHtml(html);
    }
}

/// <summary>
/// Factory methods for creating <see cref="MarkdownComponent"/> instances.
/// </summary>
public static class MarkdownExtensions
{
    /// <summary>
    /// Creates a <see cref="MarkdownComponent"/> that renders the specified Markdown content as HTML.
    /// </summary>
    /// <param name="markdown">The Markdown string to render.</param>
    /// <returns>A new <see cref="MarkdownComponent"/> instance.</returns>
    public static MarkdownComponent Markdown(string markdown) => new(markdown);

    /// <summary>
    /// Creates a <see cref="MarkdownComponent"/> that renders the specified Markdown content as HTML,
    /// applying the given CSS class to any &lt;table&gt; elements.
    /// </summary>
    /// <param name="markdown">The Markdown string to render.</param>
    /// <param name="tableClass">CSS class to apply to &lt;table&gt; elements.</param>
    /// <returns>A new <see cref="MarkdownComponent"/> instance.</returns>
    public static MarkdownComponent Markdown(string markdown, string tableClass) => new(markdown, tableClass);
}
