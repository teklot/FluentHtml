using System.Net;
using System.Web;

namespace FluentHtml.Rendering;

/// <summary>
/// Provides HTML encoding utilities to prevent XSS attacks and ensure valid HTML output.
/// </summary>
public static class HtmlEncoder
{
    /// <summary>
    /// Encodes a string value for safe HTML output.
    /// </summary>
    /// <param name="value">The string to encode.</param>
    /// <returns>The HTML-encoded string. Returns empty string if input is null or empty.</returns>
    public static string Encode(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        return HttpUtility.HtmlEncode(value);
    }

    /// <summary>
    /// Encodes a string value and appends it to a string builder.
    /// </summary>
    /// <param name="value">The string to encode.</param>
    /// <param name="sb">The string builder to append to.</param>
    public static void Encode(string value, System.Text.StringBuilder sb)
    {
        if (string.IsNullOrEmpty(value))
            return;

        sb.Append(HttpUtility.HtmlEncode(value));
    }
}
