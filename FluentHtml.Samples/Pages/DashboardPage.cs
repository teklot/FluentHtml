using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class DashboardPage
{
    private static readonly List<Order> Orders =
    [
        new(1001, "Acme Corp", "Alice Johnson", 1250.00m, "Completed", "2026-07-20"),
        new(1002, "Globex Inc", "Bob Smith", 890.50m, "Shipped", "2026-07-21"),
        new(1003, "Initech LLC", "Charlie Brown", 2100.00m, "Completed", "2026-07-22"),
        new(1004, "Umbrella Co", "Diana Prince", 450.75m, "Pending", "2026-07-23"),
        new(1005, "Stark Industries", "Tony Stark", 5000.00m, "Completed", "2026-07-24"),
        new(1006, "Wayne Enterprises", "Bruce Wayne", 3200.00m, "Shipped", "2026-07-25"),
        new(1007, "Oscorp", "Norman Osborn", 780.25m, "Pending", "2026-07-26"),
    ];

    private static readonly List<Activity> RecentActivity =
    [
        new("Order #1007 created", "2 minutes ago"),
        new("Invoice #1005 paid", "1 hour ago"),
        new("Customer Diana Prince registered", "3 hours ago"),
        new("Order #1006 shipped", "5 hours ago"),
        new("Refund processed for Order #1002", "Yesterday"),
    ];

    public static IResult Render(HttpContext http)
    {
        return Layout.Page(http,
            BreadcrumbHelper.MakeBreadcrumb(("Home", "/"), ("Dashboard", null)),
            H1("Dashboard").Class("mb-4"),
            Div(
                StatCard("Total Revenue", "$13,321.50", "border-primary"),
                StatCard("Orders", "7", "border-success"),
                StatCard("Customers", "5", "border-info"),
                StatCard("Pending", "2", "border-warning")
            ).Class("row mb-4"),
            Div(
                Div(
                    Card(
                        CardHeader(H4("Recent Orders")),
                        CardBody(RenderOrdersTable())
                    )
                ).Class("col-lg-8 mb-4"),
                Div(
                    Card(
                        CardHeader(H4("Activity")),
                        CardBody(RenderActivityFeed())
                    )
                ).Class("col-lg-4 mb-4")
            ).Class("row")
        ).ToHtmlResult();
    }

    private static Node StatCard(string title, string value, string borderClass)
    {
        return Div(
            Card(
                CardBody(
                    Div(Small(title).Class("text-muted")).Class("mb-1"),
                    Div(H2(value)).Class("card-title")
                )
            ).Class($"border-start border-4 shadow-sm {borderClass}")
        ).Class("col-xl-3 col-md-6 mb-4");
    }

    private static Node RenderOrdersTable()
    {
        var rows = Orders.Select(o => new TrElement(
            new TdElement($"#{o.Id}"),
            new TdElement(o.Customer),
            new TdElement(o.Rep),
            new TdElement(o.Amount.ToString("C")),
            new TdElement(OrderBadge(o.Status)),
            new TdElement(o.Date)
        )).ToArray();

        return Table(
            new TheadElement(new TrElement(
                new ThElement("Order"), new ThElement("Customer"),
                new ThElement("Rep"), new ThElement("Amount"),
                new ThElement("Status"), new ThElement("Date")
            )),
            new TbodyElement(rows)
        ).Class("table table-sm");
    }

    private static Node OrderBadge(string status)
    {
        return status switch
        {
            "Completed" => Badge(status).Success(),
            "Shipped" => Badge(status).Info(),
            "Pending" => Badge(status).Warning(),
            _ => Badge(status).Secondary()
        };
    }

    private static Node RenderActivityFeed()
    {
        var items = RecentActivity.Select(a =>
            Div(
                Div(Span(a.Message)).Class("fw-semibold"),
                Small(a.Time).Class("text-muted")
            ).Class("mb-3 pb-3 border-bottom")
        ).ToArray();

        return Div(items);
    }

    private record Order(int Id, string Customer, string Rep, decimal Amount, string Status, string Date);
    private record Activity(string Message, string Time);
}
