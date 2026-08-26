using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class HomePage
{
    public static IResult Render(HttpContext http)
    {
        return Layout.Page(http,
            Div(
                Div(
                    H1("FluentHtml").Class("display-4 fw-bold mb-2"),
                    P("Build rich server-rendered HTML with a fluent, type-safe C# API.")
                        .Class("lead text-muted mb-4")
                ).Class("text-center py-5"),

                Div(
                    Div(
                        CardHelpers.PackageCard("FluentHtml.Core", "Core",
                            "Node tree, Element<T>, Renderer, ~120 HTML elements, Markdown, Icons, Badge, Breadcrumb, Tree", "box-seam"),
                        CardHelpers.PackageCard("FluentHtml.Http", "HTTP",
                            "FluentRouter, IResult integration, minimal API helpers", "globe2"),
                        CardHelpers.PackageCard("FluentHtml.Htmx", "HTMX",
                            "HxGet, HxPost, HxSwap, HxTarget, HxTrigger, 20+ extensions", "arrow-repeat"),
                        CardHelpers.PackageCard("FluentHtml.Bootstrap", "Bootstrap",
                            "Card, Alert, Navbar, Modal, Tabs, DataGrid, Charts, Layouts, Tree, Spinner, Icons", "palette2"),
                        CardHelpers.PackageCard("FluentHtml.Forms", "Forms",
                            "Form, InputFor, SelectFor, AutoForm<T>, File Upload, Drag & Drop", "ui-checks"),
                        CardHelpers.PackageCard("FluentHtml.Validation", "Validation",
                            "ValidationMessage, ValidationSummary, client + server", "shield-check")
                    ).Class("row g-4 mb-5")
                ),

                Div(
                    H2("Why FluentHtml?").Class("text-center mb-4"),
                    Div(
                        Div(
                            Div(BiIcon("code-slash")).Class("text-primary display-6 mb-3"),
                            H5("Type-Safe").Class("fw-semibold"),
                            P("No string templates. Every element, attribute, and child is compile-time checked.")
                                .Class("text-muted")
                        ).Class("col-md-4 text-center p-3"),
                        Div(
                            Div(BiIcon("boxes")).Class("text-success display-6 mb-3"),
                            H5("Server-Rendered").Class("fw-semibold"),
                            P("Full HTML on every request. No JavaScript framework needed. Works with minimal APIs or Razor.")
                                .Class("text-muted")
                        ).Class("col-md-4 text-center p-3"),
                        Div(
                            Div(BiIcon("puzzle")).Class("text-warning display-6 mb-3"),
                            H5("Composable").Class("fw-semibold"),
                            P("Mix packages freely. Use HTMX without Bootstrap. Use Forms without HTMX. Every package is independent.")
                                .Class("text-muted")
                        ).Class("col-md-4 text-center p-3")
                    ).Class("row g-4 mb-5")
                ),

                Div(
                    H2("Quick Start").Class("text-center mb-4"),
                    P("Up and running in three steps.").Class("text-center text-muted mb-4"),
                    Div(
                        Div(
                            Badge("1").Pill().Primary().Class("mb-2"),
                            H5("Install packages"),
                            Pre(Code("dotnet add package FluentHtml.Core")).Class("bg-dark text-light p-3 rounded")
                        ).Class("col-md-4"),
                        Div(
                            Badge("2").Pill().Success().Class("mb-2"),
                            H5("Build your page"),
                            Pre(Code("H1(\"Hello World\").Class(\"display-6\")")).Class("bg-dark text-light p-3 rounded")
                        ).Class("col-md-4"),
                        Div(
                            Badge("3").Pill().Warning().Class("mb-2"),
                            H5("Return it"),
                            Pre(Code("return page.ToHtmlResult();")).Class("bg-dark text-light p-3 rounded")
                        ).Class("col-md-4")
                    ).Class("row g-4")
                )
            )
        ).ToHtmlResult();
    }
}
