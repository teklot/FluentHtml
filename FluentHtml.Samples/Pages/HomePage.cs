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
                CardHelpers.PackageCard("FluentHtml", "Core", "Node, Element, Fragment, RawHtml, TextNode, ~100 HTML elements, fluent attributes"),
                CardHelpers.PackageCard("FluentHtml.Rendering", "Rendering", "Renderer, HtmlWriter, HtmlEncoder - component tree to HTML"),
                CardHelpers.PackageCard("FluentHtml.AspNetCore", "AspNetCore", "HtmlResult (IResult), ToHtmlResult(), Minimal API integration"),
                CardHelpers.PackageCard("FluentHtml.Htmx", "HTMX", "HxGet, HxPost, HxSwap, HxTarget, HxTrigger, HxConfirm, 20+ extensions"),
                CardHelpers.PackageCard("FluentHtml.Bootstrap", "Bootstrap", "Card, Alert, Button, Navbar, Modal, Accordion, Toast, Dropdown, Pagination, Badge, Breadcrumb, Spinner"),
                CardHelpers.PackageCard("FluentHtml.Forms", "Forms", "Form, InputFor, LabelFor, SelectFor, TextAreaFor, CheckboxFor (not yet implemented)"),
                CardHelpers.PackageCard("FluentHtml.Validation", "Validation", "ValidationMessage, ValidationSummary (not yet implemented)")
            ).Class("row g-4 mb-5"),

            H2("Quick Demo"),
            P("Click any nav link to see that package in action. Every component below is rendered server-side - no JavaScript framework, no Razor templates.")
        ).ToHtmlResult();
    }
}
