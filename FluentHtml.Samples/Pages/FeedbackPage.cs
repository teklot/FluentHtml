using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class FeedbackPage
{
    public static IResult Render(HttpContext http)
    {
        var dialog = ConfirmDialog()
            .Id("confirm-delete")
            .Title("Delete record?")
            .Message("This action is permanent and cannot be undone.")
            .Danger()
            .ConfirmText("Delete")
            .CancelText("Cancel")
            .ConfirmHxDelete("/feedback/confirm-delete")
            .Target("#feedback-toast");

        return Layout.Page(http,
            BreadcrumbHelper.MakeBreadcrumb(("Home", "/"), ("Feedback", null)),
            H1("Feedback & Dialogs").Class("mb-4"),
            P("Confirmation dialogs, toast notifications, and timelines - all rendered server-side.").Class("text-muted mb-4"),

            SectionHelper.ShowSection("Confirmation Dialog", Div(
                P("A Bootstrap modal that replaces the native confirm() dialog. Customizable title, message, and button colors. The confirm button issues an HTMX DELETE and reports the result via toast.").Class("text-muted"),
                Div(
                    Btn(BiIcon("trash"), new TextNode(" Delete item")).Danger().Data("bs-toggle", "modal").Data("bs-target", "#confirm-delete")
                ).Class("mt-3"),
                dialog
            )),

            SectionHelper.ShowSection("Toast Manager", Div(
                P("Enqueue toasts server-side and deliver them via HTMX out-of-band swaps. Bootstrap toasts are initialized automatically.").Class("text-muted"),
                Div(
                    Btn("Success").Success()
                        .HxGet("/feedback/toast/success")
                        .HxSwap("none"),
                    Btn("Error").Danger().Class("ms-2")
                        .HxGet("/feedback/toast/error")
                        .HxSwap("none"),
                    Btn("Warning").Warning().Class("ms-2")
                        .HxGet("/feedback/toast/warning")
                        .HxSwap("none"),
                    Btn("Info").Info().Class("ms-2")
                        .HxGet("/feedback/toast/info")
                        .HxSwap("none")
                ).Class("mt-3"),

                ToastAnchor()
            )),

            SectionHelper.ShowSection("Timeline", Div(
                P("A vertical timeline for ordered events.").Class("text-muted"),
                Div(
                    Timeline()
                        .Add(new TimelineItemComponent("2024-01", "Project Kickoff", "Repository initialized and architecture planned.")
                            .Icon("rocket-takeoff").IconColor("text-primary"))
                        .Add(new TimelineItemComponent("2024-03", "Core Package Released", "v0.1 of FluentHtml.Core with node tree and renderer.")
                            .Icon("box-seam").IconColor("text-success"))
                        .Add(new TimelineItemComponent("2024-06", "Bootstrap Story", "Bootstrap components, forms, and validation shipped.")
                            .Icon("palette").IconColor("text-warning"))
                        .Add(new TimelineItemComponent("2024-09", "Feedback & Dialogs", "v0.5 with confirmation dialogs, toasts, and timelines.")
                            .Icon("bell").IconColor("text-info"))
                ).Class("mt-3")
            ))
        ).ToHtmlResult();
    }

    public static IResult ConfirmDelete(HttpContext http)
    {
        var manager = new ToastManager().Position("toast-top-end").Autohide().Success("Deleted", "The record was deleted successfully.");
        return new HtmxResponse(new RawHtml(""))
            .Oob(manager.RenderOob("beforeend:#feedback-toast"))
            .ToHtmlResult();
    }

    public static IResult ToastSuccess(HttpContext http)
        => ToastOob(new ToastManager().Autohide().Success("Saved", "Your changes were saved."));

    public static IResult ToastError(HttpContext http)
        => ToastOob(new ToastManager().Autohide().Error("Failed", "An error occurred while processing."));

    public static IResult ToastWarning(HttpContext http)
        => ToastOob(new ToastManager().Autohide().Warning("Caution", "Please review your input."));

    public static IResult ToastInfo(HttpContext http)
        => ToastOob(new ToastManager().Autohide().Info("Update", "Your profile was refreshed."));

    private static IResult ToastOob(ToastManager manager)
    {
        manager.Position("toast-top-end");
        return new HtmxResponse(new RawHtml(""))
            .Oob(manager.RenderOob("beforeend:#feedback-toast"))
            .ToHtmlResult();
    }

    private static Node ToastAnchor()
    {
        return new ToastManager().Position("toast-top-end").Render("feedback-toast");
    }
}
