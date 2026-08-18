using FluentHtml.Components;
using FluentHtml.Elements;
using FluentHtml.Nodes;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// Represents a column in a <see cref="DataGridComponent{T}"/>.
/// </summary>
/// <typeparam name="T">The row data type.</typeparam>
public sealed class DataGridColumn<T>
{
    /// <summary>
    /// Gets or sets the column header text.
    /// </summary>
    public string Header { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the property name for data binding and sorting.
    /// </summary>
    public string PropertyName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether this column is sortable.
    /// </summary>
    public bool Sortable { get; set; }

    /// <summary>
    /// Gets or sets the current sort direction when the column is actively sorted.
    /// </summary>
    public SortDirection SortDirection { get; set; }

    /// <summary>
    /// Gets or sets an optional custom render function for the cell value.
    /// </summary>
    public Func<object?, Node>? RenderValue { get; set; }

    /// <summary>
    /// Gets or sets the CSS class for the column header.
    /// </summary>
    public string? HeaderClass { get; set; }

    /// <summary>
    /// Gets or sets the CSS class for each cell in the column.
    /// </summary>
    public string? CellClass { get; set; }
}

/// <summary>
/// Represents the sort direction for a DataGrid column.
/// </summary>
public enum SortDirection
{
    /// <summary>No sorting applied.</summary>
    None,
    /// <summary>Ascending sort order.</summary>
    Asc,
    /// <summary>Descending sort order.</summary>
    Desc
}

/// <summary>
/// An HTMX-powered data grid component with server-side sorting and paging.
/// Renders a Bootstrap-styled table with sortable column headers and pagination controls.
/// </summary>
/// <typeparam name="T">The row data type.</typeparam>
public sealed class DataGridComponent<T> : Component where T : notnull
{
    private readonly string _dataSourceUrl;
    private readonly List<DataGridColumn<T>> _columns = [];
    private int _pageSize = 20;
    private int _currentPage = 1;
    private int _totalItems;
    private string _gridId = "data-grid";
    private string? _cssClass;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataGridComponent{T}"/> class.
    /// </summary>
    /// <param name="dataSourceUrl">The server endpoint URL for HTMX requests (sorting/paging).</param>
    public DataGridComponent(string dataSourceUrl)
    {
        _dataSourceUrl = dataSourceUrl;
    }

    /// <summary>
    /// Adds a column to the data grid.
    /// </summary>
    /// <typeparam name="TValue">The property type.</typeparam>
    /// <param name="property">A property selector expression.</param>
    /// <param name="header">The column header text.</param>
    /// <returns>The current <see cref="DataGridComponent{T}"/> for method chaining.</returns>
    public DataGridComponent<T> Column<TValue>(Expression<Func<T, TValue>> property, string header)
    {
        var propName = GetPropertyName(property);
        _columns.Add(new DataGridColumn<T> { Header = header, PropertyName = propName });
        return this;
    }

    /// <summary>
    /// Marks the most recently added column as sortable.
    /// </summary>
    /// <returns>The current <see cref="DataGridComponent{T}"/> for method chaining.</returns>
    public DataGridComponent<T> Sortable()
    {
        if (_columns.Count > 0)
            _columns[^1].Sortable = true;
        return this;
    }

    /// <summary>
    /// Sets a custom render function for the most recently added column.
    /// </summary>
    /// <param name="render">A function that converts a cell value to a <see cref="Node"/>.</param>
    /// <returns>The current <see cref="DataGridComponent{T}"/> for method chaining.</returns>
    public DataGridComponent<T> Render(Func<object?, Node> render)
    {
        if (_columns.Count > 0)
            _columns[^1].RenderValue = render;
        return this;
    }

    /// <summary>
    /// Sets the page size for server-side paging.
    /// </summary>
    /// <param name="size">The number of rows per page.</param>
    /// <returns>The current <see cref="DataGridComponent{T}"/> for method chaining.</returns>
    public DataGridComponent<T> PageSize(int size)
    {
        _pageSize = size;
        return this;
    }

    /// <summary>
    /// Sets the current page number.
    /// </summary>
    /// <param name="page">The 1-based page number.</param>
    /// <returns>The current <see cref="DataGridComponent{T}"/> for method chaining.</returns>
    public DataGridComponent<T> CurrentPage(int page)
    {
        _currentPage = page;
        return this;
    }

    /// <summary>
    /// Sets the total number of items across all pages.
    /// </summary>
    /// <param name="total">The total item count.</param>
    /// <returns>The current <see cref="DataGridComponent{T}"/> for method chaining.</returns>
    public DataGridComponent<T> TotalItems(int total)
    {
        _totalItems = total;
        return this;
    }

    /// <summary>
    /// Sets the grid element ID (used as the hx-target for paging/sorting).
    /// </summary>
    /// <param name="id">The element ID.</param>
    /// <returns>The current <see cref="DataGridComponent{T}"/> for method chaining.</returns>
    public DataGridComponent<T> Id(string id)
    {
        _gridId = id;
        return this;
    }

    /// <summary>
    /// Sets a CSS class on the table element.
    /// </summary>
    /// <param name="cssClass">The CSS class(es).</param>
    /// <returns>The current <see cref="DataGridComponent{T}"/> for method chaining.</returns>
    public DataGridComponent<T> Class(string cssClass)
    {
        _cssClass = cssClass;
        return this;
    }

    /// <inheritdoc/>
    public override Node Render()
    {
        var wrapper = new DivElement();
        wrapper.Id(_gridId);

        if (!string.IsNullOrEmpty(_cssClass))
            wrapper.Class(_cssClass);

        var table = new TableElement();
        table.Class("table table-striped table-hover");

        var thead = new TheadElement();
        var headerRow = new TrElement();
        foreach (var col in _columns)
        {
            var th = new ThElement();
            if (col.Sortable)
            {
                var sortDir = col.SortDirection == SortDirection.Asc ? "Desc" : "Asc";
                var arrow = col.SortDirection == SortDirection.Asc ? " ↑" : col.SortDirection == SortDirection.Desc ? " ↓" : "";
                var anchor = new AnchorElement(col.Header + arrow);
                anchor.Href("#");
                anchor.Attributes.Set("hx-get", $"{_dataSourceUrl}?sort={col.PropertyName}&sortDir={sortDir}&page={_currentPage}&pageSize={_pageSize}");
                anchor.Attributes.Set("hx-target", $"#{_gridId}");
                anchor.Attributes.Set("hx-swap", "outerHTML");
                th.AddChild(anchor);
            }
            else
            {
                th.AddChild(new TextNode(col.Header));
            }
            headerRow.AddChild(th);
        }
        thead.AddChild(headerRow);
        table.AddChild(thead);

        var tbody = new TbodyElement();
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead && p.GetIndexParameters().Length == 0)
            .ToDictionary(p => p.Name);

        table.AddChild(tbody);

        wrapper.AddChild(table);

        if (_totalItems > _pageSize)
        {
            var totalPages = (int)Math.Ceiling((double)_totalItems / _pageSize);
            var nav = new NavElement();
            var ul = new UlElement();
            ul.Class("pagination");

            for (var i = 1; i <= totalPages; i++)
            {
                var li = new LiElement();
                li.Class("page-item" + (i == _currentPage ? " active" : ""));
                var link = new AnchorElement(i.ToString());
                link.Class("page-link");
                link.Href("#");
                link.Attributes.Set("hx-get", $"{_dataSourceUrl}?page={i}&pageSize={_pageSize}");
                link.Attributes.Set("hx-target", $"#{_gridId}");
                link.Attributes.Set("hx-swap", "outerHTML");
                li.AddChild(link);
                ul.AddChild(li);
            }

            nav.AddChild(ul);
            wrapper.AddChild(nav);
        }

        return wrapper;
    }

    /// <summary>
    /// Renders the data grid with the specified data.
    /// </summary>
    /// <param name="data">The data to display in the grid.</param>
    /// <returns>A <see cref="Node"/> tree representing the rendered grid.</returns>
    public Node RenderWithData(IEnumerable<T> data)
    {
        var root = (DivElement)Render();
        var table = (TableElement)root.Children.First(c => c is TableElement);
        var tbody = (TbodyElement)table.Children.First(c => c is TbodyElement);

        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead && p.GetIndexParameters().Length == 0)
            .ToDictionary(p => p.Name);

        foreach (var row in data)
        {
            var tr = new TrElement();
            foreach (var col in _columns)
            {
                var td = new TdElement();
                if (!string.IsNullOrEmpty(col.CellClass))
                    td.Class(col.CellClass);

                if (properties.TryGetValue(col.PropertyName, out var prop))
                {
                    var value = prop.GetValue(row);
                    if (col.RenderValue is not null)
                        td.AddChild(col.RenderValue(value));
                    else
                        td.AddChild(new TextNode(value?.ToString() ?? string.Empty));
                }
                tr.AddChild(td);
            }
            tbody.AddChild(tr);
        }

        return root;
    }

    private static string GetPropertyName<TValue>(Expression<Func<T, TValue>> expression)
    {
        var body = expression.Body;
        if (body is UnaryExpression unary)
            body = unary.Operand;
        if (body is MemberExpression member && member.Member is PropertyInfo prop)
            return prop.Name;
        throw new InvalidOperationException($"Expression '{expression}' does not refer to a property.");
    }
}

/// <summary>
/// Factory methods for creating <see cref="DataGridComponent{T}"/> instances.
/// </summary>
public static class DataGridExtensions
{
    /// <summary>
    /// Creates a new <see cref="DataGridComponent{T}"/> that loads data from the specified URL via HTMX.
    /// </summary>
    /// <typeparam name="T">The row data type.</typeparam>
    /// <param name="dataSourceUrl">The server endpoint URL for HTMX requests.</param>
    /// <returns>A new <see cref="DataGridComponent{T}"/> instance.</returns>
    public static DataGridComponent<T> DataGrid<T>(string dataSourceUrl) where T : notnull => new(dataSourceUrl);

    /// <summary>
    /// Creates a new <see cref="DataGridComponent{T}"/> with pre-loaded data.
    /// </summary>
    /// <typeparam name="T">The row data type.</typeparam>
    /// <param name="dataSourceUrl">The server endpoint URL for HTMX requests.</param>
    /// <param name="data">The data to display.</param>
    /// <returns>A new <see cref="DataGridComponent{T}"/> instance with data rendered.</returns>
    public static DataGridComponent<T> DataGrid<T>(string dataSourceUrl, IEnumerable<T> data) where T : notnull
    {
        var grid = new DataGridComponent<T>(dataSourceUrl);
        return grid;
    }
}
