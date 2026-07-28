# FluentHtml.Htmx

HTMX attribute extensions for FluentHtml.

## Installation

```bash
dotnet add package FluentHtml.Htmx
```

## Available Methods

### Request Methods

| Method | HTMX Attribute | Description |
|--------|---------------|-------------|
| `HxGet(url)` | `hx-get` | Issue GET request |
| `HxPost(url)` | `hx-post` | Issue POST request |
| `HxPut(url)` | `hx-put` | Issue PUT request |
| `HxDelete(url)` | `hx-delete` | Issue DELETE request |
| `HxPatch(url)` | `hx-patch` | Issue PATCH request |

### Response Methods

| Method | HTMX Attribute | Description |
|--------|---------------|-------------|
| `HxSwap(style)` | `hx-swap` | Control how response is swapped |
| `HxTarget(selector)` | `hx-target` | Specify target element |
| `HxTrigger(event)` | `hx-trigger` | Specify when to trigger |
| `HxSwapOob(swapStyle)` | `hx-swap-oob` | Out-of-band swap strategy |

### Additional Methods

| Method | HTMX Attribute | Description |
|--------|---------------|-------------|
| `HxBoost(bool)` | `hx-boost` | Enable/disable boost |
| `HxIndicator(class)` | `hx-indicator` | Loading indicator class |
| `HxConfirm(message)` | `hx-confirm` | Confirmation dialog |
| `HxPushUrl(url)` | `hx-push-url` | Push URL to history |
| `HxSelect(selector)` | `hx-select` | Select content from response |
| `HxVals(json)` | `hx-vals` | Include additional values |
| `HxHeaders(json)` | `hx-headers` | Include additional headers |
| `HxInclude(selector)` | `hx-include` | Include additional elements in request |
| `HxParams(filter)` | `hx-params` | Control parameter inclusion |
| `HxSync(strategy)` | `hx-sync` | Synchronize requests |

## Response Builder

Combine main swap and out-of-band swaps using `HtmxResponse` from `FluentHtml.Htmx`:

```csharp
return TodoItemRow(item)
    .Htmx()
    .Oob(CreateForm().HxSwapOob("outerHTML:#create-form"));
```

## Example

```csharp
using FluentHtml.Htmx;

var button = Button("Load Users")
    .HxGet("/api/users")
    .HxTarget("#user-list")
    .HxSwap("innerHTML")
    .HxIndicator("#loading");
```
