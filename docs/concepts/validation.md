# FluentHtml.Validation

Validation components for FluentHtml.

## Installation

```bash
dotnet add package FluentHtml.Validation
```

## Key Features

### ValidationMessage

Display validation errors for a specific property:

```csharp
model.ValidationMessage(x => x.Name)
```

This renders a `<span>` with the validation error message if the property is invalid.

### ValidationSummary

Display all validation errors:

```csharp
modelState.ValidationSummary("Validation Errors")
```

### CSS Class Helpers

Check validation state:

```csharp
model.HasError(x => x.Name, modelState)
// Returns true/false

var cssClass = model.ValidationCssClass(x => x.Name, modelState);
// Returns "is-valid" or "is-invalid"
```

### Validate Extension

Validate a model using DataAnnotations attributes without `ModelStateDictionary`:

```csharp
using FluentHtml.Validation;

public class CreateUserModel
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email")]
    public string Email { get; set; }
}

// In your handler:
var validation = model.Validate();
if (!validation.IsValid)
    return CreateForm(validation.Errors[0]).HxSwapOob("outerHTML:#create-form");
```

## Complete Example with HTMX

```csharp
using FluentHtml.Validation;

public class CustomerCreateModel
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = "";

    public string? Phone { get; set; }
}

public static Node CreateCustomer(CustomerCreateModel model)
{
    var validation = model.Validate();
    if (!validation.IsValid)
        return CreateForm(validation.Errors[0])
            .HxSwapOob("outerHTML:#create-form");

    // Process valid model...
    return RenderCustomerRow(customer);
}
```

## DataAnnotations Support

FluentHtml.Validation works with standard ASP.NET Core DataAnnotations:

```csharp
public class UserModel
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Range(18, 120)]
    public int Age { get; set; }
}
```
