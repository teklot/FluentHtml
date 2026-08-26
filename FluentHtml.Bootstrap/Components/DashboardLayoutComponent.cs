using FluentHtml.Components;
using FluentHtml.Elements;
using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A pre-built dashboard layout combining header, sidebar, content, and footer regions.
/// Uses responsive flex layout with sidebar collapse on mobile.
/// </summary>
public sealed class DashboardLayoutComponent : Component
{
    private readonly Node[] _headerChildren;
    private readonly Node[] _sidebarChildren;
    private readonly Node[] _contentChildren;
    private readonly Node[] _footerChildren;
    private readonly string _sidebarWidth;

    /// <summary>
    /// Initializes a new instance of the <see cref="DashboardLayoutComponent"/> class.
    /// </summary>
    /// <param name="header">Header content.</param>
    /// <param name="sidebar">Sidebar content.</param>
    /// <param name="content">Main content.</param>
    /// <param name="footer">Footer content (optional).</param>
    /// <param name="sidebarWidth">Sidebar width (default: "280px").</param>
    public DashboardLayoutComponent(Node[] header, Node[] sidebar, Node[] content, Node[] footer, string sidebarWidth = "280px")
    {
        _headerChildren = header;
        _sidebarChildren = sidebar;
        _contentChildren = content;
        _footerChildren = footer;
        _sidebarWidth = sidebarWidth;
    }

    /// <inheritdoc/>
    public override Node Render()
    {
        var sidebarId = "dashboard-sidebar";
        var contentId = "main-content";

        var sidebar = new DivElement(_sidebarChildren)
            .Id(sidebarId)
            .Style($"width:{_sidebarWidth}")
            .Class("border-end bg-light d-flex flex-column p-3");

        var content = new LayoutContentComponent(_contentChildren)
            .Id(contentId)
            .Class("p-4 flex-grow-1");

        var hasHeader = _headerChildren.Length > 0;
        var hasFooter = _footerChildren.Length > 0;

        if (!hasHeader && !hasFooter)
            return new DivElement(sidebar, content).Class("d-flex");

        var body = new DivElement(sidebar, content).Class("d-flex flex-grow-1");
        var children = new List<Node>();
        if (hasHeader)
            children.Add(new LayoutHeaderComponent(_headerChildren).Class("d-md-none p-2"));
        children.Add(body);
        if (hasFooter)
            children.Add(new LayoutFooterComponent(_footerChildren));
        return new DivElement(children.ToArray()).Class("d-flex flex-column");
    }
}

/// <summary>
/// Extension methods for creating dashboard layout components.
/// </summary>
public static class DashboardLayoutExtensions
{
    /// <summary>
    /// Creates a new <see cref="DashboardLayoutComponent"/> with header, sidebar, content, and optional footer.
    /// </summary>
    /// <param name="header">Header content.</param>
    /// <param name="sidebar">Sidebar content.</param>
    /// <param name="content">Main content.</param>
    /// <returns>A new <see cref="DashboardLayoutComponent"/> instance.</returns>
    public static DashboardLayoutComponent DashboardLayout(Node[] header, Node[] sidebar, Node[] content) =>
        new(header, sidebar, content, Array.Empty<Node>());

    /// <summary>
    /// Creates a new <see cref="DashboardLayoutComponent"/> with header, sidebar, content, and footer.
    /// </summary>
    /// <param name="header">Header content.</param>
    /// <param name="sidebar">Sidebar content.</param>
    /// <param name="content">Main content.</param>
    /// <param name="footer">Footer content.</param>
    /// <returns>A new <see cref="DashboardLayoutComponent"/> instance.</returns>
    public static DashboardLayoutComponent DashboardLayout(Node[] header, Node[] sidebar, Node[] content, Node[] footer) =>
        new(header, sidebar, content, footer);
}
