using FluentHtml.Components;
using FluentHtml.Samples.Components;
using static FluentHtml.Components.MarkdownExtensions;

namespace FluentHtml.Samples.Pages;

public static class MarkdownPage
{
    public static IResult Render(HttpContext http)
    {
        var page = Layout.Page(http,
            H1("Markdown Component"),
            P("FluentHtml uses Markdig to render Markdown content as HTML."),
            Hr(),

            H2("Basic Markdown"),
            Card(
                CardBody(Markdown("# Hello World\n\nThis is **bold** and *italic* text.\n\n- Item 1\n- Item 2\n- Item 3"))
            ).Class("mb-4"),

            H2("Links and Code"),
            Card(
                CardBody(Markdown("Visit [Example](https://example.com) for more info.\n\nInline `code` and code blocks:\n\n```csharp\nvar x = 42;\n```"))
            ).Class("mb-4"),

            H2("Tables"),
            Card(
                CardBody(Markdown("| Name   | Role      | Active |\n|--------|-----------|--------|\n| Alice  | Admin     | Yes    |\n| Bob    | Editor    | Yes    |\n| Charlie| Viewer    | No     |", "table table-striped"))
            ).Class("mb-4")
        );

        return page.ToHtmlResult();
    }
}
