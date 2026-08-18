using FluentHtml.Components;
using FluentHtml.Nodes;
using FluentHtml.Rendering;

namespace FluentHtml.Tests;

public class StandaloneBadgeTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void Badge_RendersSpanWithText()
    {
        var badge = Badge("New");
        var html = _renderer.Render(badge);
        Assert.Contains("<span", html);
        Assert.Contains("New", html);
        Assert.Contains("</span>", html);
    }

    [Fact]
    public void Badge_WithChildNodes()
    {
        var badge = Badge(new TextNode("5"));
        var html = _renderer.Render(badge);
        Assert.Contains("5", html);
    }

    [Fact]
    public void Badge_WithCssClass()
    {
        var badge = Badge("OK").Class("badge bg-success");
        var html = _renderer.Render(badge);
        Assert.Contains("badge bg-success", html);
    }

    private static BadgeComponent Badge(string text) => CoreBadgeExtensions.Badge(text);
    private static BadgeComponent Badge(params Node[] children) => CoreBadgeExtensions.Badge(children);
}
