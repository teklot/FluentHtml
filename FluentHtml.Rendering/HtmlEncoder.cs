using System.Net;
using System.Web;

namespace FluentHtml.Rendering;

public static class HtmlEncoder
{
    public static string Encode(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        return HttpUtility.HtmlEncode(value);
    }

    public static void Encode(string value, System.Text.StringBuilder sb)
    {
        if (string.IsNullOrEmpty(value))
            return;

        sb.Append(HttpUtility.HtmlEncode(value));
    }
}
