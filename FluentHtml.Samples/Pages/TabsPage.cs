using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class TabsPage
{
    public static IResult Render(HttpContext http)
    {
        return Layout.Page(http,
            BreadcrumbHelper.MakeBreadcrumb(("Home", "/"), ("Tabs", null)),
            H1("Tabs"),
            P("Bootstrap tabs for organizing content into switchable panels. Uses data-bs-toggle for tab switching."),

            SectionHelper.ShowSection("Basic Tabs", Div(
                Tabs(
                    TabItem(TabLink("Home").Href("#home1").Active()),
                    TabItem(TabLink("Profile").Href("#profile1")),
                    TabItem(TabLink("Contact").Href("#contact1"))
                ),
                TabContent(
                    TabPane(new StrongElement("Home"), new TextNode(" - Welcome to the home tab.")).Id("home1").Active().Show(),
                    TabPane(new StrongElement("Profile"), new TextNode(" - Your profile information goes here.")).Id("profile1"),
                    TabPane(new StrongElement("Contact"), new TextNode(" - Get in touch with us.")).Id("contact1")
                ).Class("p-3 border border-top-0 rounded-bottom")
            )),

            SectionHelper.ShowSection("Pills Tabs", Div(
                Tabs(
                    TabItem(TabLink("Active").Href("#pill1").Active()),
                    TabItem(TabLink("Longer Tab Name").Href("#pill2")),
                    TabItem(TabLink("Another").Href("#pill3"))
                ).Pills(),
                TabContent(
                    TabPane(new TextNode("Pill content 1 - this tab is active by default.")).Id("pill1").Active().Show(),
                    TabPane(new TextNode("Pill content 2 - switch to this tab.")).Id("pill2"),
                    TabPane(new TextNode("Pill content 3 - and here too.")).Id("pill3")
                ).Class("p-3 border border-top-0 rounded-bottom")
            )),

            SectionHelper.ShowSection("Fill Tabs", Div(
                Tabs(
                    TabItem(TabLink("First").Href("#fill1").Active()),
                    TabItem(TabLink("Second").Href("#fill2")),
                    TabItem(TabLink("Third").Href("#fill3"))
                ).Fill(),
                TabContent(
                    TabPane(new TextNode("First tab content - tabs fill available width.")).Id("fill1").Active().Show(),
                    TabPane(new TextNode("Second tab content.")).Id("fill2"),
                    TabPane(new TextNode("Third tab content.")).Id("fill3")
                ).Class("p-3 border border-top-0 rounded-bottom")
            )),

            SectionHelper.ShowSection("Vertical Tabs", Div(
                Div(
                    Tabs(
                        TabItem(TabLink("Home").Href("#vtab1").Active()),
                        TabItem(TabLink("Profile").Href("#vtab2")),
                        TabItem(TabLink("Messages").Href("#vtab3")),
                        TabItem(TabLink("Settings").Href("#vtab4"))
                    ).Vertical().Class("col-3"),
                    TabContent(
                        TabPane(new TextNode("Home content - vertical layout.")).Id("vtab1").Active().Show().Class("col-9"),
                        TabPane(new TextNode("Profile content - vertical layout.")).Id("vtab2").Class("col-9"),
                        TabPane(new TextNode("Messages content - vertical layout.")).Id("vtab3").Class("col-9"),
                        TabPane(new TextNode("Settings content - vertical layout.")).Id("vtab4").Class("col-9")
                    ).Class("col-9")
                ).Class("row")
            ))
        ).ToHtmlResult();
    }
}
