using FluentHtml.Nodes;
using FluentHtml.Rendering;
using Microsoft.AspNetCore.Http;

namespace FluentHtml.AspNetCore;

/// <summary>
/// Represents an ASP.NET Core <see cref="IResult"/> that renders a FluentHtml <see cref="Node"/> to HTML.
/// </summary>
public sealed class HtmlResult : IResult
{
    private static readonly Renderer Renderer = new();

    private readonly Node _node;
    private readonly int _statusCode;
    private readonly string _contentType;

    /// <summary>
    /// Initializes a new instance of the <see cref="HtmlResult"/> class.
    /// </summary>
    /// <param name="node">The FluentHtml <see cref="Node"/> to render as HTML.</param>
    /// <param name="statusCode">The HTTP status code to return. Defaults to <c>200</c>.</param>
    /// <param name="contentType">The content type of the response. Defaults to <c>text/html; charset=utf-8</c>.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="node"/> is <c>null</c>.</exception>
    public HtmlResult(Node node, int statusCode = 200, string contentType = "text/html; charset=utf-8")
    {
        _node = node ?? throw new ArgumentNullException(nameof(node));
        _statusCode = statusCode;
        _contentType = contentType;
    }

    /// <summary>
    /// Executes the result by rendering the HTML node and writing it to the HTTP response.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> for the current request.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task ExecuteAsync(HttpContext context)
    {
        context.Response.StatusCode = _statusCode;
        context.Response.ContentType = _contentType;

        var html = Renderer.Render(_node);
        await context.Response.WriteAsync(html);
    }
}
