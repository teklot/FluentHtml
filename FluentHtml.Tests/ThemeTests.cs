using FluentHtml.Bootstrap.Components;
using FluentHtml.Rendering;

namespace FluentHtml.Tests;

public class ThemeTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void ThemeToggle_RendersButton()
    {
        var toggle = ThemeExtensions.ThemeToggle();
        var html = _renderer.Render(toggle);
        Assert.Contains("<button", html);
    }

    [Fact]
    public void ThemeToggle_WithCustomIcons()
    {
        var toggle = ThemeExtensions.ThemeToggle().LightIcon("brightness-high").DarkIcon("moon");
        var html = _renderer.Render(toggle);
        Assert.Contains("<button", html);
    }
}
