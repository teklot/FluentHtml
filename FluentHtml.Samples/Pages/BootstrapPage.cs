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

            SectionHelper.ShowSection("Breadcrumb", Breadcrumb(
                BreadcrumbList(
                    BreadcrumbItem(BreadcrumbLink("Home").Href("#")),
                    BreadcrumbItem(BreadcrumbLink("Library").Href("#")),
                    BreadcrumbItem("Data").Active().AriaCurrent("page")
                )
            ).AriaLabel("breadcrumb")),

            SectionHelper.ShowSection("Spinner", Div(
                Spinner().Role("status"),
                Spinner().Primary().Role("status").Class("ms-2"),
                Spinner().Success().Small().Role("status").Class("ms-2"),
                SpinnerGrow().Class("ms-2"),
                SpinnerGrow().Primary().Class("ms-2"),
                SpinnerGrow().Success().Small().Class("ms-2")
            ).Class("d-flex align-items-center")),

            SectionHelper.ShowSection("Toast", ToastContainer(
                Toast(
                    ToastHeader(
                        new StrongElement("Toast Title"),
                        new SmallElement("just now").Class("text-muted"),
                        ToastCloseButton()
                    ),
                    ToastBody("This is a toast notification built with FluentHtml components.")
                ).Show().Id("demoToast")
            ).PositionTopEnd())
        ).ToHtmlResult();
    }
}
