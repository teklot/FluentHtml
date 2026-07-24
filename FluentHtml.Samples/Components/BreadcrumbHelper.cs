namespace FluentHtml.Samples.Components;

public static class BreadcrumbHelper
{
    public static BreadcrumbComponent MakeBreadcrumb(params (string text, string? href)[] items)
    {
        var listItems = items.Select((item, i) =>
        {
            var isLast = i == items.Length - 1;
            if (isLast)
                return (Node)BreadcrumbItem(new TextNode(item.text)).Active().AriaCurrent("page");
            return (Node)BreadcrumbItem(BreadcrumbLink(item.text).Href(item.href ?? "#")).Class("breadcrumb-item");
        }).ToArray();

        return Breadcrumb(BreadcrumbList(listItems)).AriaLabel("breadcrumb");
    }
}
