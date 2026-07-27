# FluentHtml.Forms

Strongly-typed form helpers for FluentHtml.

## Installation

```bash
dotnet add package FluentHtml.Forms
```

## Key Methods

### InputFor

Create a text input bound to a model property:

```csharp
var model = new UserModel();
var input = model.InputFor(x => x.Name);
```

**Overload with type:**
```csharp
var emailInput = model.InputFor(x => x.Email, "email");
```

### LabelFor

Create a label bound to a model property:

```csharp
var label = model.LabelFor(x => x.Name);
```

### TextAreaFor

Create a textarea bound to a model property:

```csharp
var textarea = model.TextAreaFor(x => x.Bio, rows: 6);
```

### SelectFor

Create a select dropdown bound to a model property:

```csharp
var select = model.SelectFor(x => x.Country, new[]
{
    new SelectListItem("United States", "US"),
    new SelectListItem("United Kingdom", "UK"),
    new SelectListItem("Canada", "CA")
});
```

### CheckboxFor

Create a checkbox bound to a model property:

```csharp
var checkbox = model.CheckboxFor(x => x.IsActive);
var label = model.CheckboxLabelFor(x => x.IsActive, "Is Active");
```

### SubmitButton

Create a submit button:

```csharp
var submit = FluentFormExtensions.SubmitButton("Save");
var submitStyled = FluentFormExtensions.SubmitButton("Save", "btn btn-success");
```

## Complete Example

```csharp
using FluentHtml.Forms;

app.MapGet("/create", (HttpContext http) =>
{
    var model = new CreateUserModel();
    return Form()
        .Antiforgery(http)
        .Method("post")
        .Action("/users/create")
        .Children(
            model.LabelFor(x => x.Name),
            model.InputFor(x => x.Name),
            
            model.LabelFor(x => x.Email),
            model.InputFor(x => x.Email, "email"),
            
            SubmitButton("Create User")
        );
});
```
