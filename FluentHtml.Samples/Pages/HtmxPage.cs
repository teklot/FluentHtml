using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class HtmxPage
{
    public static IResult Render()
    {
        return Layout.Page(
            BreadcrumbHelper.MakeBreadcrumb(("Home", "/"), ("HTMX", null)),
            H1("FluentHtml.Htmx"),

            SectionHelper.ShowSection("HTMX Extensions", Div(
                Table(
                    new TheadElement(new TrElement(
                        new ThElement("Method"), new ThElement("Attribute"), new ThElement("Purpose")
                    )),
                    new TbodyElement(
                        CardHelpers.HtmxRow("HxGet", "hx-get", "Load content via GET"),
                        CardHelpers.HtmxRow("HxPost", "hx-post", "Submit via POST"),
                        CardHelpers.HtmxRow("HxPut", "hx-put", "Update via PUT"),
                        CardHelpers.HtmxRow("HxDelete", "hx-delete", "Delete via DELETE"),
                        CardHelpers.HtmxRow("HxPatch", "hx-patch", "Patch via PATCH"),
                        CardHelpers.HtmxRow("HxSwap", "hx-swap", "How to swap response"),
                        CardHelpers.HtmxRow("HxTarget", "hx-target", "Where to swap"),
                        CardHelpers.HtmxRow("HxTrigger", "hx-trigger", "When to trigger"),
                        CardHelpers.HtmxRow("HxConfirm", "hx-confirm", "Confirm dialog"),
                        CardHelpers.HtmxRow("HxBoost", "hx-boost", "Boost all links"),
                        CardHelpers.HtmxRow("HxIndicator", "hx-indicator", "Loading indicator"),
                        CardHelpers.HtmxRow("HxPushUrl", "hx-push-url", "Push browser URL"),
                        CardHelpers.HtmxRow("HxSelect", "hx-select", "Select from response"),
                        CardHelpers.HtmxRow("HxSelectOob", "hx-select-oob", "Out-of-band select"),
                        CardHelpers.HtmxRow("HxSwapOob", "hx-swap-oob", "Out-of-band swap"),
                        CardHelpers.HtmxRow("HxVals", "hx-vals", "Extra values"),
                        CardHelpers.HtmxRow("HxHeaders", "hx-headers", "Extra headers"),
                        CardHelpers.HtmxRow("HxInclude", "hx-include", "Include form data"),
                        CardHelpers.HtmxRow("HxParams", "hx-params", "Parameter handling"),
                        CardHelpers.HtmxRow("HxDisabled", "hx-disabled", "Disable element"),
                        CardHelpers.HtmxRow("HxDisinherit", "hx-disinherit", "Inherit settings"),
                        CardHelpers.HtmxRow("HxEncoding", "hx-encoding", "Content encoding"),
                        CardHelpers.HtmxRow("HxValidate", "hx-validate", "Form validation"),
                        CardHelpers.HtmxRow("HxSync", "hx-sync", "Sync requests")
                    )
                ).Class("table table-striped table-sm"),

                H4("Live HTMX Demo"),
                Div(
                    Btn("Load Table").Primary().HxGet("/htmx/table").HxTarget("#htmx-table").HxIndicator("#htmx-spinner"),
                    Btn("Show Alert").Success().HxGet("/htmx/alert").HxTarget("#htmx-alert"),
                    new SpanElement(" ").Class("mx-1"),
                    new SpinnerComponent().Role("status").Class("htmx-indicator ms-2").Id("htmx-spinner")
                ).Class("mb-3"),
                Div().Id("htmx-table").Class("mb-3"),
                Div().Id("htmx-alert")
            ))
        ).ToHtmlResult();
    }

    public static IResult RenderTable()
    {
        return Table(
            new TheadElement(new TrElement(new ThElement("Name"), new ThElement("Role"), new ThElement("Status"))),
            new TbodyElement(
                new TrElement(new TdElement("Alice"), new TdElement(Badge("Admin").Primary()), new TdElement(Badge("Active").Success())),
                new TrElement(new TdElement("Bob"), new TdElement(Badge("User").Secondary()), new TdElement(Badge("Active").Success())),
                new TrElement(new TdElement("Charlie"), new TdElement(Badge("Editor").Info()), new TdElement(Badge("Inactive").Danger()))
            )
        ).Class("table table-striped").ToHtmlResult();
    }

    public static IResult RenderAlert()
    {
        return Alert("HTMX partial loaded successfully! This HTML was fetched via hx-get.")
            .Success().HxGet("/htmx/alert/dismiss").HxTarget("closest .alert").HxSwap("outerHTML").ToHtmlResult();
    }

    public static IResult DismissAlert()
    {
        return new RawHtml("").ToHtmlResult();
    }
}
