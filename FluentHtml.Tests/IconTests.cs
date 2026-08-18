using FluentHtml.Components;
using FluentHtml.Rendering;

namespace FluentHtml.Tests;

public class IconTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void Icon_RendersItagWithDataIcon()
    {
        var icon = Icon("house");
        var html = _renderer.Render(icon);
        Assert.Contains("<i data-icon=\"house\"", html);
    }

    [Fact]
    public void Icon_WithCssClass()
    {
        var icon = Icon("user").Class("bi bi-house fs-5");
        var html = _renderer.Render(icon);
        Assert.Contains("bi bi-house", html);
        Assert.Contains("fs-5", html);
    }

    [Fact]
    public void Icon_Empty_RendersEmptyItag()
    {
        var icon = Icon();
        var html = _renderer.Render(icon);
        Assert.Contains("<i", html);
    }

    private static IconComponent Icon(string name = "") =>
        string.IsNullOrEmpty(name) ? IconExtensions.Icon() : IconExtensions.Icon(name);
}
