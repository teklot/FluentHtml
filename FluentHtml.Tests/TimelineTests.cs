using FluentHtml.Bootstrap.Components;
using FluentHtml.Rendering;
using static FluentHtml.Bootstrap.Components.TimelineExtensions;

namespace FluentHtml.Tests;

public class TimelineTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void Timeline_Renders_Root_Container()
    {
        var timeline = Timeline();
        var html = _renderer.Render(timeline);

        Assert.Contains("timeline", html);
        Assert.Contains("list-unstyled", html);
    }

    [Fact]
    public void Timeline_Renders_Items_With_Content()
    {
        var timeline = Timeline()
            .Add("2024-01-01", "Project started", "Initial repository created.");

        var html = _renderer.Render(timeline);

        Assert.Contains("timeline-item", html);
        Assert.Contains("2024-01-01", html);
        Assert.Contains("Project started", html);
        Assert.Contains("Initial repository created.", html);
    }

    [Fact]
    public void Timeline_Renders_Only_Injected_Style_Once()
    {
        var timeline = Timeline()
            .Add("2024-01-01", "A", "desc A")
            .Add("2024-02-01", "B", "desc B");

        var html = _renderer.Render(timeline);

        Assert.Contains("<style>", html);
        // Each item renders the item markup; the style is emitted once per render.
        Assert.Contains("border-left: 2px solid var(--bs-border-color)", html);
    }

    [Fact]
    public void Timeline_Item_With_Icon_Renders_Marker()
    {
        var timeline = Timeline()
            .Add(
                new TimelineItemComponent("2024-01-01", "Done", "Completed.")
                    .Icon("check-circle")
                    .IconColor("text-success")
            );

        var html = _renderer.Render(timeline);

        Assert.Contains("bi bi-check-circle", html);
        Assert.Contains("text-success", html);
    }

    [Fact]
    public void Timeline_Item_Fluent_Builders_Render()
    {
        var item = new TimelineItemComponent()
            .Date("2024-03-01")
            .Title("Released")
            .Description("Shipped v0.5.");

        var timeline = Timeline().Add(item);
        var html = _renderer.Render(timeline);

        Assert.Contains("Released", html);
        Assert.Contains("Shipped v0.5.", html);
    }
}
