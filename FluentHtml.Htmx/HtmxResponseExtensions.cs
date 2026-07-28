using FluentHtml.Nodes;

namespace FluentHtml.Htmx;

/// <summary>
/// Provides the <see cref="Htmx"/> extension method for creating <see cref="HtmxResponse"/> instances.
/// </summary>
public static class HtmxResponseExtensions
{
    /// <summary>
    /// Begins building an HTMX response from the specified main swap content.
    /// </summary>
    /// <param name="mainContent">The primary content to swap into the target element.</param>
    /// <returns>An <see cref="HtmxResponse"/> that can be extended with OOB swaps.</returns>
    public static HtmxResponse Htmx(this Node mainContent)
    {
        return new HtmxResponse(mainContent);
    }
}
