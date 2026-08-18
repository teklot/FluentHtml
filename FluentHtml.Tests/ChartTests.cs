using FluentHtml.Bootstrap.Components;
using FluentHtml.Rendering;

namespace FluentHtml.Tests;

public class ChartTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void Chart_RendersCanvas()
    {
        var chart = ChartExtensions.Chart("my-chart", ChartType.Bar)
            .Data(new[] { 10.0, 20.0, 30.0 })
            .Labels(new[] { "A", "B", "C" });

        var html = _renderer.Render(chart);
        Assert.Contains("<canvas id=\"my-chart\"", html);
    }

    [Fact]
    public void Chart_RendersChartJsScript()
    {
        var chart = ChartExtensions.Chart("my-chart", ChartType.Line)
            .Data(new[] { 1.0, 2.0 })
            .Labels(new[] { "X", "Y" });

        var html = _renderer.Render(chart);
        Assert.Contains("chart.js", html);
        Assert.Contains("new Chart", html);
    }

    [Fact]
    public void Chart_RendersChartType()
    {
        var chart = ChartExtensions.Chart("c1", ChartType.Pie)
            .Data(new[] { 1.0, 2.0, 3.0 })
            .Labels(new[] { "A", "B", "C" });

        var html = _renderer.Render(chart);
        Assert.Contains("type:'pie'", html);
    }

    [Fact]
    public void Chart_WithTitle_RendersTitle()
    {
        var chart = ChartExtensions.Chart("c1", ChartType.Bar)
            .Data(new[] { 1.0 })
            .Labels(new[] { "A" })
            .Title("My Chart");

        var html = _renderer.Render(chart);
        Assert.Contains("My Chart", html);
    }

    [Fact]
    public void Chart_WithDatasets_RendersMultipleDatasets()
    {
        var chart = ChartExtensions.Chart("c1", ChartType.Line)
            .Dataset("Series 1", new[] { 1.0, 2.0 })
            .Dataset("Series 2", new[] { 3.0, 4.0 })
            .Labels(new[] { "A", "B" });

        var html = _renderer.Render(chart);
        Assert.Contains("Series 1", html);
        Assert.Contains("Series 2", html);
    }

    [Fact]
    public void Chart_WithHeight_SetsContainerHeight()
    {
        var chart = ChartExtensions.Chart("c1", ChartType.Bar)
            .Data(new[] { 1.0 })
            .Labels(new[] { "A" })
            .Height(300);

        var html = _renderer.Render(chart);
        Assert.Contains("height: 300px", html);
    }

    [Fact]
    public void Chart_WithColor_RendersColor()
    {
        var chart = ChartExtensions.Chart("c1", ChartType.Bar)
            .Data(new[] { 1.0, 2.0 })
            .Labels(new[] { "A", "B" })
            .DatasetColor("red");

        var html = _renderer.Render(chart);
        Assert.Contains("red", html);
    }
}
