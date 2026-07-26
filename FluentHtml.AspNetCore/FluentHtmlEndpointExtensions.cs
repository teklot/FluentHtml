using FluentHtml.Nodes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace FluentHtml.AspNetCore;

/// <summary>
/// Provides extension methods on <see cref="IEndpointRouteBuilder"/> for mapping HTTP endpoints that return <see cref="HtmlResult"/> responses.
/// </summary>
public static class FluentHtmlEndpointExtensions
{
    /// <summary>
    /// Maps a GET endpoint that returns an <see cref="HtmlResult"/>.
    /// </summary>
    /// <param name="endpoints">The <see cref="IEndpointRouteBuilder"/> to add the endpoint to.</param>
    /// <param name="pattern">The route pattern (e.g. <c>"/"</c>).</param>
    /// <param name="handler">A delegate that returns an <see cref="HtmlResult"/>.</param>
    /// <returns>The <see cref="RouteHandlerBuilder"/> for further configuration.</returns>
    public static RouteHandlerBuilder MapGet(this IEndpointRouteBuilder endpoints, string pattern, Func<HtmlResult> handler)
    {
        return endpoints.MapGet(pattern, () => (IResult)handler());
    }

    /// <summary>
    /// Maps a POST endpoint that returns an <see cref="HtmlResult"/>.
    /// </summary>
    /// <param name="endpoints">The <see cref="IEndpointRouteBuilder"/> to add the endpoint to.</param>
    /// <param name="pattern">The route pattern (e.g. <c>"/submit"</c>).</param>
    /// <param name="handler">A delegate that returns an <see cref="HtmlResult"/>.</param>
    /// <returns>The <see cref="RouteHandlerBuilder"/> for further configuration.</returns>
    public static RouteHandlerBuilder MapPost(this IEndpointRouteBuilder endpoints, string pattern, Func<HtmlResult> handler)
    {
        return endpoints.MapPost(pattern, () => (IResult)handler());
    }

    /// <summary>
    /// Maps a PUT endpoint that returns an <see cref="HtmlResult"/>.
    /// </summary>
    /// <param name="endpoints">The <see cref="IEndpointRouteBuilder"/> to add the endpoint to.</param>
    /// <param name="pattern">The route pattern (e.g. <c>"/update"</c>).</param>
    /// <param name="handler">A delegate that returns an <see cref="HtmlResult"/>.</param>
    /// <returns>The <see cref="RouteHandlerBuilder"/> for further configuration.</returns>
    public static RouteHandlerBuilder MapPut(this IEndpointRouteBuilder endpoints, string pattern, Func<HtmlResult> handler)
    {
        return endpoints.MapPut(pattern, () => (IResult)handler());
    }

    /// <summary>
    /// Maps a DELETE endpoint that returns an <see cref="HtmlResult"/>.
    /// </summary>
    /// <param name="endpoints">The <see cref="IEndpointRouteBuilder"/> to add the endpoint to.</param>
    /// <param name="pattern">The route pattern (e.g. <c>"/delete"</c>).</param>
    /// <param name="handler">A delegate that returns an <see cref="HtmlResult"/>.</param>
    /// <returns>The <see cref="RouteHandlerBuilder"/> for further configuration.</returns>
    public static RouteHandlerBuilder MapDelete(this IEndpointRouteBuilder endpoints, string pattern, Func<HtmlResult> handler)
    {
        return endpoints.MapDelete(pattern, () => (IResult)handler());
    }

    /// <summary>
    /// Maps a PATCH endpoint that returns an <see cref="HtmlResult"/>.
    /// </summary>
    /// <param name="endpoints">The <see cref="IEndpointRouteBuilder"/> to add the endpoint to.</param>
    /// <param name="pattern">The route pattern (e.g. <c>"/modify"</c>).</param>
    /// <param name="handler">A delegate that returns an <see cref="HtmlResult"/>.</param>
    /// <returns>The <see cref="RouteHandlerBuilder"/> for further configuration.</returns>
    public static RouteHandlerBuilder MapPatch(this IEndpointRouteBuilder endpoints, string pattern, Func<HtmlResult> handler)
    {
        return endpoints.MapPatch(pattern, () => (IResult)handler());
    }
}
