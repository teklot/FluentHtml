using System.Text.Json;
using Microsoft.AspNetCore.Antiforgery;

namespace FluentHtml.Samples.Components;

public static class Layout
{
    private const string TokenCacheKey = "FluentHtml.AntiforgeryToken";

    public static PageElement Page(HttpContext http, params Node[] content)
    {
        var tokens = GetAntiforgeryTokens(http);
        var headersJson = JsonSerializer.Serialize(
            new Dictionary<string, string> { [tokens.HeaderName!] = tokens.RequestToken! });

        return new PageElement(
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
            ).HxHeaders(headersJson)
        ).Lang("en");
    }

    private static AntiforgeryTokenSet GetAntiforgeryTokens(HttpContext http)
    {
        if (http.Items.TryGetValue(TokenCacheKey, out var cached) && cached is AntiforgeryTokenSet tokens)
            return tokens;

        var antiforgery = http.RequestServices.GetRequiredService<IAntiforgery>();
        tokens = antiforgery.GetAndStoreTokens(http);
        http.Items[TokenCacheKey] = tokens;
        return tokens;
    }

    private static Element RenderNavbar()
    {
        return Navbar(
            Div(
                NavbarBrand("FluentHtml.Samples").Href("/"),
                NavbarToggler().Controls("mainNavCollapse").DataTarget("#mainNavCollapse"),
                NavbarCollapse(
                    NavbarNav(
                        NavbarNavItem(A("Home").Href("/").Class("nav-link")),
                        NavbarNavItem(A("Core").Href("/core").Class("nav-link")),
                        NavbarNavItem(A("HTMX").Href("/htmx").Class("nav-link")),
                        NavbarNavItem(A("Bootstrap").Href("/bootstrap").Class("nav-link")),
                        NavbarNavItem(A("Dashboard").Href("/dashboard").Class("nav-link")),
                        NavbarNavItem(A("Forms").Href("/forms").Class("nav-link")),
                        NavbarNavItem(A("Todo").Href("/todo").Class("nav-link")),
                        NavbarNavItem(A("Customers").Href("/customers").Class("nav-link"))
                    )
                ).Id("mainNavCollapse")
            ).Class("container")
        ).Dark().ExpandLg().Class("bg-dark").Id("mainNav");
    }
}
