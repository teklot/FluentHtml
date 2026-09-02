using FluentHtml.Bootstrap.Components;
using FluentHtml.Rendering;

namespace FluentHtml.Tests;

public class ToastManagerTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void Render_Empty_Returns_Empty_Container()
    {
        var manager = new ToastManager();
        var html = _renderer.Render(manager.Render());

        Assert.Contains("toast-container", html);
    }

    [Fact]
    public void Render_Default_Position_Is_Top_End()
    {
        var manager = new ToastManager().Success("Saved", "Changes saved.");
        var html = _renderer.Render(manager.Render());

        Assert.Contains("toast-top-end", html);
    }

    [Fact]
    public void Position_Sets_Container_Class()
    {
        var manager = new ToastManager().Position("toast-bottom-end");
        var html = _renderer.Render(manager.Render());

        Assert.Contains("toast-bottom-end", html);
    }

    [Fact]
    public void Success_Adds_Typed_Toast_With_Color()
    {
        var manager = new ToastManager().Success("Saved", "Changes saved.");
        var html = _renderer.Render(manager.Render());

        Assert.Contains("fluent-toast", html);
        Assert.Contains("border-success", html);
        Assert.Contains("text-success", html);
        Assert.Contains("Saved", html);
        Assert.Contains("Changes saved.", html);
    }

    [Fact]
    public void Error_Adds_Typed_Toast_With_Color()
    {
        var manager = new ToastManager().Error("Failed", "Something broke.");
        var html = _renderer.Render(manager.Render());

        Assert.Contains("text-danger", html);
        Assert.Contains("Failed", html);
        Assert.Contains("Something broke.", html);
    }

    [Fact]
    public void Warning_Adds_Typed_Toast_With_Color()
    {
        var manager = new ToastManager().Warning("Careful", "Check your input.");
        var html = _renderer.Render(manager.Render());

        Assert.Contains("text-warning", html);
    }

    [Fact]
    public void Info_Adds_Typed_Toast_With_Color()
    {
        var manager = new ToastManager().Info("Note", "Just an update.");
        var html = _renderer.Render(manager.Render());

        Assert.Contains("text-info", html);
    }

    [Fact]
    public void Multiple_Toasts_Are_Rendered()
    {
        var manager = new ToastManager()
            .Success("One", "First")
            .Error("Two", "Second");

        var html = _renderer.Render(manager.Render());

        Assert.Contains("First", html);
        Assert.Contains("Second", html);
    }

    [Fact]
    public void MaxVisible_Limits_Rendered_Toasts()
    {
        var manager = new ToastManager()
            .Success("One", "First")
            .Success("Two", "Second")
            .Success("Three", "Third")
            .MaxVisible(2);

        var html = _renderer.Render(manager.Render());

        Assert.Contains("First", html);
        Assert.Contains("Second", html);
        Assert.DoesNotContain("Third", html);
    }

    [Fact]
    public void Autohide_And_Delay_Are_Applied()
    {
        var manager = new ToastManager().Autohide().Delay(3000).Success("X", "Y");
        var html = _renderer.Render(manager.Render());

        Assert.Contains("autohide", html);
        Assert.Contains("data-bs-delay=\"3000\"", html);
    }

    [Fact]
    public void Toast_Has_Accent_And_Contrast_Styling()
    {
        var manager = new ToastManager().Success("X", "Y");
        var html = _renderer.Render(manager.Render());

        Assert.Contains("fluent-toast", html);
        Assert.Contains("fade", html);
        Assert.Contains("toast", html);
    }

    [Fact]
    public void Render_Includes_Initialization_Script()
    {
        var manager = new ToastManager().Success("X", "Y");
        var html = _renderer.Render(manager.Render());

        Assert.Contains("new bootstrap.Toast", html);
        Assert.Contains("toast-initialized", html);
    }

    [Theory]
    [InlineData("Success", "border-success")]
    [InlineData("Error", "border-danger")]
    [InlineData("Warning", "border-warning")]
    [InlineData("Info", "border-info")]
    public void Typed_Toast_Has_Accent_Border(string method, string borderClass)
    {
        var manager = new ToastManager();
        typeof(ToastManager).GetMethod(method)!
            .Invoke(manager, new object[] { "X", "Y" });

        var html = _renderer.Render(manager.Render());

        Assert.Contains(borderClass, html);
    }

    [Fact]
    public void Render_With_ContainerId_Sets_Anchor()
    {
        var manager = new ToastManager().Success("X", "Y");
        var html = _renderer.Render(manager.Render("site-toasts"));

        Assert.Contains("id=\"site-toasts\"", html);
        Assert.Contains("toast-container", html);
    }

    [Fact]
    public void RenderOob_Sets_Swap_Oob_Attribute()
    {
        var manager = new ToastManager().Success("Saved", "Changes saved.");
        var html = _renderer.Render(manager.RenderOob());

        Assert.Contains("hx-swap-oob=\"true\"", html);
    }

    [Fact]
    public void RenderOob_With_Anchor_Selector_Applies_To_Each_Toast()
    {
        var manager = new ToastManager().Success("One", "First").Error("Two", "Second");
        var html = _renderer.Render(manager.RenderOob("beforeend:#toast-anchor"));

        Assert.Contains("hx-swap-oob=\"beforeend:#toast-anchor\"", html);
        Assert.Contains("id=\"toast-", html);
    }

    [Fact]
    public void RenderOob_Respects_MaxVisible()
    {
        var manager = new ToastManager()
            .Success("One", "First")
            .Success("Two", "Second")
            .MaxVisible(1);

        var html = _renderer.Render(manager.RenderOob());

        Assert.Contains("First", html);
        Assert.DoesNotContain("Second", html);
    }

    [Fact]
    public void Clear_Empties_Queue()
    {
        var manager = new ToastManager().Success("One", "First").Clear();
        var html = _renderer.Render(manager.Render());

        Assert.Contains("toast-container", html);
        Assert.DoesNotContain("First", html);
    }
}
