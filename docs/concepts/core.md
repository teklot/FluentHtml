# FluentHtml (Core)

The core FluentHtml package provides the fundamental building blocks for HTML generation.

## Installation

```bash
dotnet add package FluentHtml.Core
```

## Key Types

### Node

Abstract base class for all nodes in the component tree.

- `Children` - List of child nodes
- `AddChild(Node)` - Add a child node
- `AddChildren(IEnumerable<Node>)` - Add multiple child nodes
- `AddText(string)` - Add a text content child

### Element

Abstract base class for all HTML elements.

**Fluent Methods:**
- `Id(string)` - Set the id attribute
- `Class(string)` - Add CSS classes
- `Style(string)` - Set inline styles
- `Title(string)` - Set the title attribute
- `Data(string, string)` - Set data attributes
- `Aria(string, string)` - Set ARIA attributes
- `Role(string)` - Set the role attribute
- `TabIndex(int)` - Set tab order
- `Hidden()` - Mark as hidden
- `Disabled()` - Mark as disabled
- `Required()` - Mark as required
- `ReadOnly()` - Mark as read-only
- `Checked()` - Mark as checked
- `Custom(string, string)` - Set custom attributes
- `On(string, string)` - Set event handlers

### Component

Abstract base class for reusable UI components.

```csharp
public abstract class Component : Node
{
    public abstract Node Render();
}

public abstract class Component<T> : Component
{
    protected T Data { get; }
    protected abstract Node Build(T data);
}
```

## Standalone Breadcrumb

`FluentHtml.Core` ships a framework-agnostic breadcrumb that renders semantic
`nav > ol > li` with no CSS framework dependency. For Bootstrap-styled breadcrumbs, use the
breadcrumb in `FluentHtml.Bootstrap`.

```csharp
Breadcrumb(
    BreadcrumbItem("Home"),
    BreadcrumbItem("Data").AriaCurrent("page")
);
```

| Method | Description |
|---|---|
| `BreadcrumbItemComponent.AriaCurrent(value)` | Marks the current page for assistive technology. Framework-agnostic, unlike `Active()`, which adds Bootstrap's `active` class name. |
| `BreadcrumbItemComponent.Separator(separator)` | Renders an `aria-hidden` separator inside the item. Accepts text or a `Node`. Nested because an `ol` may only contain `li`. |
| `BreadcrumbListComponent` / `BreadcrumbList(items)` | Supplies your own list element instead of relying on the factory's implicit `ol` wrapper. |

```csharp
// Control the list element and add separators
Breadcrumb(
    BreadcrumbList(
        BreadcrumbItem("Home").Separator("/"),
        BreadcrumbItem("Data").AriaCurrent("page")
    )
);
```

Collapsible trailing items and HTMX navigation are Bootstrap-only, since they require
JavaScript and a CSS runtime.

## Factory Methods

All HTML elements have factory extension methods:

```csharp
Div()              // Creates <div></div>
Span("text")       // Creates <span>text</span>
Button("Click")    // Creates <button>Click</button>
Input()            // Creates <input />
Form(children)     // Creates <form>...</form>
```

## Rendering

Convert a node tree to HTML using the `Renderer` (`using FluentHtml.Rendering;`):

```csharp
var renderer = new Renderer();
string html = renderer.Render(node);
// or write to a TextWriter:
renderer.Render(node, textWriter);
```

### HtmlWriter

Low-level HTML output builder.

| Method | Description |
|--------|-------------|
| `WriteRaw(string)` | Write raw HTML |
| `WriteOpenTag(string)` | Write opening tag |
| `WriteCloseTag(string)` | Write closing tag |
| `WriteSelfClosingTag(string)` | Write self-closing tag |
| `WriteAttribute(string, string)` | Write attribute with value |
| `WriteBooleanAttribute(string)` | Write boolean attribute |
| `WriteText(string)` | Write encoded text |
| `ToStringAndClear()` | Get output and clear buffer |

### HtmlEncoder

HTML encoding utilities.

| Method | Description |
|--------|-------------|
| `Encode(string)` | Encode string for safe HTML output |
| `Encode(string, StringBuilder)` | Encode and append to builder |
