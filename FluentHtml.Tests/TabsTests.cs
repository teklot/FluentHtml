using FluentHtml.Bootstrap.Components;
using FluentHtml.Nodes;
using FluentHtml.Rendering;
using static FluentHtml.Bootstrap.Components.TabExtensions;

namespace FluentHtml.Tests;

public class TabsTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void Tabs_Has_Correct_Tag_And_Classes()
    {
        var tabs = Tabs();
        var html = _renderer.Render(tabs);
        Assert.Contains("<ul", html);
        Assert.Contains("nav nav-tabs", html);
    }

    [Fact]
    public void Tabs_Pills_Adds_Class()
    {
        var tabs = Tabs().Pills();
        var html = _renderer.Render(tabs);
        Assert.Contains("nav-pills", html);
    }

    [Fact]
    public void Tabs_Fill_Adds_Class()
    {
        var tabs = Tabs().Fill();
        var html = _renderer.Render(tabs);
        Assert.Contains("nav-fill", html);
    }

    [Fact]
    public void Tabs_Justified_Adds_Class()
    {
        var tabs = Tabs().Justified();
        var html = _renderer.Render(tabs);
        Assert.Contains("nav-justified", html);
    }

    [Fact]
    public void Tabs_Vertical_Adds_Class()
    {
        var tabs = Tabs().Vertical();
        var html = _renderer.Render(tabs);
        Assert.Contains("flex-column", html);
    }

    [Fact]
    public void Tabs_With_Children_Renders()
    {
        var tabs = Tabs(
            TabItem(TabLink("Tab 1").Href("#tab1")),
            TabItem(TabLink("Tab 2").Href("#tab2"))
        );
        var html = _renderer.Render(tabs);
        Assert.Contains("Tab 1", html);
        Assert.Contains("Tab 2", html);
        Assert.Contains("nav-item", html);
        Assert.Contains("nav-link", html);
    }

    [Fact]
    public void TabItem_Has_Correct_Classes()
    {
        var item = TabItem();
        var html = _renderer.Render(item);
        Assert.Contains("nav-item", html);
        Assert.Contains("<li", html);
    }

    [Fact]
    public void TabLink_Has_Data_Bs_Toggle()
    {
        var link = TabLink("My Tab");
        var html = _renderer.Render(link);
        Assert.Contains("data-bs-toggle=\"tab\"", html);
        Assert.Contains("nav-link", html);
        Assert.Contains("My Tab", html);
    }

    [Fact]
    public void TabLink_Active_Has_Class()
    {
        var link = TabLink("Active Tab").Active();
        var html = _renderer.Render(link);
        Assert.Contains("active", html);
    }

    [Fact]
    public void TabLink_Href_Sets_Attribute()
    {
        var link = TabLink("Click Me").Href("#panel1");
        var html = _renderer.Render(link);
        Assert.Contains("href=\"#panel1\"", html);
    }

    [Fact]
    public void TabContent_Has_Correct_Classes()
    {
        var content = TabContent();
        var html = _renderer.Render(content);
        Assert.Contains("tab-content", html);
    }

    [Fact]
    public void TabPane_Has_Fade_Class()
    {
        var pane = TabPane();
        var html = _renderer.Render(pane);
        Assert.Contains("tab-pane fade", html);
    }

    [Fact]
    public void TabPane_With_TextNode_Renders_Content()
    {
        var pane = TabPane(new TextNode("Content"));
        var html = _renderer.Render(pane);
        Assert.Contains("Content", html);
    }

    [Fact]
    public void TabPane_Active_Show_Has_Classes()
    {
        var pane = TabPane(new TextNode("Content")).Active().Show();
        var html = _renderer.Render(pane);
        Assert.Contains("active", html);
        Assert.Contains("show", html);
        Assert.Contains("Content", html);
    }

    [Fact]
    public void Full_Tab_Setup_Renders()
    {
        var tabs = Tabs(
            TabItem(TabLink("Home").Href("#home").Active()),
            TabItem(TabLink("Profile").Href("#profile")),
            TabItem(TabLink("Contact").Href("#contact"))
        );
        var content = TabContent(
            TabPane(new TextNode("Home content")).Id("home").Active().Show(),
            TabPane(new TextNode("Profile content")).Id("profile"),
            TabPane(new TextNode("Contact content")).Id("contact")
        );
        var tabsHtml = _renderer.Render(tabs);
        var contentHtml = _renderer.Render(content);
        Assert.Contains("Home", tabsHtml);
        Assert.Contains("Profile", tabsHtml);
        Assert.Contains("Contact", tabsHtml);
        Assert.Contains("Home content", contentHtml);
        Assert.Contains("Profile content", contentHtml);
        Assert.Contains("Contact content", contentHtml);
    }

    [Fact]
    public void TabPane_Id_Sets_Attribute()
    {
        var pane = TabPane(new TextNode("Content")).Id("myTab");
        var html = _renderer.Render(pane);
        Assert.Contains("id=\"myTab\"", html);
    }
}
