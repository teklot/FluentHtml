using FluentHtml.Bootstrap.Components;
using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class ChartsPage
{
    public static IResult Render(HttpContext http)
    {
        var page = Layout.Page(http,
            H1("Chart Components"),
            P("Chart.js powered charts rendered from C# with a fluent API."),
            Hr(),

            Div(
                Div(
                    Card(
                        CardHeader("Bar Chart - Monthly Revenue"),
                        CardBody(Chart("revenue-chart", ChartType.Bar)
                            .Data(new[] { 12500.0, 19000.0, 15000.0, 22000.0, 18000.0, 25000.0 })
                            .Labels(new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" })
                            .Title("Monthly Revenue")
                            .Height(300))
                    )
                ).Class("col-md-6 mb-4"),
                Div(
                    Card(
                        CardHeader("Line Chart - Growth Trend"),
                        CardBody(Chart("growth-chart", ChartType.Line)
                            .Dataset("Users", new[] { 100.0, 150.0, 230.0, 310.0, 420.0, 580.0 })
                            .Dataset("Revenue", new[] { 50.0, 80.0, 140.0, 200.0, 280.0, 390.0 })
                            .Labels(new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" })
                            .DatasetColor("#0d6efd")
                            .DatasetColor("#198754")
                            .Title("Growth Trend")
                            .Height(300))
                    )
                ).Class("col-md-6 mb-4")
            ).Class("row"),

            Div(
                Div(
                    Card(
                        CardHeader("Pie Chart - Distribution"),
                        CardBody(Chart("dist-chart", ChartType.Pie)
                            .Data(new[] { 35.0, 25.0, 20.0, 15.0, 5.0 })
                            .Labels(new[] { "Desktop", "Mobile", "Tablet", "Other", "Unknown" })
                            .Title("Device Distribution")
                            .Height(300))
                    )
                ).Class("col-md-6 mb-4"),
                Div(
                    Card(
                        CardHeader("Doughnut Chart - Status"),
                        CardBody(Chart("status-chart", ChartType.Doughnut)
                            .Data(new[] { 65.0, 20.0, 10.0, 5.0 })
                            .Labels(new[] { "Active", "Pending", "Inactive", "Closed" })
                            .Title("Order Status")
                            .Height(300))
                    )
                ).Class("col-md-6 mb-4")
            ).Class("row"),

            H2("Features"),
            Ul(
                Li("Supports Bar, Line, Pie, Doughnut, Radar, and PolarArea chart types"),
                Li("Single or multiple datasets"),
                Li("Custom colors per dataset"),
                Li("Responsive sizing with configurable height"),
                Li("Chart.js loaded via CDN")
            )
        );

        return page.ToHtmlResult();
    }
}
