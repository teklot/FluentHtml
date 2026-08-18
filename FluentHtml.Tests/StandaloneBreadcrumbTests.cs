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

    private static BreadcrumbComponent Breadcrumb(params BreadcrumbItemComponent[] items) =>
        CoreBreadcrumbExtensions.Breadcrumb(items);

    private static BreadcrumbItemComponent BreadcrumbItem(string text) =>
        CoreBreadcrumbExtensions.BreadcrumbItem(text);
}
