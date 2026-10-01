using FluentHtml.Components;
using FluentHtml.Rendering;

namespace FluentHtml.Tests;

public class StandaloneBreadcrumbTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void Breadcrumb_RendersNavWithOl()
    {
        var bc = Breadcrumb(
            BreadcrumbItem("Home"),
            BreadcrumbItem("Products"),
            BreadcrumbItem("Detail").Active()
        );
        var html = _renderer.Render(bc);
        Assert.Contains("<nav", html);
        Assert.Contains("<ol", html);
        Assert.Contains("<li", html);
    }

    [Fact]
    public void BreadcrumbItem_Active_HasActiveClass()
    {
        var item = BreadcrumbItem("Current").Active();
        var html = _renderer.Render(item);
        Assert.Contains("active", html);
    }

    [Fact]
    public void BreadcrumbItem_TextContent()
    {
        var item = BreadcrumbItem("Home");
        var html = _renderer.Render(item);
        Assert.Contains("Home", html);
    }

    [Fact]
    public void BreadcrumbItem_AriaCurrent_RendersAccessibilityAttribute()
    {
        var item = BreadcrumbItem("Current").AriaCurrent("page");
        var html = _renderer.Render(item);
        Assert.Contains("aria-current=\"page\"", html);
    }

    [Fact]
    public void BreadcrumbItem_Separator_RendersHiddenSpanInsideItem()
    {
        var item = BreadcrumbItem("Home").Separator("/");
        var html = _renderer.Render(item);

        Assert.Contains("breadcrumb-separator", html);
        Assert.Contains("aria-hidden=\"true\"", html);
        // The separator must live inside the <li>, since an <ol> may only contain <li>.
        Assert.Contains("<li", html);
        Assert.StartsWith("<li", html);
    }

    [Fact]
    public void BreadcrumbItem_Separator_AcceptsNode()
    {
        var item = BreadcrumbItem("Home").Separator(new FluentHtml.Nodes.TextNode(">"));
        var html = _renderer.Render(item);
        Assert.Contains("breadcrumb-separator", html);
        Assert.Contains(">", html);
    }

    [Fact]
    public void BreadcrumbList_RendersOrderedList()
    {
        var list = CoreBreadcrumbExtensions.BreadcrumbList(
            BreadcrumbItem("Home"),
            BreadcrumbItem("About"));

        var html = _renderer.Render(list);
        Assert.Contains("<ol", html);
        Assert.Contains("Home", html);
        Assert.Contains("About", html);
    }

    [Fact]
    public void Breadcrumb_WrapsExplicitList()
    {
        var list = CoreBreadcrumbExtensions.BreadcrumbList(BreadcrumbItem("Home"));
        var html = _renderer.Render(CoreBreadcrumbExtensions.Breadcrumb(list));

        Assert.Contains("<nav", html);
        Assert.Contains("<ol", html);
    }

    private static BreadcrumbComponent Breadcrumb(params BreadcrumbItemComponent[] items) =>
        CoreBreadcrumbExtensions.Breadcrumb(items);

    private static BreadcrumbItemComponent BreadcrumbItem(string text) =>
        CoreBreadcrumbExtensions.BreadcrumbItem(text);
}
