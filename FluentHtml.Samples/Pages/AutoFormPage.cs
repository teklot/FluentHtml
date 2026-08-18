using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class AutoFormPage
{
    public class UserModel
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Full Name")]
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; } = string.Empty;

        [System.ComponentModel.DataAnnotations.EmailAddress]
        [System.ComponentModel.DataAnnotations.Required]
        public string Email { get; set; } = string.Empty;

        [System.ComponentModel.DataAnnotations.Phone]
        public string? Phone { get; set; }

        public int Age { get; set; }

        public string Role { get; set; } = string.Empty;

        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
        public string? Bio { get; set; }

        public bool IsActive { get; set; }
    }

    public static IResult Render(HttpContext http)
    {
        var model = new UserModel();
        var form = model.AutoForm("/autoform/create", Enums.MethodType.Post, hx =>
        {
            hx.Target = "#form-result";
            hx.Swap = "innerHTML";
        });

        var page = Layout.Page(http,
            H1("AutoForm<T>"),
            P("Automatically generate a complete form from a model type using reflection and DataAnnotations."),
            Hr(),

            Div().Id("form-result"),

            Card(
                CardHeader("Auto-Generated Form"),
                CardBody(form)
            ).Class("mb-4"),

            H2("Features"),
            Ul(
                Li("Automatic field generation from model properties"),
                Li("Supports [Required], [EmailAddress], [Phone], [Range], [StringLength]"),
                Li("Enum properties become <select> dropdowns"),
                Li("Boolean properties become checkboxes"),
                Li("Optional HTMX integration for partial rendering"),
                Li("Customizable labels, excluded fields, and submit button")
            )
        );

        return page.ToHtmlResult();
    }

    public static IResult CreateUser(HttpContext http, UserModel model)
    {
        var success = Div()
            .Class("alert alert-success");
        success.AddChild(new FluentHtml.Nodes.TextNode($"Created user: {model.Name} ({model.Email})"));
        return success.ToHtmlResult();
    }
}
