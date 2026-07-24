using FluentHtml.Nodes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace FluentHtml.AspNetCore;

public static class FluentHtmlEndpointExtensions
{
    public static RouteHandlerBuilder MapGet(this IEndpointRouteBuilder endpoints, string pattern, Func<HtmlResult> handler)
    {
        return endpoints.MapGet(pattern, () => (IResult)handler());
    }

    public static RouteHandlerBuilder MapPost(this IEndpointRouteBuilder endpoints, string pattern, Func<HtmlResult> handler)
    {
        return endpoints.MapPost(pattern, () => (IResult)handler());
    }

    public static RouteHandlerBuilder MapPut(this IEndpointRouteBuilder endpoints, string pattern, Func<HtmlResult> handler)
    {
        return endpoints.MapPut(pattern, () => (IResult)handler());
    }

    public static RouteHandlerBuilder MapDelete(this IEndpointRouteBuilder endpoints, string pattern, Func<HtmlResult> handler)
    {
        return endpoints.MapDelete(pattern, () => (IResult)handler());
    }

    public static RouteHandlerBuilder MapPatch(this IEndpointRouteBuilder endpoints, string pattern, Func<HtmlResult> handler)
    {
        return endpoints.MapPatch(pattern, () => (IResult)handler());
    }
}
