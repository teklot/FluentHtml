# FluentHtml — Server-Rendered HTML with a Fluent .NET API

[![CI](https://github.com/TekLot/FluentHtml/actions/workflows/ci.yml/badge.svg)](https://github.com/TekLot/FluentHtml/actions/workflows/ci.yml)
[![NuGet Version](https://img.shields.io/nuget/v/FluentHtml.Core)](https://www.nuget.org/packages/FluentHtml.Core)
[![.NET](https://img.shields.io/badge/.NET-net8.0%20%7C%20net10.0-blue)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/License-Apache%202.0-blue)](https://github.com/TekLot/FluentHtml/blob/main/LICENSE)
[![Docs](https://img.shields.io/badge/docs-FluentHtml-blue)](https://teklot.github.io/FluentHtml/)

Every ASP.NET team eventually faces the same choice: Razor mixes HTML and .NET into a template language that resists refactoring. Blazor introduces a runtime, a component lifecycle, and hydration overhead that most line-of-business apps don't need. React/Vue/Angular require a separate language, a build pipeline, and a deployment story that doubles operational complexity. None of these are bad tools — they're just solving a bigger problem than most internal applications actually have.

FluentHtml takes a different approach. Instead of importing a foreign programming model, it makes HTML a native citizen of .NET — strongly typed, composable, IntelliSense-discoverable (in .NET) — and keeps application logic on the server where ASP.NET Core excels. HTMX handles interactivity without a JavaScript framework. The result feels like writing idiomatic .NET, not porting another language's ideas.

**Guiding principle:** Never replace ASP.NET Core. Extend it with strongly typed HTML generation.

## Table of Contents

- [The Problem](#the-problem)
- [How It Works](#how-it-works)
  - [Not a Clone — An Idiom](#not-a-clone--an-idiom)
  - [Fluent API — Not a Template Language](#fluent-api--not-a-template-language)
  - [Composition, Not Inheritance](#composition-not-inheritance)
  - [Server-Side Rendering — No Runtime Required](#server-side-rendering--no-runtime-required)
- [Use Cases](#use-cases)
  - [Internal Business Applications](#internal-business-applications)
  - [CRUD Systems](#crud-systems)
  - [Dashboards and Reporting](#dashboards-and-reporting)
  - [Documentation and Portals](#documentation-and-portals)
- [Technical Differentiators](#technical-differentiators)
- [Packages](#packages)
- [Installation](#installation)
- [Quick Start](#quick-start)
  - [Component Model](#component-model)
  - [Fluent Attributes](#fluent-attributes)
  - [Markdown](#markdown)
  - [HTMX Integration](#htmx-integration)
  - [AutoForm\<T\>](#autoformt)
  - [File Upload & Drag-and-Drop](#file-upload--drag-and-drop)
  - [DataGrid\<T\>](#datagridt)
  - [Charts](#charts)
  - [Dark Mode / Theme Toggle](#dark-mode--theme-toggle)
  - [Bootstrap Icons](#bootstrap-icons)
  - [Progress Bar](#progress-bar)
  - [Layouts](#layouts)
  - [Tree Navigation](#tree-navigation)
  - [Forms with Model Binding](#forms-with-model-binding)
  - [Testing](#testing)
- [Node Hierarchy](#node-hierarchy)

## The Problem

```csharp
// Razor — mixes template syntax with .NET
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

Razor forces a template language that mixes two syntaxes in one file. String concatenation has no compile-time safety. Blazor adds a runtime, state management, and a rendering pipeline for pages that could be simple HTML. There is no lightweight, strongly typed, fluent way to generate HTML in .NET that integrates naturally with Minimal APIs and produces clean output.

**FluentHtml eliminates the seam.** It provides the strongly typed building blocks that make HTML generation a first-class .NET operation — not a template language, not a string, not a separate runtime.

## How It Works

The entire component model lives in `FluentHtml` — **pure .NET with no third-party dependencies** (Markdig is used only for Markdown rendering). Targets `net8.0` and `net10.0`. ASP.NET Core integration, HTMX support, and Bootstrap components are separate packages you opt into.

```
┌──────────────────────────────────────────────────────────────────┐
│                          FluentHtml                              │
│  ┌────────────────┐  ┌────────────────┐  ┌────────────────────┐  │
│  │     Node       │  │    Element     │  │     Component      │  │
│  │   .Children    │  │   .TagName     │  │     .Render()      │  │
│  │   .AddChild()  │  │   .Attributes  │  │     .Build()       │  │
│  │                │  │   .Classes     │  │                    │  │
│  └────────────────┘  └────────────────┘  └────────────────────┘  │
│  ┌────────────────┐  ┌────────────────┐  ┌────────────────────┐  │
│  │   TextNode     │  │    RawHtml     │  │     Fragment       │  │
│  │   .Content     │  │   .Content     │  │   (no wrapper)     │  │
│  │   (encoded)    │  │     (raw)      │  │                    │  │
│  └────────────────┘  └────────────────┘  └────────────────────┘  │
│  ┌────────────────────────────────────────────────────────────┐  │
│  │     ~120 HTML Elements (Div, Span, Button, Ul, Li...)      │  │
│  │     Fluent attributes: .Id() .Class() .HxPost()            │  │
│  └────────────────────────────────────────────────────────────┘  │
│  ┌────────────────────────────────────────────────────────────┐  │
│  │  Markdown (Markdig) — tables, code blocks, emphasis        │  │
│  │  Icons — framework-agnostic icon abstraction               │  │
│  │  Badge / Breadcrumb — standalone, non-Bootstrap variants   │  │
│  │  Tree Navigation — expandable/collapsible tree component   │  │
│  └────────────────────────────────────────────────────────────┘  │
│  ┌────────────────────────────────────────────────────────────┐  │
│  │  FluentHtml.Http      — IResult, Minimal API helpers       │  │
│  │  FluentHtml.Htmx      — hx-get, hx-post, hx-swap           │  │
│  │  FluentHtml.Forms     — AutoForm<T>, File Upload, Drag     │  │
│  │  FluentHtml.Bootstrap — Card, Alert, DataGrid, Charts,     │  │
│  │                         Theme Toggle, Icons, ProgressBar,  │  │
│  │                         Sidebar, Dashboard/Split Layout,   │  │
│  │                         Responsive Layout, Tree Nav,       │  │
│  │                         Confirm, Toast, Timeline, Wizards  │  │
│  └────────────────────────────────────────────────────────────┘  │
└──────────────────────────────────────────────────────────────────┘
```

Every element is **immutable after construction** — fluent methods return the same instance. Thread-safe by design. No defensive copies needed.

### Not a Clone — An Idiom

FluentHtml is **inspired by** FastHTML's philosophy of composing HTML from function calls, but it is designed as an **idiomatic .NET framework** that follows .NET conventions rather than porting another language's patterns:

- **Extension methods** instead of static functions — `Button().Primary()` reads like fluent .NET, not F# pipe operators
- **Generics and type constraints** — `Component<T>` with compile-time safety, not duck typing
- **Immutable element trees** — built via constructors, not mutable builder chains
- **ASP.NET Core native** — `IResult` integration, Minimal API extensions, not a standalone renderer
- **Strong typing everywhere** — `ButtonType.Submit` instead of `"submit"`, `InputType.Email` instead of `"email"`

The result is a framework that feels like writing .NET, not translating another language's idioms.

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

```csharp
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

Reusable components compose into complex layouts. Bootstrap integration provides the visual foundation. Charts render via Chart.js with no client-side framework.

### Documentation and Portals

Clean, semantic HTML without the weight of a JavaScript framework. Server-side rendering provides excellent SEO and fast first-page load. Markdown support renders content from `.md` files or inline strings.

## Technical Differentiators

| vs. | FluentHtml |
|---|---|
| **Razor** | No template language — pure .NET with compile-time safety, IntelliSense, and easy refactoring |
| **Blazor** | No runtime, no hydration, no component lifecycle — just HTML generation and server responses |
| **React/Vue/Angular** | No JavaScript build pipeline, no client-side state management, no deployment complexity |
| **String concatenation** | Strongly typed elements, automatic HTML encoding, attribute management, composition |
| **Tag Helpers** | Fluent API with method chaining — not attribute-based template extensions |
| **FastHTML** | Idiomatic .NET — extension methods, generics, ASP.NET Core integration, not a language port |

## Packages

| Package | Description |
|---|---|
| **FluentHtml.Core** | Core: `Node`, `Element`, `Component<T>`, `Fragment`, `TextNode`, `RawHtml`, `Renderer`, `HtmlWriter`, `HtmlEncoder`, `MarkdownComponent` (Markdig), `IconComponent` (framework-agnostic), standalone `BadgeComponent` / `BreadcrumbComponent`, `InlineScriptComponent`, `TreeComponent` (tree navigation), ~120 HTML elements, fluent attributes, CSS helpers |
| **FluentHtml.Http** | `HtmlResult` (`IResult`), Minimal API endpoint extensions, `Node.ToHtmlResult()` |
| **FluentHtml.Htmx** | `HxGet()`, `HxPost()`, `HxSwap()`, `HxTarget()`, `HxTrigger()`, `HxConfirm()` and 20+ HTMX attribute extensions |
| **FluentHtml.Bootstrap** | `Card`, `Alert`, `Button`, `Navbar`, `Modal`, `Accordion`, `Toast`, `ToastManager`, `Dropdown`, `Pagination`, `Badge`, `Breadcrumb`, `BreadcrumbCollapse`, `Spinner`, `Tab`, `DataGrid<T>` (HTMX-powered), `ChartComponent` (Chart.js), `ThemeToggle`, Bootstrap Icons, `ProgressBar`, `Sidebar`, `DashboardLayout`, `SplitLayout`, `ResponsiveLayout`, `BootstrapTree`, `ConfirmDialog`, `Timeline`, `Wizard` |
| **FluentHtml.Forms** | `Form`, `InputFor()`, `LabelFor()`, `SelectFor()`, `TextAreaFor()`, `CheckboxFor()`, `ValidationSummary()`, `AutoForm<T>()`, `FileInputFor()`, `FileInputGroup()`, `DragDropUpload()` |
| **FluentHtml.Validation** | `ValidationMessage`, `ValidationSummary`, validation CSS helpers |

## Installation

```shell
dotnet add package FluentHtml.Core
dotnet add package FluentHtml.Http
dotnet add package FluentHtml.Htmx
dotnet add package FluentHtml.Bootstrap
dotnet add package FluentHtml.Forms
dotnet add package FluentHtml.Validation
```

## Quick Start

```csharp
using FluentHtml.Elements;
using FluentHtml.Http;
using FluentHtml.Bootstrap.Components;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// A complete page — all .NET, no Razor, no templates
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
                    new ParagraphElement("Built with strongly typed .NET components."),
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

### Markdown

```csharp
using FluentHtml.Components;
using static FluentHtml.Components.MarkdownExtensions;

// Render Markdown to HTML via Markdig
CardBody(Markdown("# Hello\n\n**Bold** and *italic*.\n\n- Item 1\n- Item 2"))

// With optional CSS class injection for tables
CardBody(Markdown("| Name | Age |\n|------|-----|\n| Alice | 30 |", "table table-striped"))
```

Supports headings, bold/italic, links, code blocks, lists, and pipe tables. Tables accept an optional CSS class for Bootstrap styling.

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

### AutoForm\<T\>

```csharp
using FluentHtml.Forms;

public class CreateUserModel
{
    [Required]
    [Display(Name = "Full Name")]
    public string Name { get; set; } = string.Empty;

    [EmailAddress, Required]
    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public int Age { get; set; }

    public string Role { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}

// Generate a complete form from model type using reflection + DataAnnotations
var form = model.AutoForm("/users/create", MethodType.Post, hx =>
{
    hx.Target = "#result";
    hx.Swap = "innerHTML";
});

// With field configuration
var form = model.AutoForm("/users/create", MethodType.Post, hx: null, cfg =>
{
    cfg.Exclude(m => m.Id);
    cfg.Label(m => m.Name, "Customer Name");
    cfg.SubmitText = "Create User";
    cfg.SubmitClass = "btn btn-success";
});
```

Maps CLR types to input types: `string` → text, `int` → number, `bool` → checkbox, `DateTime` → date, `enum` → select. Supports `[Required]`, `[EmailAddress]`, `[Phone]`, `[Range]`, `[StringLength]`, `[DataType]`, and `[ScaffoldColumn]`.

### File Upload & Drag-and-Drop

```csharp
using FluentHtml.Forms;

// Standard file input with label
model.FileInputGroup(m => m.Document, label: "Choose a file", accept: ".pdf,.doc,.txt")

// HTMX-powered drag-and-drop upload zone
DragDropUpload("/upload", "files", "Drop files here")
    .Accept(".pdf,.doc,.jpg,.png")
    .Target("#upload-result")
    .DropZoneClass("border border-2 border-dashed rounded p-5 text-center")
```

`FileInputFor` / `FileInputGroup` generate `<input type="file">` elements. `DragDropUpload` generates a drop zone with inline JavaScript that uses HTMX to POST files to the server.

### DataGrid\<T\>

```csharp
using FluentHtml.Bootstrap.Components;

var grid = DataGrid<Customer>("/api/customers")
    .Column(c => c.Name, "Name").Sortable()
    .Column(c => c.Email, "Email")
    .Column(c => c.Status, "Status")
        .Render(v => Badge(v?.ToString() ?? "").Success())
    .Column(c => c.Orders, "Orders").Sortable()
    .PageSize(10)
    .CurrentPage(1)
    .TotalItems(totalCount)
    .Id("customer-grid");

// Render with data (server-side paging/sorting)
return grid.RenderWithData(pagedCustomers).ToHtmlResult();
```

HTMX-powered data grid with sortable column headers, pagination controls, custom cell rendering, and Bootstrap-styled striped rows. Sorting and paging send `hx-get` requests to the configured data source URL.

### Charts

```csharp
using FluentHtml.Bootstrap.Components;

// Single dataset
Chart("revenue-chart", ChartType.Bar)
    .Data(new[] { 12500.0, 19000.0, 15000.0, 22000.0 })
    .Labels(new[] { "Jan", "Feb", "Mar", "Apr" })
    .Title("Monthly Revenue")
    .Height(300)

// Multi-series line chart
Chart("growth-chart", ChartType.Line)
    .Dataset("Users", new[] { 100.0, 150.0, 230.0, 310.0 })
    .Dataset("Revenue", new[] { 50.0, 80.0, 140.0, 200.0 })
    .Labels(new[] { "Jan", "Feb", "Mar", "Apr" })
    .DatasetColor("#0d6efd")
    .DatasetColor("#198754")
    .Height(300)
```

Renders Chart.js charts from .NET. Supports Bar, Line, Pie, Doughnut, Radar, and PolarArea types. Single or multiple datasets with custom colors per dataset. Chart.js is loaded via CDN.

### Dark Mode / Theme Toggle

```csharp
using FluentHtml.Bootstrap.Components;

// Theme toggle button (switches Bootstrap data-bs-theme attribute)
ThemeToggle().Id("theme-toggle")

// Apply dark mode by default to an element
Div("Content").Theme("dark")
```

Toggle button uses inline JavaScript to switch between light and dark themes via Bootstrap's `data-bs-theme` attribute.

### Bootstrap Icons

```csharp
using FluentHtml.Bootstrap.Components;

// Bootstrap Icons via factory methods
BiIcon("house")              // <i class="bi bi-house"></i>
BiIcon("pencil").Size(Lg)    // <i class="bi bi-pencil fs-5"></i>
BiIcon("trash").Size(Xl)     // <i class="bi bi-trash fs-1"></i>
```

Framework-agnostic icon abstraction in Core; Bootstrap Icons implementation in the Bootstrap package. Additional icon sets (Font Awesome, Material Icons) can be added as community packages.

### Progress Bar

```csharp
using FluentHtml.Bootstrap.Components;

// Basic progress bar
ProgressBar(
    ProgressBarFill("75%").Width(75)
)

// Striped and animated with color
ProgressBar(
    ProgressBarFill("50%").Width(50).Success().Striped().Animated()
).Height("25px")

// Stacked progress bars
ProgressBar(
    ProgressBarFill().Width(35).Primary(),
    ProgressBarFill().Width(25).Success(),
    ProgressBarFill().Width(20).Info()
)
```

Color variants: `Primary()`, `Secondary()`, `Success()`, `Danger()`, `Warning()`, `Info()`, `Light()`, `Dark()`. Add `Striped()` for stripes and `Animated()` for moving stripes.

### Layouts

```csharp
using FluentHtml.Bootstrap.Components;

// Sidebar with navigation
Sidebar(
    SidebarBrand("My App").Href("/"),
    SidebarNav(
        SidebarSection(
            SidebarSectionHeading("Main"),
            SidebarNavItem(SidebarNavLink("Dashboard").Href("/dashboard").Active()),
            SidebarNavItem(SidebarNavLink("Users").Href("/users")),
            SidebarNavItem(SidebarNavLink("Settings").Href("/settings"))
        )
    )
).Width("280px").MinHeight("100vh")

// Dashboard layout (header + sidebar + content + footer)
DashboardLayout(
    header: new[] { Navbar(...).Dark() },
    sidebar: new[] { Sidebar(...) },
    content: new[] { Div("Main content").Class("p-4") }
)

// Split layout (two panels, stacks on mobile)
SplitLayout(
    SplitPanel(Div("Left panel")).FlexGrow1().Border(),
    SplitPanel(Div("Right panel")).FlexGrow1()
)
```

`ResponsiveLayout` provides header/sidebar/content/footer regions. `DashboardLayout` wraps them into a pre-built pattern. `SplitLayout` creates two-panel layouts that stack vertically on mobile.

### Tree Navigation

```csharp
using FluentHtml.Bootstrap.Components;

// Static tree
BootstrapTree(
    BootstrapTreeNode(
        BootstrapTreeToggle("Documents"),
        BootstrapTreeChildren(
            BootstrapTreeLeaf("report.pdf"),
            BootstrapTreeLeaf("notes.txt")
        )
    ),
    BootstrapTreeNode(
        BootstrapTreeToggle("Images"),
        BootstrapTreeChildren(
            BootstrapTreeLeaf("photo.jpg")
        )
    )
).TreeLines()

// Lazy-loaded tree (fetches children via HTMX on expand)
BootstrapTreeNode(
    BootstrapTreeToggle("Users")
        .HxLoad("/api/tree/users", "next .tree-children"),
    BootstrapTreeChildren().Collapsed()
)
```

Framework-agnostic `TreeComponent` in Core; `BootstrapTreeComponent` with Bootstrap styling and HTMX lazy-loading in the Bootstrap package.

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

No web server required. Components are plain .NET objects — instantiate, render, assert.

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
