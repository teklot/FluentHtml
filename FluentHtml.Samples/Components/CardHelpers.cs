namespace FluentHtml.Samples.Components;

public static class CardHelpers
{
    public static DivElement PackageCard(string name, string tag, string description)
    {
        return Div(
            Card(
                CardBody(
                    Div(new StrongElement(name), Badge(tag).Secondary().Class("ms-2")).Class("mb-2"),
                    CardText(description)
                )
            ).Class("h-100 shadow-sm")
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
