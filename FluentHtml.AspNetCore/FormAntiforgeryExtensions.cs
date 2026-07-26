using FluentHtml.Elements;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace FluentHtml.AspNetCore;

/// <summary>
/// Provides extension methods for adding ASP.NET Core antiforgery token hidden fields to <see cref="FormElement"/> instances.
/// </summary>
public static class FormAntiforgeryExtensions
{
    /// <summary>
    /// Adds a hidden input field containing the antiforgery token to the specified form.
    /// </summary>
    /// <param name="form">The <see cref="FormElement"/> to add the antiforgery hidden field to.</param>
    /// <param name="httpContext">The current <see cref="HttpContext"/>, used to resolve the <see cref="IAntiforgery"/> service and generate tokens.</param>
    /// <returns>The modified <see cref="FormElement"/> with the antiforgery hidden field appended.</returns>
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
