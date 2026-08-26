using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class TreePage
{
    public static IResult Render(HttpContext http)
    {
        return Layout.Page(http,
            BreadcrumbHelper.MakeBreadcrumb(("Home", "/"), ("Tree", null)),
            H1("Tree Navigation"),
            P("Expandable and collapsible tree structures. Supports lazy-loading child nodes via HTMX."),

            SectionHelper.ShowSection("Basic Tree", Div(
                P("A static tree with toggles and leaf nodes."),
                BootstrapTree(
                    BootstrapTreeNode(
                        BootstrapTreeToggle(BiIcon("folder"), new TextNode(" Documents")),
                        BootstrapTreeChildren(
                            BootstrapTreeLeaf(BiIcon("file-earmark"), new TextNode(" report.pdf")),
                            BootstrapTreeLeaf(BiIcon("file-earmark"), new TextNode(" notes.txt")),
                            BootstrapTreeLeaf(BiIcon("file-earmark"), new TextNode(" budget.xlsx"))
                        ).Collapsed()
                    ),
                    BootstrapTreeNode(
                        BootstrapTreeToggle(BiIcon("folder"), new TextNode(" Images")),
                        BootstrapTreeChildren(
                            BootstrapTreeLeaf(BiIcon("file-earmark-image"), new TextNode(" photo.jpg")),
                            BootstrapTreeLeaf(BiIcon("file-earmark-image"), new TextNode(" logo.png"))
                        ).Collapsed()
                    ),
                    BootstrapTreeNode(
                        BootstrapTreeToggle(BiIcon("folder"), new TextNode(" Source")),
                        BootstrapTreeChildren(
                            BootstrapTreeNode(
                                BootstrapTreeToggle(BiIcon("folder"), new TextNode(" src")),
                                BootstrapTreeChildren(
                                    BootstrapTreeLeaf(BiIcon("filetype-cs"), new TextNode(" Program.cs")),
                                    BootstrapTreeLeaf(BiIcon("filetype-cs"), new TextNode(" Startup.cs"))
                                ).Collapsed()
                            ),
                            BootstrapTreeLeaf(BiIcon("filetype-json"), new TextNode(" appsettings.json"))
                        ).Collapsed()
                    )
                ).Class("border p-3 rounded")
            )),

            SectionHelper.ShowSection("Tree with HTMX Lazy Loading", Div(
                P("Child nodes load on demand via hx-get when the toggle is clicked."),
                BootstrapTree(
                    BootstrapTreeNode(
                        BootstrapTreeToggle(BiIcon("folder"), new TextNode(" Users"))
                            .HxLoad("/tree/users", "next .tree-children"),
                        BootstrapTreeChildren().Collapsed()
                    ),
                    BootstrapTreeNode(
                        BootstrapTreeToggle(BiIcon("folder"), new TextNode(" Products"))
                            .HxLoad("/tree/products", "next .tree-children"),
                        BootstrapTreeChildren().Collapsed()
                    ),
                    BootstrapTreeNode(
                        BootstrapTreeToggle(BiIcon("folder"), new TextNode(" Orders"))
                            .HxLoad("/tree/orders", "next .tree-children"),
                        BootstrapTreeChildren().Collapsed()
                    )
                ).Class("border p-3 rounded")
            )),

            SectionHelper.ShowSection("Core Tree (Framework-Agnostic)", Div(
                P("The core TreeComponent provides tree navigation with Bootstrap-compatible styling."),
                Tree(
                    TreeNode(
                        TreeToggle(BiIcon("folder"), new TextNode(" Design")),
                        Tree(
                            TreeLeaf(BiIcon("filetype-psd"), new TextNode(" mockup.psd")),
                            TreeLeaf(BiIcon("filetype-ai"), new TextNode(" brand.ai")),
                            TreeLeaf(BiIcon("filetype-sketch"), new TextNode(" wireframe.sketch"))
                        ).Indent().Collapsed()
                    ),
                    TreeNode(
                        TreeToggle(BiIcon("folder"), new TextNode(" Backend")),
                        Tree(
                            TreeLeaf(BiIcon("filetype-cs"), new TextNode(" Program.cs")),
                            TreeLeaf(BiIcon("filetype-cs"), new TextNode(" Startup.cs")),
                            TreeLeaf(BiIcon("filetype-json"), new TextNode(" appsettings.json"))
                        ).Indent().Collapsed()
                    ),
                    TreeNode(
                        TreeToggle(BiIcon("folder"), new TextNode(" Docs")),
                        Tree(
                            TreeNode(
                                TreeToggle(BiIcon("folder"), new TextNode(" api")),
                                Tree(
                                    TreeLeaf(BiIcon("file-earmark"), new TextNode(" README.md")),
                                    TreeLeaf(BiIcon("file-earmark"), new TextNode(" CHANGELOG.md"))
                                ).Indent().Collapsed()
                            ),
                            TreeLeaf(BiIcon("filetype-pdf"), new TextNode(" architecture.pdf"))
                        ).Indent().Collapsed()
                    )
                ).Class("border p-3 rounded")
            )),

            new ScriptElement(@"
                document.addEventListener('DOMContentLoaded', function() {
                    document.querySelectorAll('.tree-toggle').forEach(function(btn) {
                        btn.addEventListener('click', function() {
                            var children = this.parentElement.querySelector('.tree-children');
                            if (children) {
                                children.classList.toggle('collapse');
                                var expanded = !children.classList.contains('collapse');
                                this.setAttribute('aria-expanded', expanded);
                            }
                        });
                    });
                });
            ")
        ).ToHtmlResult();
    }

    public static IResult LoadUsers(HttpContext http)
    {
        var users = new[] { "Alice Johnson", "Bob Smith", "Charlie Brown" };
        var fragment = new Fragment(users.Select(u =>
            (Node)BootstrapTreeLeaf(BiIcon("person"), new TextNode($" {u}"))
        ).ToArray());
        return fragment.ToHtmlResult();
    }

    public static IResult LoadProducts(HttpContext http)
    {
        var products = new[] { "Laptop", "Mouse", "Keyboard" };
        var fragment = new Fragment(products.Select(p =>
            (Node)BootstrapTreeLeaf(BiIcon("box"), new TextNode($" {p}"))
        ).ToArray());
        return fragment.ToHtmlResult();
    }

    public static IResult LoadOrders(HttpContext http)
    {
        var orders = new[] { "Order #1001", "Order #1002", "Order #1003" };
        var fragment = new Fragment(orders.Select(o =>
            (Node)BootstrapTreeLeaf(BiIcon("cart"), new TextNode($" {o}"))
        ).ToArray());
        return fragment.ToHtmlResult();
    }
}
