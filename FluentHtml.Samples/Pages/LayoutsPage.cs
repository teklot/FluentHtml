using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class LayoutsPage
{
    public static IResult Render(HttpContext http)
    {
        return Layout.Page(http,
            BreadcrumbHelper.MakeBreadcrumb(("Home", "/"), ("Layouts", null)),
            H1("Layouts"),
            P("Responsive layout components: Sidebar, Dashboard, Split, and Responsive regions for building application shells."),

            SectionHelper.ShowSection("Sidebar", Div(
                P("A vertical navigation component with brand, sections, nav items, and dividers."),
                Div(Sidebar(
                    SidebarNav(
                        SidebarSection(
                            SidebarSectionHeading("Main"),
                            SidebarNavItem(TabLink(BiIcon("speedometer2"), new TextNode(" Dashboard")).Href("#tab-dashboard").Active()),
                            SidebarNavItem(TabLink(BiIcon("graph-up"), new TextNode(" Analytics")).Href("#tab-analytics")),
                            SidebarNavItem(TabLink(BiIcon("file-earmark-bar-graph"), new TextNode(" Reports")).Href("#tab-reports"))
                        ),
                        SidebarDivider(),
                        SidebarSection(
                            SidebarSectionHeading("Management"),
                            SidebarNavItem(TabLink(BiIcon("people"), new TextNode(" Users")).Href("#tab-users")),
                            SidebarNavItem(TabLink(BiIcon("shield-lock"), new TextNode(" Roles")).Href("#tab-roles")),
                            SidebarNavItem(TabLink(BiIcon("gear"), new TextNode(" Settings")).Href("#tab-settings"))
                        )
                    )
                ).Width("280px").Class("bg-light border-end"),
                    TabContent(
                        TabPane(H5("Dashboard"), P("Overview of key metrics and recent activity.")).Id("tab-dashboard").Active().Show(),
                        TabPane(H5("Analytics"), P("Traffic sources, conversion rates, and user behavior.")).Id("tab-analytics"),
                        TabPane(H5("Reports"), P("Scheduled and custom reports for stakeholders.")).Id("tab-reports"),
                        TabPane(H5("Users"), P("Manage user accounts, roles, and permissions.")).Id("tab-users"),
                        TabPane(H5("Roles"), P("Define role-based access control policies.")).Id("tab-roles"),
                        TabPane(H5("Settings"), P("Application configuration and preferences.")).Id("tab-settings")
                    ).Class("flex-grow-1 p-3")
                ).Class("d-flex border rounded overflow-hidden").Style("max-height:500px;overflow-y:auto")
            )),

            SectionHelper.ShowSection("Dashboard Layout", Div(
                P("A pre-built layout combining header, sidebar, and content regions."),
                Div(DashboardLayout(
                    header: new Node[] { },
                    sidebar: new Node[] {
                        SidebarNav(
                            SidebarNavItem(TabLink(BiIcon("speedometer2"), new TextNode(" Overview")).Href("#db-overview").Active()),
                            SidebarNavItem(TabLink(BiIcon("people"), new TextNode(" Customers")).Href("#db-customers")),
                            SidebarNavItem(TabLink(BiIcon("box"), new TextNode(" Products")).Href("#db-products")),
                            SidebarNavItem(TabLink(BiIcon("cart"), new TextNode(" Orders")).Href("#db-orders"))
                        )
                    },
                    content: new Node[] {
                        TabContent(
                            TabPane(
                                Div(H4("Welcome back!"), P("This is the dashboard overview with key metrics."),
                                    Div(Card(CardBody(CardTitle("Quick Stats"), CardText("The sidebar is responsive and collapses on mobile."))).Class("shadow-sm mt-3"))
                                ).Class("p-4")
                            ).Id("db-overview").Active().Show(),
                            TabPane(
                                Div(H4("Customers"), P("View and manage your customer database."),
                                    Div(Card(CardBody(CardTitle("Total Customers"), CardText("1,234 active accounts across all regions."))).Class("shadow-sm mt-3"))
                                ).Class("p-4")
                            ).Id("db-customers"),
                            TabPane(
                                Div(H4("Products"), P("Browse and manage your product catalog."),
                                    Div(Card(CardBody(CardTitle("Product Catalog"), CardText("56 products listed across 8 categories."))).Class("shadow-sm mt-3"))
                                ).Class("p-4")
                            ).Id("db-products"),
                            TabPane(
                                Div(H4("Orders"), P("Track orders and manage fulfillment."),
                                    Div(Card(CardBody(CardTitle("Recent Orders"), CardText("23 orders pending shipment, 156 delivered this month."))).Class("shadow-sm mt-3"))
                                ).Class("p-4")
                            ).Id("db-orders")
                        )
                    }
                )).Class("border rounded overflow-hidden").Style("max-height:450px;overflow:hidden")
            )),

            SectionHelper.ShowSection("Split Layout", Div(
                P("Two-panel layout that stacks vertically on mobile, side-by-side on desktop."),
                Div(SplitLayout(
                    SplitPanel(
                        Div(H5("Left Panel"), P("File tree or navigation goes here.")).Class("p-3")
                    ).FlexGrow1().Class("bg-light"),
                    SplitDivider(),
                    SplitPanel(
                        Div(H5("Right Panel"), P("Main content area goes here.")).Class("p-3")
                    ).FlexGrow1()
                )).Class("border rounded overflow-hidden").Style("max-height:300px;overflow:hidden")
            )),

            SectionHelper.ShowSection("Responsive Layout", Div(
                P("Breakpoint-aware layout regions: header, sidebar, content, and footer."),
                Div(new ResponsiveLayoutComponent(
                    LayoutHeader(
                        Div().Class("bg-white").Style("height:4px")
                    ),
                    Div(
                        new LayoutSidebarComponent(
                            SidebarNav(
                                SidebarNavItem(TabLink(BiIcon("house"), new TextNode(" Home")).Href("#rl-home").Active()),
                                SidebarNavItem(TabLink(BiIcon("journal-text"), new TextNode(" Blog")).Href("#rl-blog")),
                                SidebarNavItem(TabLink(BiIcon("envelope"), new TextNode(" Contact")).Href("#rl-contact"))
                            )
                        ).Width("220px").Class("border-end bg-light p-3"),
                        LayoutContent(
                            TabContent(
                                TabPane(
                                    Div(H5("Home"), P("Welcome to the home page. This content area grows to fill available space."))
                                ).Id("rl-home").Active().Show(),
                                TabPane(
                                    Div(H5("Blog"), P("Read the latest articles and updates from the team."))
                                ).Id("rl-blog"),
                                TabPane(
                                    Div(H5("Contact"), P("Get in touch with us via the form or email."))
                                ).Id("rl-contact")
                            )
                        ).Class("flex-grow-1 p-3")
                    ).Class("d-flex flex-grow-1"),
                    LayoutFooter(
                        Div("Footer content").Class("text-center text-muted py-2 border-top bg-light")
                    )
                ).Class("flex-column").Style("height:400px")).Class("border rounded overflow-hidden")
            ))
        ).ToHtmlResult();
    }
}
