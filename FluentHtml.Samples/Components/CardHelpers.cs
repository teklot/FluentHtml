namespace FluentHtml.Samples.Components;

public static class CardHelpers
{
    public static DivElement PackageCard(string name, string tag, string description, string icon)
    {
        return Div(
            Card(
                CardBody(
                    Div(
                        Div(BiIcon(icon).BiSize("fs-3").Class("text-primary"))
                            .Class("bg-primary bg-opacity-10 rounded-circle d-inline-flex align-items-center justify-content-center")
                            .Style("width:48px;height:48px"),
                        Div(
                            Div(new StrongElement(name), Badge(tag).Secondary().Class("ms-2")).Class("mb-1"),
                            CardText(description).Class("text-muted small mb-0")
                        ).Class("ms-3")
                    ).Class("d-flex align-items-start")
                )
            ).Class("h-100 shadow-sm border-0")
        ).Class("col-md-4");
    }

    public static DivElement FeatureCard(string title, string description, string icon)
    {
        return Div(
            Div(
                Div(BiIcon(icon)).Class("text-primary fs-3 mb-3"),
                H5(title).Class("fw-semibold"),
                P(description).Class("text-muted small mb-0")
            ).Class("p-4")
        ).Class("col-md-4");
    }

    public static TrElement HtmxRow(string method, string attr, string purpose)
    {
        return new TrElement(
            new TdElement(new CodeElement(method)),
            new TdElement(new CodeElement(attr)),
            new TdElement(purpose)
        );
    }
}
