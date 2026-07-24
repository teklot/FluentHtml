namespace FluentHtml.Samples.Components;

public static class Layout
{
    public static HtmlElement Page(params Node[] content)
    {
        return new HtmlElement(
            new HeadElement(
                new TitleElement("FluentHtml Showcase"),
                Meta().Charset("utf-8"),
                Meta().Name("viewport").Content("width=device-width, initial-scale=1"),
                Link().Href("https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css").Rel("stylesheet"),
                Script().Src("https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"),
                Script().Src("https://unpkg.com/htmx.org@2.0.4/dist/htmx.min.js")
            ),
            new BodyElement(
                RenderNavbar(),
                new MainElement(content).Class("container py-4")
            )
        );
    }

    private static Element RenderNavbar()
    {
        return Navbar(
            Div(
                NavbarBrand("FluentHtml").Href("/"),
                NavbarToggler().Controls("mainNavCollapse").DataTarget("#mainNavCollapse"),
                NavbarCollapse(
                    NavbarNav(
                        NavbarNavItem(A("Home").Href("/").Class("nav-link")),
                        NavbarNavItem(A("Core").Href("/core").Class("nav-link")),
                        NavbarNavItem(A("HTMX").Href("/htmx").Class("nav-link")),
                        NavbarNavItem(A("Bootstrap").Href("/bootstrap").Class("nav-link")),
                        NavbarNavItem(A("Rendering").Href("/rendering").Class("nav-link")),
                        NavbarNavItem(A("Forms").Href("/forms").Class("nav-link"))
                    )
                ).Id("mainNavCollapse")
            ).Class("container")
        ).Dark().ExpandLg().Class("bg-dark").Id("mainNav");
    }
}
