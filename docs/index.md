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
| [FluentHtml](packages/core.md) | Core HTML elements, Node hierarchy, Components |
| [FluentHtml.Rendering](packages/rendering.md) | HTML renderer and encoding |
| [FluentHtml.AspNetCore](packages/aspnetcore.md) | ASP.NET Core integration |
| [FluentHtml.Htmx](packages/htmx.md) | HTMX attribute extensions |
| [FluentHtml.Bootstrap](packages/bootstrap.md) | Bootstrap components and CSS helpers |
| [FluentHtml.Forms](packages/forms.md) | Strongly-typed form helpers |
| [FluentHtml.Validation](packages/validation.md) | Validation components |

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
            .Target("#result")
    );
```
