# FluentHtml.Rendering

The rendering package converts FluentHtml node trees to HTML strings.

## Installation

```bash
dotnet add package FluentHtml.Rendering
```

## Key Types

### Renderer

Converts a node tree to HTML output.

```csharp
var renderer = new Renderer();
string html = renderer.Render(node);
```

**Methods:**
- `Render(Node)` - Render to HTML string
- `Render(Node, TextWriter)` - Render to a text writer

### HtmlWriter

Low-level HTML output builder.

**Methods:**
- `WriteRaw(string)` - Write raw HTML
- `WriteOpenTag(string)` - Write opening tag
- `WriteCloseTag(string)` - Write closing tag
- `WriteSelfClosingTag(string)` - Write self-closing tag
- `WriteAttribute(string, string)` - Write attribute with value
- `WriteBooleanAttribute(string)` - Write boolean attribute
- `WriteText(string)` - Write encoded text
- `ToStringAndClear()` - Get output and clear buffer

### HtmlEncoder

HTML encoding utilities.

**Methods:**
- `Encode(string)` - Encode string for safe HTML output
- `Encode(string, StringBuilder)` - Encode and append to builder
