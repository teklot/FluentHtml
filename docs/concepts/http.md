# FluentHtml.Http

HTTP layer integration for FluentHtml.

## Installation

```bash
dotnet add package FluentHtml.Http
```

## Key Features

### HtmlResult

An `IResult` implementation that renders FluentHtml nodes to HTML responses.

```csharp
app.MapGet("/", () => new HtmlResult(H1("Hello")));
```

### ToHtmlResult Extension

Convert any node to an `IResult`:

```csharp
app.MapGet("/page", () => MyPage().ToHtmlResult());
```

### FluentRouter

A wrapper around `IEndpointRouteBuilder` providing clean `MapGet`/`MapPost`/`MapPut`/`MapPatch`/`MapDelete` methods with auto-form-binding and automatic `Node`-to-`HtmlResult` conversion.

```csharp
var routes = app.FluentRouting();
routes.MapGet("/", HomePage.Render);
routes.MapPost("/create", CrudPage.CreateCustomer);
routes.MapPatch("/toggle/{id}", TodoPage.ToggleTodo);
routes.MapDelete("/delete/{id}", TodoPage.DeleteTodo);
```

**Auto-form-binding (POST/PUT/PATCH):** Handler parameters are bound from form data or route values. Supports `HttpContext`, `CancellationToken`, `IFormCollection` injection, simple types, and complex type binding.

**Auto-route-binding (GET/DELETE):** Handler parameters are bound from route values or query string.

**Auto-Node wrapping:** Handlers returning `Node` are automatically wrapped in `HtmlResult`. `IResult` values pass through as-is.

## Setup

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAntiforgery();

var app = builder.Build();
app.UseAntiforgery();

var routes = app.FluentRouting();
routes.MapGet("/", HomePage.Render);
routes.MapPost("/create", MyPage.Create);
routes.MapDelete("/delete/{id}", MyPage.Delete);

app.Run();
```
