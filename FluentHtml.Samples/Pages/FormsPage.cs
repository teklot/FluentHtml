using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class FormsPage
{
    public static IResult Render(HttpContext http)
    {
        var model = new CreateUserModel();

        return Layout.Page(http,
            BreadcrumbHelper.MakeBreadcrumb(("Home", "/"), ("Forms", null)),
            H1("FluentHtml.Forms & Validation"),
            Alert("Forms and Validation provide strongly-typed, model-bound form helpers with DataAnnotations integration.").Info(),

            SectionHelper.ShowSection("Strongly-Typed Form", Form(
                H3("Create User"),

                Div(
                    model.LabelFor(m => m.Name),
                    model.InputFor(m => m.Name).Placeholder("John Doe").Required(),
                    model.ValidationMessage(m => m.Name, new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
                ).Class("mb-3"),

                Div(
                    model.LabelFor(m => m.Email),
                    model.InputFor(m => m.Email, "email").Placeholder("john@example.com").Required(),
                    model.ValidationMessage(m => m.Email, new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
                ).Class("mb-3"),

                Div(
                    model.LabelFor(m => m.Password),
                    model.InputFor(m => m.Password, "password").Required(),
                    model.ValidationMessage(m => m.Password, new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
                ).Class("mb-3"),

                Div(
                    model.LabelFor(m => m.Role),
                    model.SelectFor(m => m.Role, new[]
                    {
                        new SelectListItem { Text = "Select...", Value = "" },
                        new SelectListItem { Text = "Admin", Value = "admin" },
                        new SelectListItem { Text = "User", Value = "user" },
                        new SelectListItem { Text = "Editor", Value = "editor" }
                    }).Required(),
                    model.ValidationMessage(m => m.Role, new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
                ).Class("mb-3"),

                Div(
                    model.LabelFor(m => m.Bio),
                    model.TextAreaFor(m => m.Bio, rows: 4)
                ).Class("mb-3"),

                Div(
                    model.CheckboxFor(m => m.Terms),
                    model.CheckboxLabelFor(m => m.Terms)
                ).Class("form-check mb-3"),

                FluentFormExtensions.SubmitButton("Create User").HxPost("/forms/create").HxTarget("#user-form").HxSwap("outerHTML")
            ).Action("/forms/create").Method("post").Id("user-form")),

            SectionHelper.ShowSection("AutoForm<T>", Div(
                P("Auto-generates complete forms from model types with DataAnnotations. Supports field exclusion, custom labels, field type overrides, and HTMX integration."),
                new PreElement(
                    "AutoForm<CreateUserModel>()\n    .Exclude(m => m.Id)\n    .Label(m => m.Name, \"Full Name\")\n    .Field(m => m.Password, FieldType.Password)\n    .HtmxForm(config => config\n        .Post(\"/users/create\")\n        .Target(\"#result\")\n        .Swap(\"outerHTML\"))\n    .SubmitText(\"Create Account\")\n    .SubmitClass(\"btn btn-success\")"
                ).Class("bg-dark text-light p-3 rounded small font-monospace mb-3"),
                A("See full AutoForm demo").Href("/autoform").Class("btn btn-outline-primary btn-sm")
            )),

            SectionHelper.ShowSection("File Upload", Div(
                P("File input components for single, multi-file, and drag-and-drop uploads with HTMX integration."),
                A("See full Upload demo").Href("/upload").Class("btn btn-outline-primary btn-sm")
            ))
        ).ToHtmlResult();
    }

    public static Node CreateUser(CreateUserModel model)
    {
        var modelState = new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary();

        if (string.IsNullOrWhiteSpace(model.Name))
            modelState.AddModelError(nameof(model.Name), "Name is required");
        if (string.IsNullOrWhiteSpace(model.Email))
            modelState.AddModelError(nameof(model.Email), "Email is required");
        else if (!model.Email.Contains("@"))
            modelState.AddModelError(nameof(model.Email), "Invalid email address");
        if (string.IsNullOrWhiteSpace(model.Password))
            modelState.AddModelError(nameof(model.Password), "Password is required");
        else if (model.Password.Length < 6)
            modelState.AddModelError(nameof(model.Password), "Password must be at least 6 characters");
        if (string.IsNullOrWhiteSpace(model.Role))
            modelState.AddModelError(nameof(model.Role), "Please select a role");

        if (!modelState.IsValid)
        {
            return Form(
                Alert("Please fix the errors below.").Danger(),
                modelState.ValidationSummary("Validation Errors"),
                Div(
                    model.LabelFor(m => m.Name),
                    model.InputFor(m => m.Name).Placeholder("John Doe").Class(
                        model.HasError(m => m.Name, modelState) ? "form-control is-invalid" : "form-control"),
                    model.ValidationMessage(m => m.Name, modelState)
                ).Class("mb-3"),
                Div(
                    model.LabelFor(m => m.Email),
                    model.InputFor(m => m.Email, "email").Placeholder("john@example.com").Class(
                        model.HasError(m => m.Email, modelState) ? "form-control is-invalid" : "form-control"),
                    model.ValidationMessage(m => m.Email, modelState)
                ).Class("mb-3"),
                Div(
                    model.LabelFor(m => m.Password),
                    model.InputFor(m => m.Password, "password").Class(
                        model.HasError(m => m.Password, modelState) ? "form-control is-invalid" : "form-control"),
                    model.ValidationMessage(m => m.Password, modelState)
                ).Class("mb-3"),
                Div(
                    model.LabelFor(m => m.Role),
                    model.SelectFor(m => m.Role, new[]
                    {
                        new SelectListItem { Text = "Select...", Value = "" },
                        new SelectListItem { Text = "Admin", Value = "admin" },
                        new SelectListItem { Text = "User", Value = "user" },
                        new SelectListItem { Text = "Editor", Value = "editor" }
                    }).Class(
                        model.HasError(m => m.Role, modelState) ? "form-select is-invalid" : "form-select"),
                    model.ValidationMessage(m => m.Role, modelState)
                ).Class("mb-3"),
                Div(
                    model.LabelFor(m => m.Bio),
                    model.TextAreaFor(m => m.Bio, rows: 4)
                ).Class("mb-3"),
                Div(
                    model.CheckboxFor(m => m.Terms),
                    model.CheckboxLabelFor(m => m.Terms)
                ).Class("form-check mb-3"),
                FluentFormExtensions.SubmitButton("Create User").HxPost("/forms/create").HxTarget("#user-form").HxSwap("outerHTML")
            ).Action("/forms/create").Method("post").Id("user-form").Class("mt-3");
        }

        return Alert($"User '{model.Name}' created successfully! (POST received by server)").Success();
    }
}
