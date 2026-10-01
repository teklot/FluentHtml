using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class BootstrapPage
{
    public static IResult Render(HttpContext http)
    {
        return Layout.Page(http,
            BreadcrumbHelper.MakeBreadcrumb(("Home", "/"), ("Bootstrap", null)),
            H1("FluentHtml.Bootstrap"),

            SectionHelper.ShowSection("Alerts", Div(
                Alert("Primary alert - informational message.").Primary(),
                Alert("Success! Record saved.").Success(),
                Alert("Warning - check your input.").Warning(),
                Alert("Danger! Something went wrong.").Danger(),
                Alert("Info - just so you know.").Info(),
                Alert("Light alert on dark background.").Light(),
                Alert("Dark alert with light text.").Dark(),
                Alert("Secondary alert.").Secondary()
            ).Class("d-flex flex-column gap-2")),

            SectionHelper.ShowSection("Badges", Div(
                Badge("Primary").Primary(),
                Badge("Secondary").Secondary(),
                Badge("Success").Success(),
                Badge("Danger").Danger(),
                Badge("Warning").Warning(),
                Badge("Info").Info(),
                Badge("Light").Light(),
                Badge("Dark").Dark(),
                Badge("Pill").Primary().Pill()
            ).Class("d-flex flex-wrap gap-2")),

            SectionHelper.ShowSection("Buttons", Div(
                H4("Solid"),
                Div(Btn("Primary").Primary(), Btn("Secondary").Secondary(), Btn("Success").Success(),
                    Btn("Danger").Danger(), Btn("Warning").Warning(), Btn("Info").Info(),
                    Btn("Light").Light(), Btn("Dark").Dark(), Btn("Link").Link()
                ).Class("d-flex flex-wrap gap-2 mb-3"),
                H4("Outline"),
                Div(Btn("Outline Primary").OutlinePrimary(), Btn("Outline Secondary").OutlineSecondary(),
                    Btn("Outline Success").OutlineSuccess(), Btn("Outline Danger").OutlineDanger(),
                    Btn("Outline Warning").OutlineWarning(), Btn("Outline Info").OutlineInfo(),
                    Btn("Outline Light").OutlineLight(), Btn("Outline Dark").OutlineDark()
                ).Class("d-flex flex-wrap gap-2 mb-3"),
                H4("Sizes"),
                Div(Btn("Small").Primary().Small(), Btn("Default").Primary(), Btn("Large").Primary().Large()
                ).Class("d-flex flex-wrap gap-2 mb-3"),
                H4("States"),
                Div(Btn("Active").Primary().Active(), Btn("Disabled").Primary().Disabled()
                ).Class("d-flex flex-wrap gap-2 mb-3"),
                H4("Block"),
                Btn("Full Width Block Button").Primary().Block()
            )),

            SectionHelper.ShowSection("Cards", Div(
                Card(
                    CardHeader("Card Header"),
                    CardBody(
                        CardTitle("Card Title"),
                        CardText("Some quick example text to build on the card title."),
                        Btn("Go somewhere").Primary()
                    ),
                    CardFooter("Card Footer")
                ).Class("shadow-sm"),
                Card(
                    CardBody(
                        CardTitle("Simple Card"),
                        CardText("No header or footer.")
                    )
                ).Class("shadow-sm")
            ).Class("row g-3")),

            SectionHelper.ShowSection("Navbar", Navbar(
                Div(
                    NavbarBrand("Brand").Href("#"),
                    NavbarToggler().Controls("navCollapse").DataTarget("#navCollapse"),
                    NavbarCollapse(
                        NavbarNav(
                            NavbarNavItem(A("Home").Href("#").Class("nav-link active")),
                            NavbarNavItem(A("Features").Href("#").Class("nav-link")),
                            NavbarNavItem(A("Pricing").Href("#").Class("nav-link"))
                        ),
                        NavbarText("Signed in as Admin")
                    ).Id("navCollapse")
                ).Class("container")
            ).Dark().ExpandLg().Class("bg-dark rounded mb-3")),

            SectionHelper.ShowSection("Modal", Div(
                Btn("Open Modal").Primary().Data("bs-toggle", "modal").Data("bs-target", "#demoModal"),
                Modal(
                    ModalDialog(
                        ModalContent(
                            ModalHeader(ModalTitle("Demo Modal"), ModalCloseButton()),
                            ModalBody("This modal is built entirely with FluentHtml Bootstrap components."),
                            ModalFooter(
                                Btn("Close").Secondary().Data("bs-dismiss", "modal"),
                                Btn("Save Changes").Primary()
                            )
                        )
                    )
                ).Fade().Id("demoModal")
            )),

            SectionHelper.ShowSection("Accordion", Accordion(
                AccordionItem(
                    AccordionHeader(AccordionButton("Accordion Item #1").Data("bs-toggle", "collapse").Data("bs-target", "#collapse1")),
                    AccordionCollapse(
                        AccordionBody("Content for accordion item #1. This collapses and expands.")
                    ).Show().Id("collapse1").Data("bs-parent", "#demoAccordion")
                ),
                AccordionItem(
                    AccordionHeader(AccordionButton("Accordion Item #2").Collapsed().Data("bs-toggle", "collapse").Data("bs-target", "#collapse2")),
                    AccordionCollapse(
                        AccordionBody("Content for accordion item #2.")
                    ).Id("collapse2").Data("bs-parent", "#demoAccordion")
                ),
                AccordionItem(
                    AccordionHeader(AccordionButton("Accordion Item #3").Collapsed().Data("bs-toggle", "collapse").Data("bs-target", "#collapse3")),
                    AccordionCollapse(
                        AccordionBody("Content for accordion item #3.")
                    ).Id("collapse3").Data("bs-parent", "#demoAccordion")
                )
            ).Id("demoAccordion")),

            SectionHelper.ShowSection("Dropdown", Div(
                Dropdown(
                    DropdownToggle("Action").Data("bs-toggle", "dropdown"),
                    DropdownMenu(
                        DropdownHeader("Actions"),
                        DropdownItem("Edit").Href("#"),
                        DropdownItem("Duplicate").Href("#"),
                        DropdownDivider(),
                        DropdownItem("Delete").Href("#").Class("text-danger")
                    )
                )
            )),

            SectionHelper.ShowSection("Pagination", Pagination(
                PaginationList(
                    PageItem(PageLink("Previous").Href("#").AriaLabel("Previous")),
                    PageItem(PageLink("1").Href("#")),
                    PageItem(PageLink("2").Href("#")).Active(),
                    PageItem(PageLink("3").Href("#")),
                    PageItem(PageLink("Next").Href("#").AriaLabel("Next"))
                ).Small()
            ).AriaLabel("Demo pagination")),

            SectionHelper.ShowSection("Breadcrumb", Div(
                Breadcrumb(
                    BreadcrumbList(
                        BreadcrumbItem(BreadcrumbLink("Home").Href("#")),
                        BreadcrumbItem(BreadcrumbLink("Library").Href("#")),
                        BreadcrumbItem("Data").Active().AriaCurrent("page")
                    )
                ).AriaLabel("breadcrumb"),
                new SmallElement("Custom separator").Class("d-block mt-3 mb-1 text-muted"),
                Breadcrumb(
                    BreadcrumbList(
                        BreadcrumbItem(BreadcrumbLink("Home").Href("#")),
                        BreadcrumbItem(BreadcrumbLink("Library").Href("#")),
                        BreadcrumbItem("Data").Active().AriaCurrent("page")
                    ).Separator(">")
                ).AriaLabel("breadcrumb with custom separator"),
                new SmallElement("Collapsible trailing items").Class("d-block mt-3 mb-1 text-muted"),
                Breadcrumb(
                    BreadcrumbCollapse(2,
                        BreadcrumbItem(BreadcrumbLink("Home").Href("#")),
                        BreadcrumbItem(BreadcrumbLink("Library").Href("#")),
                        BreadcrumbItem(BreadcrumbLink("Reports").Href("#")),
                        BreadcrumbItem(BreadcrumbLink("Archive").Href("#")),
                        BreadcrumbItem(BreadcrumbLink("Detail").Href("#")).Active().AriaCurrent("page")
                    )
                ).AriaLabel("collapsible breadcrumb")
            )),

            SectionHelper.ShowSection("Spinner", Div(
                Spinner().Role("status"),
                Spinner().Primary().Role("status").Class("ms-2"),
                Spinner().Success().Small().Role("status").Class("ms-2"),
                SpinnerGrow().Class("ms-2"),
                SpinnerGrow().Primary().Class("ms-2"),
                SpinnerGrow().Success().Small().Class("ms-2")
            ).Class("d-flex align-items-center")),

            SectionHelper.ShowSection("Bootstrap Icons", Div(
                P("Framework-agnostic icon abstraction with Bootstrap Icons implementation. Use "),
                new CodeElement("BiIcon(\"icon-name\")"),
                P(" to render any Bootstrap Icon."),
                Div(
                    BiIcon("house"),
                    BiIcon("person"),
                    BiIcon("gear"),
                    BiIcon("star"),
                    BiIcon("heart"),
                    BiIcon("trash"),
                    BiIcon("pencil"),
                    BiIcon("search"),
                    BiIcon("bell"),
                    BiIcon("envelope")
                ).Class("d-flex flex-wrap gap-3 fs-4 mb-3"),
                new PreElement(
                    "BiIcon(\"house\")    // <i class=\"bi bi-house\"></i>\nBiIcon(\"person\")   // <i class=\"bi bi-person\"></i>\nBiIcon(\"gear\")     // <i class=\"bi bi-gear\"></i>"
                ).Class("bg-dark text-light p-3 rounded small font-monospace")
            )),

            SectionHelper.ShowSection("Theme Toggle", Div(
                P("Dark/light mode toggle button with persistence via localStorage."),
                Div(new ThemeToggleComponent()).Class("mb-3")
            )),

            SectionHelper.ShowSection("DataGrid & Charts", Div(
                P("HTMX-powered sortable/paginated data grid and Chart.js wrappers."),
                Div(
                    A("See DataGrid demo").Href("/datagrid").Class("btn btn-outline-primary btn-sm me-2"),
                    A("See Charts demo").Href("/charts").Class("btn btn-outline-primary btn-sm")
                )
            )),

            SectionHelper.ShowSection("Tabs", Div(
                P("Bootstrap tabs for organizing content into switchable panels."),
                Tabs(
                    TabItem(TabLink("Tab 1").Href("#bsTab1").Active()),
                    TabItem(TabLink("Tab 2").Href("#bsTab2")),
                    TabItem(TabLink("Tab 3").Href("#bsTab3"))
                ).Class("mb-2"),
                TabContent(
                    TabPane(new TextNode("Content for tab 1.")).Id("bsTab1").Active().Show(),
                    TabPane(new TextNode("Content for tab 2.")).Id("bsTab2"),
                    TabPane(new TextNode("Content for tab 3.")).Id("bsTab3")
                ).Class("p-3 border border-top-0 rounded-bottom mb-3"),
                Div(
                    A("See full Tabs demo").Href("/tabs").Class("btn btn-outline-primary btn-sm")
                )
            )),

            SectionHelper.ShowSection("Toast", Div(
                ToastContainer(
                    Toast(
                        ToastHeader(
                            new StrongElement("Toast Title").Class("me-auto"),
                            new SmallElement("Just now...").Class("text-muted"),
                            ToastCloseButton()
                        ),
                        ToastBody("This is a toast notification built with FluentHtml components.")
                    ).Show().Id("demoToast")
                ).PositionTopEnd()
            ).Style("min-height:100px"))
        ).ToHtmlResult();
    }
}
