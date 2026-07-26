# Architecture

## Overview

FluentHtml follows a layered architecture that integrates seamlessly with ASP.NET Core:

```
Browser → HTTP Request → ASP.NET Core Pipeline → Minimal API Route → FluentHtml Components → Rendering Engine → HTML Response → Browser
```

## Node Hierarchy

```
Node
├── Element      (single HTML tag: Div, Span, Button, Form, Table, Input...)
├── TextNode     (plain text, always HTML encoded)
├── RawHtml      (trusted HTML, not encoded - use sparingly)
├── Fragment     (groups multiple sibling nodes without wrapper element)
└── Component    (reusable UI, composes existing nodes)
```

## Rendering Pipeline

```
Component Tree → Normalize → Render → Encode → HTML
```

1. **Normalize**: Walk the tree; every node becomes part of a render queue
2. **Render**: Elements write opening tag, attributes, children, closing tag
3. **Encode**: Text and attribute content is HTML-encoded
4. **Output**: Final HTML string returned to ASP.NET Core

## Component Model

### Components vs Elements

| Aspect | Elements | Components |
|--------|----------|------------|
| Represents | HTML tags | Application UI |
| Renders | Exactly one HTML tag | May render many elements |
| Example | `Button` → `<button>` | `CustomerCard` → Card, Image, Heading |

### Component Rules

**A component may:**
- Compose nodes
- Accept data
- Configure elements
- Encapsulate UI

**A component should NOT:**
- Query databases
- Call APIs
- Resolve services
- Perform business logic

## Fluent API Design

Every configuration method returns the current object for method chaining:

```csharp
Button("Save")
    .Primary()
    .Large()
    .HxPost("/users")
    .Target("#content")
```

## Thread Safety

- Components should be immutable
- Renderers should be stateless
- Applications should safely render multiple requests concurrently