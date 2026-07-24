using FluentHtml.Nodes;
using FluentHtml.Rendering;
using Microsoft.AspNetCore.Http;

namespace FluentHtml.AspNetCore;

public sealed class HtmlResult : IResult
{
    private static readonly Renderer Renderer = new();

    private readonly Node _node;
    private readonly int _statusCode;
    private readonly string _contentType;

    public HtmlResult(Node node, int statusCode = 200, string contentType = "text/html; charset=utf-8")
    {
        _node = node ?? throw new ArgumentNullException(nameof(node));
        _statusCode = statusCode;
        _contentType = contentType;
    }

    public async Task ExecuteAsync(HttpContext context)
    {
        context.Response.StatusCode = _statusCode;
        context.Response.ContentType = _contentType;

        var html = Renderer.Render(_node);
        await context.Response.WriteAsync(html);
    }
}
