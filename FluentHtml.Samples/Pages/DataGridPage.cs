using FluentHtml.Bootstrap.Components;
using FluentHtml.Samples.Components;
using System.Reflection;

namespace FluentHtml.Samples.Pages;

public static class DataGridPage
{
    public class Customer
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int Orders { get; set; }
    }

    private static readonly Customer[] Customers =
    [
        new() { Name = "Alice Johnson", Email = "alice@example.com", Status = "Active", Orders = 12 },
        new() { Name = "Bob Smith", Email = "bob@example.com", Status = "Active", Orders = 8 },
        new() { Name = "Charlie Brown", Email = "charlie@example.com", Status = "Inactive", Orders = 3 },
        new() { Name = "Diana Prince", Email = "diana@example.com", Status = "Active", Orders = 22 },
        new() { Name = "Eve Davis", Email = "eve@example.com", Status = "Pending", Orders = 5 },
        new() { Name = "Frank Miller", Email = "frank@example.com", Status = "Active", Orders = 15 },
        new() { Name = "Grace Lee", Email = "grace@example.com", Status = "Inactive", Orders = 1 },
        new() { Name = "Henry Wilson", Email = "henry@example.com", Status = "Active", Orders = 30 },
        new() { Name = "Ivy Chen", Email = "ivy@example.com", Status = "Pending", Orders = 7 },
        new() { Name = "Jack Taylor", Email = "jack@example.com", Status = "Active", Orders = 18 },
        new() { Name = "Karen White", Email = "karen@example.com", Status = "Inactive", Orders = 2 },
        new() { Name = "Leo Garcia", Email = "leo@example.com", Status = "Active", Orders = 25 },
    ];

    public static IResult Render(HttpContext http)
    {
        var grid = BuildGrid(1, 10, null, null);

        var page = Layout.Page(http,
            H1("DataGrid"),
            P("HTMX-powered data grid with server-side sorting and paging."),
            Hr(),

            grid.RenderWithData(Customers),

            H2("Features"),
            Ul(
                Li("Server-side sorting via HTMX requests"),
                Li("Pagination with page links"),
                Li("Custom cell rendering (e.g., badges for status)"),
                Li("Bootstrap-styled table with striped rows"),
                Li("Configurable page size and column definitions")
            )
        );

        return page.ToHtmlResult();
    }

    public static IResult HandleApiRequest(HttpContext http)
    {
        var sort = http.Request.Query["sort"].FirstOrDefault();
        var sortDir = http.Request.Query["sortDir"].FirstOrDefault();
        var page = int.TryParse(http.Request.Query["page"].FirstOrDefault(), out var p) ? p : 1;
        var pageSize = int.TryParse(http.Request.Query["pageSize"].FirstOrDefault(), out var ps) ? ps : 10;

        var data = Customers.AsEnumerable();

        if (!string.IsNullOrEmpty(sort))
        {
            var prop = typeof(Customer).GetProperty(sort, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (prop is not null)
            {
                data = sortDir == "Desc"
                    ? data.OrderByDescending(r => prop.GetValue(r))
                    : data.OrderBy(r => prop.GetValue(r));
            }
        }

        var paged = data.Skip((page - 1) * pageSize).Take(pageSize).ToArray();
        var grid = BuildGrid(page, pageSize, sort, sortDir);

        return grid.RenderWithData(paged).ToHtmlResult();
    }

    private static DataGridComponent<Customer> BuildGrid(int page, int pageSize, string? sort, string? sortDir)
    {
        var grid = DataGridExtensions.DataGrid<Customer>("/api/customers")
            .Column(c => c.Name, "Name").Sortable()
            .Column(c => c.Email, "Email")
            .Column(c => c.Status, "Status")
                .Render(v => Badge(v?.ToString() ?? "").Success())
            .Column(c => c.Orders, "Orders").Sortable()
            .PageSize(pageSize)
            .CurrentPage(page)
            .TotalItems(Customers.Length)
            .Id("customer-grid");

        if (!string.IsNullOrEmpty(sort))
        {
            var direction = sortDir == "Desc" ? SortDirection.Desc : SortDirection.Asc;
            var columnsField = typeof(DataGridComponent<Customer>).GetField("_columns", BindingFlags.NonPublic | BindingFlags.Instance);
            if (columnsField?.GetValue(grid) is System.Collections.IList columns)
            {
                foreach (var col in columns)
                {
                    if (col is DataGridColumn<Customer> c &&
                        c.PropertyName.Equals(sort, StringComparison.OrdinalIgnoreCase))
                    {
                        c.SortDirection = direction;
                    }
                }
            }
        }

        return grid;
    }
}
