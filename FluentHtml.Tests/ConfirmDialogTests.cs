using FluentHtml.Bootstrap.Components;
using FluentHtml.Nodes;
using FluentHtml.Rendering;
using static FluentHtml.Bootstrap.Components.ConfirmDialogExtensions;

namespace FluentHtml.Tests;

public class ConfirmDialogTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void ConfirmDialog_Renders_Modal_Structure()
    {
        var dialog = ConfirmDialog()
            .Id("confirm-delete")
            .Title("Delete item?")
            .Message("This cannot be undone.")
            .Danger()
            .ConfirmText("Delete");

        var html = _renderer.Render(dialog);

        Assert.Contains("class=\"modal fade\"", html);
        Assert.Contains("id=\"confirm-delete\"", html);
        Assert.Contains("modal-dialog", html);
        Assert.Contains("modal-header", html);
        Assert.Contains("modal-body", html);
        Assert.Contains("modal-footer", html);
    }

    [Fact]
    public void ConfirmDialog_Renders_Title_And_Message()
    {
        var dialog = ConfirmDialog()
            .Id("d")
            .Title("Are you sure?")
            .Message("This action is permanent.");

        var html = _renderer.Render(dialog);

        Assert.Contains("Are you sure?", html);
        Assert.Contains("This action is permanent.", html);
    }

    [Fact]
    public void ConfirmDialog_Confirm_Button_Uses_Custom_Text()
    {
        var dialog = ConfirmDialog()
            .Id("d")
            .ConfirmText("Yes, delete it");

        var html = _renderer.Render(dialog);

        Assert.Contains("Yes, delete it", html);
    }

    [Fact]
    public void ConfirmDialog_Danger_Applies_Css_Class()
    {
        var dialog = ConfirmDialog()
            .Id("d")
            .Danger();

        var html = _renderer.Render(dialog);

        Assert.Contains("btn-danger", html);
    }

    [Fact]
    public void ConfirmDialog_Default_Confirm_Is_Primary()
    {
        var dialog = ConfirmDialog()
            .Id("d");

        var html = _renderer.Render(dialog);

        Assert.Contains("btn-primary", html);
    }

    [Fact]
    public void ConfirmDialog_Cancel_Button_Dismisses_Modal()
    {
        var dialog = ConfirmDialog()
            .Id("d")
            .CancelText("Never mind");

        var html = _renderer.Render(dialog);

        Assert.Contains("Never mind", html);
        Assert.Contains("data-bs-dismiss=\"modal\"", html);
    }

    [Fact]
    public void ConfirmDialog_HxDelete_Sets_Attribute_On_Confirm()
    {
        var dialog = ConfirmDialog()
            .Id("d")
            .ConfirmHxDelete("/customers/delete/1");

        var html = _renderer.Render(dialog);

        Assert.Contains("hx-delete=\"/customers/delete/1\"", html);
    }

    [Fact]
    public void ConfirmDialog_HxPost_Sets_Attribute_On_Confirm()
    {
        var dialog = ConfirmDialog()
            .Id("d")
            .ConfirmHxPost("/submit");

        var html = _renderer.Render(dialog);

        Assert.Contains("hx-post=\"/submit\"", html);
    }

    [Fact]
    public void ConfirmDialog_Target_And_Swap_Are_Applied()
    {
        var dialog = ConfirmDialog()
            .Id("d")
            .ConfirmHxDelete("/items/1")
            .Target("closest .modal")
            .Swap("outerHTML");

        var html = _renderer.Render(dialog);

        Assert.Contains("hx-target=\"closest .modal\"", html);
        Assert.Contains("hx-swap=\"outerHTML\"", html);
    }

    [Fact]
    public void ConfirmDialog_ConfirmMessage_Sets_HxConfirm()
    {
        var dialog = ConfirmDialog()
            .Id("d")
            .ConfirmHxDelete("/items/1")
            .ConfirmMessage("Double-check this action.");

        var html = _renderer.Render(dialog);

        Assert.Contains("hx-confirm=\"Double-check this action.\"", html);
    }

    [Fact]
    public void ConfirmDialog_Trigger_Sets_Modal_Toggle_Data()
    {
        var dialog = ConfirmDialog()
            .Id("confirm-123");

        var trigger = dialog.Trigger("Delete");

        var html = _renderer.Render(trigger);

        Assert.Contains("data-bs-toggle=\"modal\"", html);
        Assert.Contains("data-bs-target=\"#confirm-123\"", html);
        Assert.Contains("Delete", html);
    }

    [Fact]
    public void ConfirmDialog_Without_Id_Throws()
    {
        var dialog = ConfirmDialog();

        Assert.Throws<InvalidOperationException>(() => _renderer.Render(dialog));
    }
}
