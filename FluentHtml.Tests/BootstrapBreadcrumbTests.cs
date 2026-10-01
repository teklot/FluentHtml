using FluentHtml.Rendering;
using static FluentHtml.Bootstrap.Components.BreadcrumbExtensions;

namespace FluentHtml.Tests;

public class BootstrapBreadcrumbTests
{
    private readonly Renderer _renderer = new();

    private static FluentHtml.Bootstrap.Components.BreadcrumbCollapseComponent BuildCollapsed() =>
        BreadcrumbCollapse(2,
            BreadcrumbItem("Home"),
            BreadcrumbItem("Library"),
            BreadcrumbItem("Data"),
            BreadcrumbItem("Report"));

    [Fact]
    public void Breadcrumb_Renders_Nav_And_List()
    {
        var html = _renderer.Render(
            Breadcrumb(BreadcrumbList(BreadcrumbItem("Home"))).AriaLabel("breadcrumb"));

        Assert.Contains("<nav", html);
        Assert.Contains("<ol", html);
        Assert.Contains("breadcrumb", html);
    }

    [Fact]
    public void Breadcrumb_Item_Renders_Bootstrap_Classes()
    {
        var html = _renderer.Render(BreadcrumbList(BreadcrumbItem("Home")));
        Assert.Contains("breadcrumb-item", html);
    }

    [Fact]
    public void Breadcrumb_Item_Active_Renders_Active_Class_And_AriaCurrent()
    {
        var html = _renderer.Render(BreadcrumbItem("Current").Active().AriaCurrent("page"));
        Assert.Contains("active", html);
        Assert.Contains("aria-current=\"page\"", html);
    }

    [Fact]
    public void Breadcrumb_List_Separator_Sets_Css_Variable()
    {
        var html = _renderer.Render(BreadcrumbList(BreadcrumbItem("Home")).Separator(">"));
        Assert.Contains("--bs-breadcrumb-divider", html);
    }

    [Fact]
    public void Breadcrumb_List_Small_Sets_Font_Size_Not_Item_Class()
    {
        var html = _renderer.Render(BreadcrumbList(BreadcrumbItem("Home")).Small());

        Assert.Contains("--bs-breadcrumb-font-size", html);
        // Regression: Small() previously applied breadcrumb-item to the <ol>.
        Assert.DoesNotContain("<ol class=\"breadcrumb breadcrumb-item\"", html);
    }

    [Fact]
    public void Breadcrumb_Link_HxGet_Renders_Htmx_Attributes()
    {
        var html = _renderer.Render(BreadcrumbLink("Orders").HxGet("/orders"));
        Assert.Contains("hx-get=\"/orders\"", html);
        Assert.Contains("hx-push-url=\"true\"", html);
    }

    [Fact]
    public void Breadcrumb_Link_Target_And_Swap_Are_Applied()
    {
        var html = _renderer.Render(
            BreadcrumbLink("Orders").HxGet("/orders").Target("#content").Swap("innerHTML"));

        Assert.Contains("hx-target=\"#content\"", html);
        Assert.Contains("hx-swap=\"innerHTML\"", html);
    }

    [Fact]
    public void BreadcrumbCollapse_Keeps_First_Items_Visible()
    {
        var html = _renderer.Render(BuildCollapsed());
        Assert.Contains("Home", html);
        Assert.Contains("Library", html);
    }

    [Fact]
    public void BreadcrumbCollapse_Renders_Toggle_And_Collapse_Class()
    {
        var html = _renderer.Render(BuildCollapsed());
        Assert.Contains("breadcrumb-toggle", html);
        Assert.Contains("data-bs-toggle=\"collapse\"", html);
        Assert.Contains("data-bs-target=\".breadcrumb-collapsed\"", html);
    }

    [Fact]
    public void BreadcrumbCollapse_Keeps_Every_Li_As_Direct_Child_Of_Ol()
    {
        var html = _renderer.Render(BuildCollapsed());

        // No wrapper element may sit between <ol> and <li>, since Bootstrap's flex layout
        // and the HTML content model both require <ol> to contain <li> only.
        Assert.DoesNotContain("<ol class=\"breadcrumb\"><li class=\"breadcrumb-item\"><a href=\"#\">Home</a></li><li class=\"breadcrumb-item\"><a href=\"#\">Library</a></li><div", html);
        Assert.Contains("class=\"breadcrumb-item collapse breadcrumb-collapsed\"", html);
    }

    [Fact]
    public void BreadcrumbCollapse_Injects_Stylesheet()
    {
        var html = _renderer.Render(BuildCollapsed());
        Assert.Contains("<style", html);
        Assert.Contains("breadcrumb-collapsed", html);
    }

    [Fact]
    public void BreadcrumbCollapse_Custom_Toggle_Label()
    {
        var html = _renderer.Render(BuildCollapsed().ToggleLabel("Show"));
        Assert.Contains("Show", html);
    }

    [Fact]
    public void BreadcrumbCollapse_Supports_Custom_Separator()
    {
        var html = _renderer.Render(BuildCollapsed().Separator(">"));
        Assert.Contains("--bs-breadcrumb-divider", html);
    }

    [Fact]
    public void BreadcrumbCollapse_Without_Overflow_Renders_No_Toggle()
    {
        var html = _renderer.Render(
            BreadcrumbCollapse(5, BreadcrumbItem("Home"), BreadcrumbItem("About")));

        // The stylesheet is always emitted, so assert on the toggle element itself.
        Assert.DoesNotContain("data-bs-toggle=\"collapse\"", html);
        Assert.DoesNotContain("breadcrumb-collapsed\"", html);
    }
}
