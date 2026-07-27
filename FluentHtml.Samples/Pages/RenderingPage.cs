using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class RenderingPage
{
    public static IResult Render(HttpContext http)
    {
        var renderer = new Renderer();

        var demo = Div(
            H3("HtmlWriter & Renderer Demo"),
            P("The Renderer converts component trees to clean HTML strings.")
        ).Class("p-3 bg-light rounded mb-3");

        var renderedHtml = renderer.Render(demo);

        var encoded = HtmlEncoder.Encode("<script>alert('xss')</script>");

        return Layout.Page(http,
            BreadcrumbHelper.MakeBreadcrumb(("Home", "/"), ("Rendering", null)),
            H1("FluentHtml.Rendering"),

            SectionHelper.ShowSection("Renderer", Div(
                P(new StrongElement("Renderer.Render(Node)")),
                new PreElement(renderedHtml).Class("bg-dark text-light p-3 rounded small")
            )),

            SectionHelper.ShowSection("HtmlEncoder", Div(
                P(new StrongElement("HtmlEncoder.Encode()")),
                P(new TextNode("Input: "), new CodeElement("<script>alert('xss')</script>")),
                P(new TextNode("Output: "), new CodeElement(encoded)),
                P("All user text is automatically encoded. RawHtml bypasses encoding for trusted content.")
            )),

            SectionHelper.ShowSection("HtmlWriter", Div(
                P("HtmlWriter builds HTML via StringBuilder:"),
                new PreElement(
                    "WriteOpenTag(\"div\")  ? <div\n" +
                    "WriteAttribute(\"id\", \"x\")  ? id=\"x\"\n" +
                    "WriteRaw(\">\")  ? id=\"x\">\n" +
                    "WriteText(\"Hello\")  ? Hello (encoded)\n" +
                    "WriteCloseTag(\"div\")  ? </div>"
                ).Class("bg-dark text-light p-3 rounded small font-monospace")
            )),

            SectionHelper.ShowSection("HtmlResult", Div(
                P("HtmlResult implements "),
                new CodeElement("IResult"),
                P(" - returns HTML directly from Minimal API endpoints:"),
                new PreElement(
                    "app.MapGet(\"/api\", () =>\n{\n    return Alert(\"OK\").Success().ToHtmlResult();\n});"
                ).Class("bg-dark text-light p-3 rounded small font-monospace")
            ))
        ).ToHtmlResult();
    }
}
