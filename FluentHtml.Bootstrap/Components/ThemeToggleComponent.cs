using FluentHtml.Components;
using FluentHtml.Elements;
using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A theme toggle component that switches Bootstrap's <c>data-bs-theme</c> attribute
/// between light and dark mode. Persists the user's preference in localStorage.
/// </summary>
public sealed class ThemeToggleComponent : Component
{
    private string _lightIcon = "sun";
    private string _darkIcon = "moon";

    /// <summary>
    /// Initializes a new instance of the <see cref="ThemeToggleComponent"/> class.
    /// </summary>
    public ThemeToggleComponent()
    {
    }

    /// <summary>
    /// Sets the Bootstrap Icon name to display in light mode.
    /// </summary>
    /// <param name="iconName">The Bootstrap Icon name (without "bi-" prefix).</param>
    /// <returns>The current <see cref="ThemeToggleComponent"/> for method chaining.</returns>
    public ThemeToggleComponent LightIcon(string iconName)
    {
        _lightIcon = iconName;
        return this;
    }

    /// <summary>
    /// Sets the Bootstrap Icon name to display in dark mode.
    /// </summary>
    /// <param name="iconName">The Bootstrap Icon name (without "bi-" prefix).</param>
    /// <returns>The current <see cref="ThemeToggleComponent"/> for method chaining.</returns>
    public ThemeToggleComponent DarkIcon(string iconName)
    {
        _darkIcon = iconName;
        return this;
    }

    /// <inheritdoc/>
    public override Node Render()
    {
        var icon = new FluentHtml.Components.IconComponent(_lightIcon)
            .Class($"bi bi-{_lightIcon}")
            .Id("theme-toggle-icon");

        var script = new FluentHtml.Components.InlineScriptComponent(
            "(function(){" +
            "var h=document.documentElement;" +
            "var b=document.getElementById('theme-toggle-icon');" +
            "var li='" + _lightIcon + "';" +
            "var di='" + _darkIcon + "';" +
            "function apply(t){" +
            "h.setAttribute('data-bs-theme',t);" +
            "localStorage.setItem('fh-theme',t);" +
            "if(b)b.className='bi bi-'+(t==='dark'?li:di);" +
            "}" +
            "var s=localStorage.getItem('fh-theme');" +
            "if(s)apply(s);" +
            "document.getElementById('theme-toggle-btn').addEventListener('click',function(){" +
            "var c=h.getAttribute('data-bs-theme')==='dark'?'light':'dark';" +
            "apply(c);" +
            "});" +
            "})();");

        var btn = new ButtonElement(icon, script)
            .Type("button")
            .Class("btn btn-outline-secondary")
            .Id("theme-toggle-btn");
        btn.Attributes.Set("aria-label", "Toggle theme");

        return btn;
    }
}

/// <summary>
/// Extension methods for theme support.
/// </summary>
public static class ThemeExtensions
{
    /// <summary>
    /// Creates a theme toggle button that switches between light and dark mode.
    /// </summary>
    /// <returns>A new <see cref="ThemeToggleComponent"/> instance.</returns>
    public static ThemeToggleComponent ThemeToggle() => new();
}
