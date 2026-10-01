# FluentHtml.Bootstrap

Bootstrap component library for FluentHtml.

## Installation

```bash
dotnet add package FluentHtml.Bootstrap
```

## Available Components

### Button

```csharp
Btn("Click Me")
    .Primary()
    .Large()
    .HxPost("/action");
```

**Styles:** Primary, Secondary, Success, Danger, Warning, Info, Light, Dark, Link
**Outline Styles:** OutlinePrimary, OutlineSecondary, OutlineSuccess, etc.
**Sizes:** Small, Large

### Card

```csharp
Card()
    .CardHeader("Card Title")
    .CardBody(
        P("Card content"),
        Btn("Action").Primary()
    )
    .CardFooter("Footer");
```

### Alert

```csharp
Alert()
    .Success()
    .Children(P("Operation completed successfully."));
```

### Modal

```csharp
Modal()
    .ModalDialog(
        ModalContent()
            .ModalHeader("Confirm")
            .ModalBody(P("Are you sure?"))
            .ModalFooter(Btn("Cancel").Secondary(), Btn("OK").Primary())
    );
```

### Navbar

```csharp
Navbar()
    .NavbarBrand("MyApp")
    .NavbarNav(
        NavbarNavItem(A("Home").Href("/")),
        NavbarNavItem(A("About").Href("/about"))
    );
```

### Wizard

Linear multi-step flows. Steps backed by a URL load their panel over HTMX and swap into
`#{id}-panel`; inline steps render their content directly. Validation is server-side, so a
step endpoint decides whether the flow may advance.

```csharp
Wizard()
    .Id("signup-wizard")
    .Step("Account", "/wizard/step/account")
    .Step("Profile", "/wizard/step/profile")
    .Step("Review", "/wizard/step/review")
    .Label("Step 1 of 3")
    .Include("[name=email]")
    .FinishHxPost("/wizard/step/complete")
```

Use `Include` to carry collected form values into the next step's request. Because a step's
fields only exist while that step is on screen, the wizard keeps every value it has collected
for the life of the flow: later steps still receive earlier answers, going Back restores what was
typed, and Finish submits the whole set rather than just the visible fields.

Back stays available on the final step so a user can correct an earlier answer. Finishing retires
the navigation: the component issues the finish request with everything it collected, then hides
Back and Next and locks the step links. `FinishHref` still navigates the browser normally instead.

To reject a step (for example when a required field is empty), mark the endpoint's root element
with `data-wizard-reject`. The indicator then returns to the step the user came from, so the
error appears on the tab that caused it rather than the next one.

```csharp
var rejected = Div(Alert("Email is required before continuing.").Danger(), AccountContent());
rejected.Attributes.Set("data-wizard-reject", "true");
return rejected.ToHtmlResult();
```

| Method | Description |
|---|---|
| `Id(string)` | Required. Root id; the panel is derived as `{id}-panel`. |
| `Step(title, content)` | Adds a step with inline content. |
| `Step(title, hxUrl)` | Adds a step whose panel loads over HTMX. |
| `ActiveStep(int)` | Zero-based index of the active step. |
| `Linear(bool = true)` | When true (default), steps after the active one are disabled. |
| `Label(string)` | Step counter text. The initial value is shown on render; the component then keeps it accurate as "Step M of N" while navigating. |
| `Include(selector)` | CSS selector whose field values are sent with each step request. |
| `PrevText/NextText/FinishText` | Navigation button labels. |
| `FinishHxGet/FinishHxPost(url)` | Wires the terminal action over HTMX. |
| `FinishHref(url)` | Navigates to a URL on finish. |

`WizardComponent.Id` and at least one `Step` must be set before rendering, and
`ActiveStep` must be within range; otherwise `Render()` throws.

Navigation state (locked steps, Back/Next/Finish, the active tab) is maintained by a small
component-owned script, because the server renders the chrome once while navigation happens
client-side.

### Breadcrumb

```csharp
Breadcrumb(
    BreadcrumbList(
        BreadcrumbItem(BreadcrumbLink("Home").Href("/")),
        BreadcrumbItem(BreadcrumbLink("Library").Href("/library")),
        BreadcrumbItem("Data").Active().AriaCurrent("page")
    )
).AriaLabel("breadcrumb")
```

**Custom separators** — sets Bootstrap's `--bs-breadcrumb-divider`:

```csharp
BreadcrumbList(/* items */).Separator(">")
```

**Collapsible trailing items** — keeps the first `keepVisible` items visible and hides the
rest behind a toggle. Bootstrap has no native breadcrumb overflow, so the component wires a
Bootstrap collapse region and injects its own minimal stylesheet.

```csharp
Breadcrumb(
    BreadcrumbCollapse(2,
        BreadcrumbItem(BreadcrumbLink("Home").Href("/")),
        BreadcrumbItem(BreadcrumbLink("Library").Href("/library")),
        BreadcrumbItem(BreadcrumbLink("Reports").Href("/reports")),
        BreadcrumbItem(BreadcrumbLink("Detail").Href("/detail")).Active().AriaCurrent("page")
    )
)
```

`ToggleLabel(string)` changes the toggle text (default `...`).

**HTMX active state** — navigate without a full page load:

```csharp
BreadcrumbLink("Orders").HxGet("/orders").Target("#content").Swap("innerHTML")
```

`HxGet` defaults to `hx-push-url="true"` and `hx-swap="outerHTML"`.

Collapse is Bootstrap-only. The framework-agnostic breadcrumb in `FluentHtml.Core` offers
`AriaCurrent`, `Separator`, and list control instead, since those need no JavaScript or CSS.

## CSS Helpers

Extension methods for applying Bootstrap utility classes:

```csharp
// Colors
element.Primary().Success().Danger()

// Spacing
element.Mt(3).Mb(2).Px(4).Py(2)

// Display
element.DFlex().DNone().DBlock()

// Flexbox
element.FlexRow().JustifyCenter().AlignCenter()

// Borders
element.Border().Rounded().RoundedCircle()

// Shadows
element.Shadow().ShadowLg()
```
