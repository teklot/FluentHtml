# FluentHtml

**Build HTML with C#, not strings.**

FluentHtml is a FastHTML-inspired microframework for ASP.NET Core that enables developers to build modern server-rendered web applications entirely in C# using a fluent API.

## Quick Links

- [Getting Started](getting-started.md) - Install and create your first page
- [Architecture](architecture.md) - Understand the component model and rendering pipeline
- [API Reference](~/api/index.md) - Complete API documentation

## Packages

| Package | Description |
|---------|-------------|
| [FluentHtml](concepts/core.md) | Core HTML elements, Node hierarchy, Components, Rendering |
| [FluentHtml.Http](concepts/http.md) | HTTP layer integration |
| [FluentHtml.Htmx](concepts/htmx.md) | HTMX attribute extensions |
| [FluentHtml.Bootstrap](concepts/bootstrap.md) | Bootstrap components and CSS helpers |
| [FluentHtml.Forms](concepts/forms.md) | Strongly-typed form helpers |
| [FluentHtml.Validation](concepts/validation.md) | Validation components |

## Example

```csharp
using FluentHtml;
using FluentHtml.Elements;
using FluentHtml.Bootstrap.Components;
using FluentHtml.Htmx;

var page = Div()
    .Class("container")
    .Children(
        H1("Welcome to FluentHtml"),
        P("Build HTML with C#, not strings."),
        Btn("Click Me")
            .Primary()
            .Large()
            .HxPost("/api/click")
            .HxTarget("#result")
    );
```
