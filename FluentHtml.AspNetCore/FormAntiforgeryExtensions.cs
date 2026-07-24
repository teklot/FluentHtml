using FluentHtml.Elements;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace FluentHtml.AspNetCore;

public static class FormAntiforgeryExtensions
{
    public static FormElement Antiforgery(this FormElement form, HttpContext httpContext)
    {
        var antiforgery = httpContext.RequestServices.GetRequiredService<IAntiforgery>();
        var tokens = antiforgery.GetAndStoreTokens(httpContext);

        var hiddenField = new InputElement()
            .Type("hidden")
            .Name(tokens.FormFieldName)
            .Value(tokens.RequestToken!);

        form.AddChild(hiddenField);
        return form;
    }
}
