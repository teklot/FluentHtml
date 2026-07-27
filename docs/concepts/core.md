# FluentHtml (Core)

The core FluentHtml package provides the fundamental building blocks for HTML generation.

## Installation

```bash
dotnet add package FluentHtml
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

## Factory Methods

All HTML elements have factory extension methods:

```csharp
Div()              // Creates <div></div>
Span("text")       // Creates <span>text</span>
Button("Click")    // Creates <button>Click</button>
Input()            // Creates <input />
Form(children)     // Creates <form>...</form>
```
