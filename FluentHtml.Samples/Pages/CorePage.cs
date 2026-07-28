using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class CorePage
{
    public static IResult Render(HttpContext http)
    {
        var renderer = new Renderer();
        return Layout.Page(http,
            BreadcrumbHelper.MakeBreadcrumb(("Home", "/"), ("Core Elements", null)),
            H1("FluentHtml Core"),

            SectionHelper.ShowSection("Node Hierarchy", Div(
                Div(Code("Node")).Class("fw-bold"),
                Div(Div("+-- ").Class("text-muted"), Div(Code("Element")).Class("fw-bold"), Div(" \u00E0 single HTML tag").Class("text-muted")),
                Div(Div("+-- ").Class("text-muted"), Div(Code("TextNode")).Class("fw-bold"), Div(" \u00E0 plain text, HTML encoded").Class("text-muted")),
                Div(Div("+-- ").Class("text-muted"), Div(Code("RawHtml")).Class("fw-bold"), Div(" \u00E0 trusted HTML, not encoded").Class("text-muted")),
                Div(Div("+-- ").Class("text-muted"), Div(Code("Fragment")).Class("fw-bold"), Div(" \u00E0 groups siblings without wrapper").Class("text-muted")),
                Div(Div("+-- ").Class("text-muted"), Div(Code("Component")).Class("fw-bold"), Div(" \u00E0 reusable UI, composes nodes").Class("text-muted"))
            ).Class("p-3 bg-light rounded font-monospace small")),

            SectionHelper.ShowSection("HTML Elements", Div(
                H4("Text"),
                Div(P(new EmElement("Emphasis text")),
                    P(new StrongElement("Strong/bold text")),
                    P(new SmallElement("Small text")),
                    P(new MarkElement("Highlighted text")),
                    P(new CodeElement("Inline code")),
                    P(new KbdElement("Keyboard input")),
                    P(new SampElement("Sample output")),
                    P(new VarElement("Variable")),
                    P(new AbbrElement("abbreviation").Title("Abbr")),
                    P(new SubElement("subscript")),
                    P(new SupElement("superscript")),
                    P(new DelElement("strikethrough text"))
                ).Class("mb-3"),
                H4("Inline"),
                Div(new SpanElement("Span"),
                    new BrElement(),
                    new HrElement(),
                    new AnchorElement("Link").Href("#"),
                    new ImgElement().Src("/placeholder.png").Alt("Image")
                ).Class("mb-3"),
                H4("Block"),
                Div(
                    new BlockquoteElement(new ParagraphElement("Blockquote text")),
                    new PreElement("Preformatted\ncode block"),
                    new FigureElement(
                        new FigcaptionElement("Figure caption")
                    ),
                    new AddressElement("123 Main St, City"),
                    new CiteElement("Citation"),
                    new DfnElement("Definition term")
                ).Class("mb-3"),
                H4("Lists"),
                Div(
                    new UlElement(new LiElement("Unordered 1"), new LiElement("Unordered 2")),
                    new OlElement(new LiElement("Ordered 1"), new LiElement("Ordered 2"))
                ).Class("mb-3"),
                H4("Details/Summary"),
                new DetailsElement(
                    new SummaryElement("Click to expand"),
                    new ParagraphElement("Hidden content revealed!")
                )
            )),

            SectionHelper.ShowSection("Fluent Attributes", Div(
                new DivElement().Id("fluent-demo").Class("p-3 bg-light rounded"),
                P(new CodeElement("Id(), Class(), Style(), Data(), Aria(), Role(), Hidden(), Disabled(), Required(), ReadOnly(), Checked(), Custom(), On()")),
                P(new CodeElement("AttributeCollection: Set(), SetBool(), Has(), Get(), Remove(), GetAll()"))
            )),

            SectionHelper.ShowSection("Fragment & RawHtml", Div(
                P("Fragment: renders children without a wrapper element."),
                P(new RawHtml("<strong>RawHtml</strong> content - <em>not</em> HTML-encoded")),
                P("TextNode: always HTML-encoded. <script> tags become &lt;script&gt;.")
            )),

            SectionHelper.ShowSection("Renderer & HtmlWriter", Div(
                P("The Renderer converts component trees to clean HTML strings."),
                P(new StrongElement("Renderer.Render(Node)")),
                new PreElement(
                    renderer.Render(Div(H3("Demo"), P("Rendered inline")).Class("p-3"))
                ).Class("bg-dark text-light p-3 rounded small")
            )),

            SectionHelper.ShowSection("HtmlEncoder", Div(
                P(new StrongElement("HtmlEncoder.Encode()")),
                P(new TextNode("Input: "), new CodeElement("<script>alert('xss')</script>")),
                P(new TextNode("Output: "), new CodeElement(HtmlEncoder.Encode("<script>alert('xss')</script>"))),
                P("All user text is automatically encoded. RawHtml bypasses encoding for trusted content.")
            )),

            SectionHelper.ShowSection("HtmlResult", Div(
                P("HtmlResult implements "),
                new CodeElement("IResult"),
                P(" - returns HTML directly from Minimal API endpoints."),
                new PreElement(
                    "app.MapGet(\"/api\", () =>\n{\n    return Alert(\"OK\").Success().ToHtmlResult();\n});"
                ).Class("bg-dark text-light p-3 rounded small font-monospace")
            ))
        ).ToHtmlResult();
    }
}
