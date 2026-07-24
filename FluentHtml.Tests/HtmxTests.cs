using FluentHtml.Elements;
using FluentHtml.Htmx;
using FluentHtml.Rendering;

namespace FluentHtml.Tests;

public class HtmxTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void Button_HxPost_Sets_Attribute()
    {
        var btn = new ButtonElement("Save").HxPost("/api/save");
        var html = _renderer.Render(btn);
        Assert.Contains("hx-post=\"/api/save\"", html);
    }

    [Fact]
    public void Button_HxGet_Sets_Attribute()
    {
        var btn = new ButtonElement("Load").HxGet("/api/data");
        var html = _renderer.Render(btn);
        Assert.Contains("hx-get=\"/api/data\"", html);
    }

    [Fact]
    public void Button_HxTarget_Sets_Attribute()
    {
        var btn = new ButtonElement("Click").HxTarget("#result");
        var html = _renderer.Render(btn);
        Assert.Contains("hx-target=\"#result\"", html);
    }

    [Fact]
    public void Button_HxSwap_Sets_Attribute()
    {
        var btn = new ButtonElement("Click").HxSwap("outerHTML");
        var html = _renderer.Render(btn);
        Assert.Contains("hx-swap=\"outerHTML\"", html);
    }

    [Fact]
    public void Button_HxTrigger_Sets_Attribute()
    {
        var btn = new ButtonElement("Click").HxTrigger("click");
        var html = _renderer.Render(btn);
        Assert.Contains("hx-trigger=\"click\"", html);
    }

    [Fact]
    public void Button_HxConfirm_Sets_Attribute()
    {
        var btn = new ButtonElement("Delete").HxConfirm("Are you sure?");
        var html = _renderer.Render(btn);
        Assert.Contains("hx-confirm=\"Are you sure?\"", html);
    }

    [Fact]
    public void Button_HxDelete_Sets_Attribute()
    {
        var btn = new ButtonElement("Remove").HxDelete("/api/items/1");
        var html = _renderer.Render(btn);
        Assert.Contains("hx-delete=\"/api/items/1\"", html);
    }

    [Fact]
    public void Button_HxPut_Sets_Attribute()
    {
        var btn = new ButtonElement("Update").HxPut("/api/items/1");
        var html = _renderer.Render(btn);
        Assert.Contains("hx-put=\"/api/items/1\"", html);
    }

    [Fact]
    public void Button_HxPatch_Sets_Attribute()
    {
        var btn = new ButtonElement("Patch").HxPatch("/api/items/1");
        var html = _renderer.Render(btn);
        Assert.Contains("hx-patch=\"/api/items/1\"", html);
    }

    [Fact]
    public void Button_HxBoost_Sets_Attribute()
    {
        var btn = new ButtonElement("Nav").HxBoost();
        var html = _renderer.Render(btn);
        Assert.Contains("hx-boost", html);
    }
}
