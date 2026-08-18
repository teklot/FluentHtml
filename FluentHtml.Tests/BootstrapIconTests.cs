using FluentHtml.Bootstrap.Components;
using FluentHtml.Rendering;

namespace FluentHtml.Tests;

public class BootstrapIconTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void BiIcon_RendersWithBootstrapIconClasses()
    {
        var icon = BootstrapIconExtensions.BiIcon("house");
        var html = _renderer.Render(icon);
        Assert.Contains("bi bi-house", html);
        Assert.Contains("data-icon=\"house\"", html);
    }

    [Fact]
    public void BiIcon_WithSizeClass()
    {
        var icon = BootstrapIconExtensions.BiIcon("user").BiSize("fs-3");
        var html = _renderer.Render(icon);
        Assert.Contains("fs-3", html);
    }
}
