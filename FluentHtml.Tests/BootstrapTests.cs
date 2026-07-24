using FluentHtml.Bootstrap.Components;
using FluentHtml.Rendering;

namespace FluentHtml.Tests;

public class BootstrapTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void Card_Renders_Correctly()
    {
        var card = CardExtensions.Card(
            new FluentHtml.Elements.Heading2Element("Title"),
            new FluentHtml.Elements.ParagraphElement("Content")
        );
        var html = _renderer.Render(card);
        Assert.Contains("<div", html);
        Assert.Contains("Title", html);
        Assert.Contains("Content", html);
    }

    [Fact]
    public void Button_Primary_Has_Classes()
    {
        var btn = ButtonExtensions.Btn("Save").Primary();
        var html = _renderer.Render(btn);
        Assert.Contains("btn", html);
        Assert.Contains("btn-primary", html);
        Assert.Contains("Save", html);
    }

    [Fact]
    public void Button_Outline_Danger_Has_Classes()
    {
        var btn = ButtonExtensions.Btn("Delete").OutlineDanger();
        var html = _renderer.Render(btn);
        Assert.Contains("btn-outline-danger", html);
    }

    [Fact]
    public void Button_Large_Has_Size_Class()
    {
        var btn = ButtonExtensions.Btn("Big").Large();
        var html = _renderer.Render(btn);
        Assert.Contains("btn-lg", html);
    }

    [Fact]
    public void Alert_Success_Has_Classes()
    {
        var alert = AlertExtensions.Alert("Saved!").Success();
        var html = _renderer.Render(alert);
        Assert.Contains("alert", html);
        Assert.Contains("alert-success", html);
        Assert.Contains("Saved!", html);
    }

    [Fact]
    public void Badge_Has_Classes()
    {
        var badge = BadgeExtensions.Badge("5");
        var html = _renderer.Render(badge);
        Assert.Contains("badge", html);
    }

    [Fact]
    public void Spinner_Renders()
    {
        var spinner = SpinnerExtensions.Spinner();
        var html = _renderer.Render(spinner);
        Assert.Contains("spinner-border", html);
    }
}
