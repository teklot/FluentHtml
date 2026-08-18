using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class HomePage
{
    public static IResult Render(HttpContext http)
    {
        return Layout.Page(http,
            H1("FluentHtml Showcase"),
            P("Every package, every component, every method - live and working.")
                .Class("lead text-muted"),

            Div(
                CardHelpers.PackageCard("FluentHtml.Core", "Core", "Node, Element, Fragment, RawHtml, TextNode, Renderer, HtmlWriter, HtmlEncoder, ~120 HTML elements, Markdown, Icons, Badge, Breadcrumb"),
                CardHelpers.PackageCard("FluentHtml.Http", "Http", "FluentRouter, HtmlResult (IResult), ToHtmlResult(), Minimal API integration"),
                CardHelpers.PackageCard("FluentHtml.Htmx", "HTMX", "HxGet, HxPost, HxSwap, HxTarget, HxTrigger, HxConfirm, HtmxResponse, 20+ extensions"),
                CardHelpers.PackageCard("FluentHtml.Bootstrap", "Bootstrap", "Card, Alert, Button, Navbar, Modal, Accordion, Toast, Dropdown, Pagination, Spinner, Tabs, Icons, ThemeToggle, DataGrid, Charts"),
                CardHelpers.PackageCard("FluentHtml.Forms", "Forms", "Form, InputFor, LabelFor, SelectFor, TextAreaFor, CheckboxFor, AutoForm<T>, File Upload, Drag & Drop"),
                CardHelpers.PackageCard("FluentHtml.Validation", "Validation", "ValidationMessage, ValidationSummary")
            ).Class("row g-4 mb-5"),

            H2("Quick Demo"),
            P("Click any nav link to see that package in action. Every component below is rendered server-side - no JavaScript framework, no Razor templates.")
        ).ToHtmlResult();
    }
}
