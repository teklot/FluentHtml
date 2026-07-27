using Microsoft.AspNetCore.Builder;

namespace FluentHtml.AspNetCore;

/// <summary>
/// Provides the <see cref="FluentRouting"/> extension method on <see cref="IEndpointRouteBuilder"/>
/// to access FluentHtml's endpoint mapping API.
/// </summary>
public static class FluentHtmlEndpointExtensions
{
    /// <summary>
    /// Returns a <see cref="FluentRouter"/> that exposes <c>MapGet</c>, <c>MapPost</c>, <c>MapPut</c>, <c>MapPatch</c>,
    /// and <c>MapDelete</c> methods with auto-form-binding and Node auto-wrapping support.
    /// </summary>
    /// <param name="endpoints">The <see cref="IEndpointRouteBuilder"/>.</param>
    /// <returns>A <see cref="FluentRouter"/> for mapping FluentHtml endpoints.</returns>
    public static FluentRouter FluentRouting(this IEndpointRouteBuilder endpoints)
    {
        return new FluentRouter(endpoints);
    }
}
