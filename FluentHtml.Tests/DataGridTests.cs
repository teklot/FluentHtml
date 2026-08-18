using FluentHtml.Bootstrap.Components;
using FluentHtml.Rendering;

namespace FluentHtml.Tests;

public class DataGridTests
{
    private readonly Renderer _renderer = new();

    public class Customer
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    [Fact]
    public void DataGrid_RendersTable()
    {
        var grid = DataGridExtensions.DataGrid<Customer>("/api/customers")
            .Column(c => c.Name, "Name")
            .Column(c => c.Email, "Email")
            .CurrentPage(1)
            .TotalItems(0);

        var html = _renderer.Render(grid);
        Assert.Contains("<table", html);
        Assert.Contains("table-striped", html);
    }

    [Fact]
    public void DataGrid_RendersColumnHeaders()
    {
        var grid = DataGridExtensions.DataGrid<Customer>("/api/customers")
            .Column(c => c.Name, "Name")
            .Column(c => c.Email, "Email")
            .CurrentPage(1)
            .TotalItems(0);

        var html = _renderer.Render(grid);
        Assert.Contains("Name", html);
        Assert.Contains("Email", html);
    }

    [Fact]
    public void DataGrid_SortableColumn_HasHxGet()
    {
        var grid = DataGridExtensions.DataGrid<Customer>("/api/customers")
            .Column(c => c.Name, "Name").Sortable()
            .CurrentPage(1)
            .TotalItems(0);

        var html = _renderer.Render(grid);
        Assert.Contains("hx-get=\"/api/customers?sort=Name", html);
        Assert.Contains("hx-target", html);
    }

    [Fact]
    public void DataGrid_WithPaging_RendersPagination()
    {
        var grid = DataGridExtensions.DataGrid<Customer>("/api/customers")
            .Column(c => c.Name, "Name")
            .PageSize(10)
            .CurrentPage(1)
            .TotalItems(25);

        var html = _renderer.Render(grid);
        Assert.Contains("pagination", html);
        Assert.Contains("page-item", html);
    }

    [Fact]
    public void DataGrid_RenderWithData_RendersRows()
    {
        var data = new[]
        {
            new Customer { Name = "Alice", Email = "alice@test.com", Age = 30 },
            new Customer { Name = "Bob", Email = "bob@test.com", Age = 25 }
        };

        var grid = DataGridExtensions.DataGrid<Customer>("/api/customers")
            .Column(c => c.Name, "Name")
            .Column(c => c.Email, "Email")
            .CurrentPage(1)
            .TotalItems(2);

        var node = grid.RenderWithData(data);
        var html = _renderer.Render(node);
        Assert.Contains("Alice", html);
        Assert.Contains("Bob", html);
        Assert.Contains("alice@test.com", html);
    }

    [Fact]
    public void DataGrid_WithId_SetsGridId()
    {
        var grid = DataGridExtensions.DataGrid<Customer>("/api/customers")
            .Column(c => c.Name, "Name")
            .Id("my-grid")
            .CurrentPage(1)
            .TotalItems(0);

        var html = _renderer.Render(grid);
        Assert.Contains("id=\"my-grid\"", html);
    }
}
