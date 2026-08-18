using FluentHtml.Components;
using FluentHtml.Rendering;

namespace FluentHtml.Tests;

public class MarkdownTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void Markdown_RendersHeading()
    {
        var md = Markdown("# Hello World");
        var html = _renderer.Render(md);
        Assert.Contains("<h1>Hello World</h1>", html);
    }

    [Fact]
    public void Markdown_RendersBoldAndItalic()
    {
        var md = Markdown("**bold** and *italic*");
        var html = _renderer.Render(md);
        Assert.Contains("<strong>bold</strong>", html);
        Assert.Contains("<em>italic</em>", html);
    }

    [Fact]
    public void Markdown_RendersLink()
    {
        var md = Markdown("[Click here](https://example.com)");
        var html = _renderer.Render(md);
        Assert.Contains("href=\"https://example.com\"", html);
        Assert.Contains("Click here", html);
    }

    [Fact]
    public void Markdown_RendersList()
    {
        var md = Markdown("- Item 1\n- Item 2\n- Item 3");
        var html = _renderer.Render(md);
        Assert.Contains("<ul>", html);
        Assert.Contains("<li>Item 1</li>", html);
    }

    [Fact]
    public void Markdown_EmptyString_ReturnsEmpty()
    {
        var md = Markdown("");
        var html = _renderer.Render(md);
        Assert.Equal(string.Empty, html);
    }

    [Fact]
    public void Markdown_NullOrEmpty_ReturnsEmpty()
    {
        var md = Markdown(null!);
        var html = _renderer.Render(md);
        Assert.Equal(string.Empty, html);
    }

    private static MarkdownComponent Markdown(string content) => FluentHtml.Components.MarkdownExtensions.Markdown(content);
}
