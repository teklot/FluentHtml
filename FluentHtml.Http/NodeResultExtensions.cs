using FluentHtml.Nodes;

namespace FluentHtml.Http;

/// <summary>
/// Provides extension methods for converting FluentHtml <see cref="Node"/> instances to <see cref="HtmlResult"/> objects.
/// </summary>
public static class NodeResultExtensions
{
    /// <summary>
    /// Converts a FluentHtml <see cref="Node"/> to an <see cref="HtmlResult"/> for use as an ASP.NET Core endpoint response.
    /// </summary>
    /// <param name="node">The <see cref="Node"/> to convert.</param>
    /// <param name="statusCode">The HTTP status code for the response. Defaults to <c>200</c>.</param>
    /// <returns>An <see cref="HtmlResult"/> that renders the node as HTML.</returns>
    public static HtmlResult ToHtmlResult(this Node node, int statusCode = 200)
    {
        return new HtmlResult(node, statusCode);
    }
}
