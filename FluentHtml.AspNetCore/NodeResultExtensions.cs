using FluentHtml.Nodes;

namespace FluentHtml.AspNetCore;

public static class NodeResultExtensions
{
    public static HtmlResult ToHtmlResult(this Node node, int statusCode = 200)
    {
        return new HtmlResult(node, statusCode);
    }
}
