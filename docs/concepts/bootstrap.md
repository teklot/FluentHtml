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
