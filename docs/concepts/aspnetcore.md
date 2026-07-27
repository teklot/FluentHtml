# FluentHtml.AspNetCore

ASP.NET Core integration for FluentHtml.

## Installation

```bash
dotnet add package FluentHtml.AspNetCore
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

### HtmxResponse

Combine main swap content with out-of-band OOB elements:

```csharp
return TodoItemRow(item)
    .Htmx()
    .Oob(CreateForm().HxSwapOob("outerHTML:#create-form"));
```

When no OOB elements are added, renders the main content directly. When OOB elements are present, renders all elements as siblings. Avoid using table row elements (`<tr>`, `<td>`) as main content when OOB is present — browser HTML parsing wraps them in an implicit `<table>`.

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
