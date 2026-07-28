# Getting Started with FluentHtml

## Installation

Install the FluentHtml packages via NuGet:

```bash
dotnet add package FluentHtml.Http
```

This will install the core packages. For additional features:

```bash
# HTMX support
dotnet add package FluentHtml.Htmx

# Bootstrap components
dotnet add package FluentHtml.Bootstrap

# Form helpers
dotnet add package FluentHtml.Forms

# Validation
dotnet add package FluentHtml.Validation
```

## Minimal API Setup

```csharp
using FluentHtml;
using FluentHtml.Elements;
using FluentHtml.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAntiforgery();

var app = builder.Build();
app.UseAntiforgery();

var routes = app.FluentRouting();
routes.MapGet("/", () => H1("Hello, FluentHtml!"));

app.Run();
```

## Routing

Use `FluentRouting()` for automatic `Node`-to-`HtmlResult` conversion:

```csharp
var routes = app.FluentRouting();
routes.MapGet("/", HomePage.Render);
routes.MapPost("/create", MyPage.Create);
routes.MapDelete("/{id}", MyPage.Delete);
```

## Creating Components

### Inline Components

```csharp
var card = Div()
    .Class("card")
    .Children(
        Div().Class("card-header").Children(H3("Card Title")),
        Div().Class("card-body").Children(
            P("Card content goes here.")
        )
    );
```

### Reusable Components

```csharp
public class ProductCard : Component<Product>
{
    public ProductCard(Product product) : base(product) { }

    protected override Node Build(Product data) =>
        Div().Class("card").Children(
            Div().Class("card-body").Children(
                H5(data.Name).Class("card-title"),
                P($"Price: {data.Price:C}").Class("card-text"),
                Btn("Add to Cart").Primary()
            )
        );
}
```

## HTMX Integration

```csharp
using FluentHtml.Htmx;

var button = Button("Load Data")
    .HxGet("/api/data")
    .HxTarget("#results")
    .HxSwap("innerHTML");
```

## Bootstrap Styling

```csharp
using FluentHtml.Bootstrap.Components;

var button = Btn("Submit")
    .Primary()
    .Large()
    .HxPost("/submit");
```
