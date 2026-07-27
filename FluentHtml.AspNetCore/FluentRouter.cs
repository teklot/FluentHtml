using System.ComponentModel;
using System.Reflection;
using FluentHtml.Nodes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace FluentHtml.AspNetCore;

/// <summary>
/// Provides FluentHtml HTTP endpoint mapping methods (<c>MapGet</c>, <c>MapPost</c>, etc.)
/// that wrap ASP.NET Core's Minimal API with auto-form-binding and Node auto-wrapping.
/// </summary>
public sealed class FluentRouter
{
    private readonly IEndpointRouteBuilder _endpoints;

    internal FluentRouter(IEndpointRouteBuilder endpoints)
    {
        _endpoints = endpoints;
    }

    /// <summary>
    /// Maps a GET endpoint with auto-binding: handler parameters are bound from route values or query string.
    /// Supports <see cref="HttpContext"/>, <see cref="CancellationToken"/> injection.
    /// Returns <see cref="Node"/> values are auto-wrapped in <see cref="HtmlResult"/>.
    /// </summary>
    public RouteHandlerBuilder MapGet(string pattern, Delegate handler)
    {
        return _endpoints.MapGet(pattern, CreateRouteDelegate(handler));
    }

    /// <summary>
    /// Maps a GET endpoint that accepts a handler returning <see cref="Node"/> (auto-wrapped in <see cref="HtmlResult"/>).
    /// </summary>
    public RouteHandlerBuilder MapGet(string pattern, Func<Node> handler)
    {
        return _endpoints.MapGet(pattern, () => handler().ToHtmlResult());
    }

    /// <summary>
    /// Maps a POST endpoint with auto-form-binding: handler parameters are bound from form data (or route values for route parameters).
    /// Supports <see cref="HttpContext"/>, <see cref="CancellationToken"/>, <see cref="IFormCollection"/> injection,
    /// simple types, and complex type binding via property names.
    /// </summary>
    public RouteHandlerBuilder MapPost(string pattern, Delegate handler)
    {
        return _endpoints.MapPost(pattern, CreateFormDelegate(handler));
    }

    /// <summary>
    /// Maps a PUT endpoint with auto-form-binding.
    /// </summary>
    public RouteHandlerBuilder MapPut(string pattern, Delegate handler)
    {
        return _endpoints.MapPut(pattern, CreateFormDelegate(handler));
    }

    /// <summary>
    /// Maps a PATCH endpoint with auto-form-binding.
    /// </summary>
    public RouteHandlerBuilder MapPatch(string pattern, Delegate handler)
    {
        return _endpoints.MapPatch(pattern, CreateFormDelegate(handler));
    }

    /// <summary>
    /// Maps a DELETE endpoint with auto-binding: handler parameters are bound from route values or query string.
    /// Supports <see cref="HttpContext"/>, <see cref="CancellationToken"/> injection.
    /// Returns <see cref="Node"/> values are auto-wrapped in <see cref="HtmlResult"/>.
    /// </summary>
    public RouteHandlerBuilder MapDelete(string pattern, Delegate handler)
    {
        return _endpoints.MapDelete(pattern, CreateRouteDelegate(handler));
    }

    /// <summary>
    /// Maps a DELETE endpoint that accepts a handler returning <see cref="Node"/> (auto-wrapped in <see cref="HtmlResult"/>).
    /// </summary>
    public RouteHandlerBuilder MapDelete(string pattern, Func<Node> handler)
    {
        return _endpoints.MapDelete(pattern, () => handler().ToHtmlResult());
    }

    private static Func<HttpContext, Task<IResult>> CreateRouteDelegate(Delegate handler)
    {
        var method = handler.Method;
        var parameters = method.GetParameters();

        return async context =>
        {
            var args = new object?[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];
                var type = param.ParameterType;

                if (type == typeof(HttpContext)) { args[i] = context; continue; }
                if (type == typeof(CancellationToken)) { args[i] = context.RequestAborted; continue; }

                var routeValue = context.Request.RouteValues[param.Name!]?.ToString();
                if (routeValue != null)
                {
                    args[i] = ConvertValue(routeValue, type);
                    continue;
                }

                var queryValue = context.Request.Query[param.Name!].FirstOrDefault();
                if (queryValue != null)
                {
                    args[i] = ConvertValue(queryValue, type);
                    continue;
                }

                args[i] = param.HasDefaultValue ? param.DefaultValue : (type.IsValueType ? Activator.CreateInstance(type) : null);
            }

            var result = handler.DynamicInvoke(args);
            return result switch
            {
                IResult ir => ir,
                Node node => node.ToHtmlResult(),
                _ => Results.Ok(result)
            };
        };
    }

    private static Func<HttpContext, Task<IResult>> CreateFormDelegate(Delegate handler)
    {
        var method = handler.Method;
        var parameters = method.GetParameters();

        return async context =>
        {
            var form = await context.Request.ReadFormAsync();
            var args = new object?[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];
                var type = param.ParameterType;

                if (type == typeof(HttpContext)) { args[i] = context; continue; }
                if (type == typeof(CancellationToken)) { args[i] = context.RequestAborted; continue; }
                if (type == typeof(IFormCollection)) { args[i] = form; continue; }

                var routeValue = context.Request.RouteValues[param.Name!]?.ToString();
                if (routeValue != null)
                {
                    args[i] = ConvertValue(routeValue, type);
                    continue;
                }

                var formValue = form[param.Name!].FirstOrDefault();
                if (formValue != null)
                {
                    args[i] = ConvertValue(formValue, type);
                    continue;
                }

                if (!IsSimpleType(type))
                {
                    args[i] = BindComplexType(type, form);
                    continue;
                }

                args[i] = param.HasDefaultValue ? param.DefaultValue : (type.IsValueType ? Activator.CreateInstance(type) : null);
            }

            var result = handler.DynamicInvoke(args);
            return result switch
            {
                IResult ir => ir,
                Node node => node.ToHtmlResult(),
                _ => Results.Ok(result)
            };
        };
    }

    private static bool IsSimpleType(Type type)
    {
        type = Nullable.GetUnderlyingType(type) ?? type;
        return type.IsPrimitive || type == typeof(string) || type == typeof(decimal) ||
               type == typeof(DateTime) || type == typeof(Guid) || type == typeof(TimeSpan) ||
               type.IsEnum;
    }

    private static object? ConvertValue(string value, Type targetType)
    {
        var type = Nullable.GetUnderlyingType(targetType) ?? targetType;
        if (type == typeof(bool))
            return value is "on" or "true" || value == "1";
        if (type.IsEnum)
            return Enum.Parse(type, value, ignoreCase: true);
        return TypeDescriptor.GetConverter(type).ConvertFromString(value);
    }

    private static object BindComplexType(Type type, IFormCollection form)
    {
        var instance = Activator.CreateInstance(type);
        if (instance == null) return instance!;

        foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (!prop.CanWrite) continue;
            var value = form[prop.Name].FirstOrDefault();
            if (value == null && prop.PropertyType == typeof(bool))
            {
                prop.SetValue(instance, false);
                continue;
            }
            if (value == null) continue;
            prop.SetValue(instance, ConvertValue(value, prop.PropertyType));
        }
        return instance;
    }
}
