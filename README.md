# FluentHtml — Server-Rendered HTML with Fluent C#

[![CI](https://github.com/TekLot/FluentHtml/actions/workflows/ci.yml/badge.svg)](https://github.com/TekLot/FluentHtml/actions/workflows/ci.yml)
[![NuGet Version](https://img.shields.io/nuget/v/FluentHtml)](https://www.nuget.org/packages/FluentHtml)
[![.NET](https://img.shields.io/badge/.NET-net10.0-blue)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/License-Apache%202.0-blue)](LICENSE)

Every ASP.NET team eventually faces the same choice: Razor mixes HTML and C# into a template language that resists refactoring. Blazor introduces a runtime, a component lifecycle, and hydration overhead that most line-of-business apps don't need. React/Vue/Angular require a separate language, a build pipeline, and a deployment story that doubles operational complexity. None of these are bad tools — they're just solving a bigger problem than most internal applications actually have.

FluentHtml takes a different approach. Instead of importing a foreign programming model into .NET, it makes HTML a native citizen of C# — strongly typed, composable, IntelliSense-discoverable — and keeps application logic on the server where ASP.NET Core excels. HTMX handles interactivity without a JavaScript framework. The result is a framework that feels like writing idiomatic .NET, not porting another language's ideas.

**Guiding principle:** Never replace ASP.NET Core. Extend it with strongly typed HTML generation.

## The Problem

```csharp
// Razor — mixes template syntax with C#
<div class="card">
    <h2>@Model.Title</h2>
    @foreach (var item in Model.Items) {
        <p>@item.Name</p>
    }
</div>

// String concatenation — no IntelliSense, no refactoring, no safety
html += "<div class=\"card\">";
html += "<h2>" + title + "</h2>";

// Blazor — runtime overhead for simple server-rendered pages
<div class="card">
    <h2>@Title</h2>
    @foreach (var item in Items) {
        <p>@item.Name</p>
    }
</div>
```

Razor forces a template language that mixes two syntaxes in one file. String concatenation has no compile-time safety. Blazor adds a runtime, state management, and a rendering pipeline for pages that could be simple HTML. There is no lightweight, strongly typed, fluent way to generate HTML in C# that integrates naturally with Minimal APIs and produces clean output.

**FluentHtml eliminates the seam.** It provides the strongly typed building blocks that make HTML generation a first-class C# operation — not a template language, not a string, not a separate runtime.

## How It Works

The entire component model lives in `FluentHtml` — **pure C# with no third-party dependencies.** ASP.NET Core integration, HTMX support, and Bootstrap components are separate packages you opt into.

```
┌──────────────────────────────────────────────────────────────┐
│                        FluentHtml                            │
│  ┌────────────────┐  ┌────────────────┐  ┌────────────────┐  │
│  │     Node       │  │    Element     │  │   Component    │  │
│  │   .Children    │  │   .TagName     │  │   .Render()    │  │
│  │   .AddChild()  │  │   .Attributes  │  │   .Build()     │  │
│  │                │  │   .Classes     │  │                │  │
│  └────────────────┘  └────────────────┘  └────────────────┘  │
│  ┌────────────────┐  ┌────────────────┐  ┌────────────────┐  │
│  │   TextNode     │  │    RawHtml     │  │   Fragment     │  │
│  │   .Content     │  │   .Content     │  │   (no wrapper) │  │
│  │   (encoded)    │  │   (raw)        │  │                │  │
│  └────────────────┘  └────────────────┘  └────────────────┘  │
│  ┌────────────────────────────────────────────────────────┐  │
│  │        ~120 HTML Elements (Div, Span, Button, ...)     │  │
│  │     Fluent attributes: .Id() .Class() .HxPost()        │  │
│  └────────────────────────────────────────────────────────┘  │
│  ┌────────────────────────────────────────────────────────┐  │
│  │  FluentHtml.Rendering  — Renderer, HtmlWriter, Encode  │  │
│  │  FluentHtml.AspNetCore — IResult, Minimal API helpers  │  │
│  │  FluentHtml.Htmx       — hx-get, hx-post, hx-swap      │  │
│  │  FluentHtml.Bootstrap  — Card, Alert, Button, Modal    │  │
│  └────────────────────────────────────────────────────────┘  │
└──────────────────────────────────────────────────────────────┘
```

Every element is **immutable after construction** — fluent methods return the same instance. Thread-safe by design. No defensive copies needed.

### Not a Clone — An Idiom

FluentHtml is **inspired by** FastHTML's philosophy of composing HTML from function calls, but it is designed as an **idiomatic .NET framework** that follows C# conventions rather than porting another language's patterns:

- **Extension methods** instead of static functions — `Button().Primary()` reads like fluent C#, not F# pipe operators
- **Generics and type constraints** — `Component<T>` with compile-time safety, not duck typing
- **Immutable element trees** — built via constructors, not mutable builder chains
- **ASP.NET Core native** — `IResult` integration, Minimal API extensions, not a standalone renderer
- **Strong typing everywhere** — `ButtonType.Submit` instead of `"submit"`, `InputType.Email` instead of `"email"`

The result is a framework that feels like writing C#, not translating another language's idioms into .NET.

### Fluent API — Not a Template Language

```csharp
// FluentHtml — strongly typed, IntelliSense-discoverable
Button("Save")
    .Primary()
    .Large()
    .HxPost("/api/save")
    .Target("#result")

// Instead of Razor's mixed syntax:
// <button class="btn btn-primary btn-lg"
//         hx-post="/api/save"
//         hx-target="#result">Save</button>
```

Typing `Button().` reveals `Primary()`, `Secondary()`, `Disabled()`, `Id()`, `Class()`, `HxPost()`, `HxGet()`, `MarginTop()`, `Width()` — developers should rarely need documentation for common tasks.

### Composition, Not Inheritance

```csharp
// Assemble building blocks — don't extend base classes:
var card = Card(
    H2("Customer Orders"),
    Table(
        Thead(new Tr(Th("Name"), Th("Amount"))),
        Tbody(orders.Select(o =>
            new Tr(new Td(o.Name), new Td(o.Amount.ToString("C")))
        ))
    ),
    Button("New Order")
        .Primary()
        .HxGet("/orders/new")
        .HxTarget("#dialog")
);
```

Components compose from elements. Elements compose from nodes. Pages compose from layouts. No inheritance hierarchies to navigate.

### Server-Side Rendering — No Runtime Required

```
Browser → HTTP Request → ASP.NET Core Pipeline → Minimal API Route → FluentHtml Components → Renderer → HTML Response → Browser
```

FluentHtml owns only component creation and rendering. Everything before and after is standard ASP.NET Core — routing, DI, middleware, authentication, model binding, logging. HTMX requests behave exactly like normal requests; the only difference is partial HTML is returned instead of a complete page.

## Use Cases

### Internal Business Applications

```
app.MapGet("/customers", (CustomerService svc) =>
{
    return CustomersPage(service.GetAll());
});
```

Dashboards, admin panels, CRM, ERP, inventory systems — applications where the UI serves the data, not the other way around. Server-rendered HTML with HTMX partial updates provides the interactivity without the JavaScript overhead.

### CRUD Systems

```csharp
app.MapGet("/users/new", () => CreateUserForm());
app.MapPost("/users", (CreateUserDto dto) =>
{
    service.Create(dto);
    return UsersTable(service.GetAll()).ToHtmlResult();
});
```

Strongly typed forms with `InputFor(x => x.Name)`, validation via ASP.NET Core's existing infrastructure, and HTMX partial rendering for seamless updates.

### Dashboards and Reporting

```csharp
app.MapGet("/dashboard", (DashboardService svc) =>
{
    return DashboardPage(
        MetricCards(svc.GetMetrics()),
        RecentOrders(svc.GetOrders(10)),
        SalesChart(svc.GetSalesData())
    );
});
```

Reusable components compose into complex layouts. Bootstrap integration provides the visual foundation.

### Documentation and Portals

Clean, semantic HTML without the weight of a JavaScript framework. Server-side rendering provides excellent SEO and fast first-page load.

## Technical Differentiators

| vs. | FluentHtml |
|---|---|
| **Razor** | No template language — pure C# with compile-time safety, IntelliSense, and easy refactoring |
| **Blazor** | No runtime, no hydration, no component lifecycle — just HTML generation and server responses |
| **React/Vue/Angular** | No JavaScript build pipeline, no client-side state management, no deployment complexity |
| **String concatenation** | Strongly typed elements, automatic HTML encoding, attribute management, composition |
| **Tag Helpers** | Fluent API with method chaining — not attribute-based template extensions |
| **FastHTML** | Idiomatic .NET — extension methods, generics, ASP.NET Core integration, not a language port |

## Packages

| Package | Description |
|---|---|
| **FluentHtml** | Core: `Node`, `Element`, `Component<T>`, `Fragment`, `TextNode`, `RawHtml`, ~120 HTML elements, fluent attributes, CSS helpers |
| **FluentHtml.Rendering** | `Renderer`, `HtmlWriter`, `HtmlEncoder` — converts component trees to clean HTML |
| **FluentHtml.AspNetCore** | `HtmlResult` (`IResult`), Minimal API endpoint extensions, `Node.ToHtmlResult()` |
| **FluentHtml.Htmx** | `HxGet()`, `HxPost()`, `HxSwap()`, `HxTarget()`, `HxTrigger()`, `HxConfirm()` and 20+ HTMX attribute extensions |
| **FluentHtml.Bootstrap** | `Card`, `Alert`, `Button`, `Navbar`, `Modal`, `Accordion`, `Toast`, `Dropdown`, `Pagination`, `Badge`, `Breadcrumb`, `Spinner` + CSS helper extensions |
| **FluentHtml.Forms** | `Form`, `InputFor()`, `LabelFor()`, `SelectFor()`, `TextAreaFor()`, `CheckboxFor()`, `ValidationSummary()` |
| **FluentHtml.Validation** | `ValidationMessage`, `ValidationSummary`, validation CSS helpers |

## Installation

```shell
dotnet add package FluentHtml
dotnet add package FluentHtml.Rendering
dotnet add package FluentHtml.AspNetCore
dotnet add package FluentHtml.Htmx
dotnet add package FluentHtml.Bootstrap
dotnet add package FluentHtml.Forms
dotnet add package FluentHtml.Validation
```

## Quick Start

```csharp
using FluentHtml.Elements;
using FluentHtml.Rendering;
using FluentHtml.AspNetCore;
using FluentHtml.Bootstrap.Components;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// A complete page — all C#, no Razor, no templates
app.MapGet("/", () =>
{
    return new HtmlElement(
        new HeadElement(new TitleElement("FluentHtml Sample")),
        new BodyElement(
            new NavElement().Class("navbar navbar-dark bg-dark").Children(
                new AnchorElement("FluentHtml").Href("/").Class("navbar-brand")
            ),
            new MainElement().Class("container mt-4").Children(
                Card(
                    new Heading1Element("Welcome"),
                    new ParagraphElement("Built with strongly typed C# components."),
                    Button("Click Me")
                        .Primary()
                        .Large()
                        .HxPost("/api/click")
                        .HxTarget("#result")
                ),
                new DivElement().Id("result")
            )
        )
    );
});

// Partial rendering for HTMX
app.MapGet("/api/click", () =>
{
    return AlertExtensions.Alert("Button clicked!")
        .Success()
        .ToHtmlResult();
});

app.Run();
```

### Component Model

```csharp
// Elements — one HTML tag each
var div = new DivElement(
    new Heading1Element("Dashboard"),
    new ParagraphElement("Welcome back.")
).Id("main").Class("container");

// Text nodes — auto-encoded
var p = new ParagraphElement("Hello <script>alert('xss')</script>");
// Renders: <p>Hello &lt;script&gt;alert(&#39;xss&#39;)&lt;/script&gt;</p>

// Fragments — siblings without a wrapper
var fragment = new Fragment(
    new Heading1Element("Title"),
    new ParagraphElement("Body")
);

// Raw HTML — trusted, not encoded (use sparingly)
var raw = new RawHtml("<strong>Bold text</strong>");
```

### Fluent Attributes

```csharp
Button("Save")
    .Primary()              // class="btn btn-primary"
    .Large()                // class="btn btn-primary btn-lg"
    .Disabled()             // disabled
    .Id("save-btn")         // id="save-btn"
    .HxPost("/api/save")    // hx-post="/api/save"
    .HxTarget("#result")    // hx-target="#result"
    .HxConfirm("Save?")     // hx-confirm="Save?"
```

### HTMX Integration

```csharp
using FluentHtml.Htmx;

Button("Load Data")
    .HxGet("/api/data")
    .HxTarget("#table")
    .HxSwap("innerHTML")
    .HxTrigger("click")
    .HxIndicator("#spinner");

Button("Delete")
    .Danger()
    .HxDelete("/api/items/1")
    .HxConfirm("Are you sure?")
    .HxTarget("closest tr")
    .HxSwap("outerHTML");
```

### Forms with Model Binding

```csharp
using FluentHtml.Forms;

var form = new FormElement(
    new Heading2Element("Create User"),
    new DivElement(
        new LabelElement("Name").For("name"),
        new InputElement().Type("text").Name("name").Id("name").Required()
    ).Class("mb-3"),
    new DivElement(
        new LabelElement("Email").For("email"),
        new InputElement().Type("email").Name("email").Id("email").Required()
    ).Class("mb-3"),
    Button("Create").Primary()
).Action("/users").Method("post");
```

### Testing

```csharp
using FluentHtml.Elements;
using FluentHtml.Rendering;

var renderer = new Renderer();

var card = new DivElement(
    new Heading2Element("Test"),
    new ParagraphElement("Content")
).Class("card");

var html = renderer.Render(card);
Assert.Equal("<div class=\"card\"><h2>Test</h2><p>Content</p></div>", html);
```

No web server required. Components are plain C# objects — instantiate, render, assert.

## Node Hierarchy

```
Node
├── Element      — single HTML tag (Div, Span, Button, Form, Table, Input...)
├── TextNode     — plain text, always HTML encoded
├── RawHtml      — trusted HTML, not encoded (use sparingly)
├── Fragment     — groups siblings without a wrapper element
└── Component    — reusable UI, composes existing nodes
```

Every renderable object derives from `Node`. Elements own a tag name, attributes, and children. Components render other nodes. Fragments produce no wrapper HTML.

## License

Apache License 2.0 — see [LICENSE](LICENSE) for details.
