using FluentHtml.Nodes;

namespace FluentHtml.Htmx;

/// <summary>
/// Builds an HTMX response combining a main swap element with optional out-of-band swap elements.
/// When no OOB elements are added, the main content is used directly as the response.
/// When OOB elements are present, all elements are rendered as siblings.
/// Note: Avoid using table row elements (<c>tr</c>, <c>td</c>, etc.) as the main content
/// when OOB elements are present — the browser HTML parser moves them into an implicit
/// <c>table</c>, which corrupts the HTMX swap. Return table content alone (no OOB) instead.
/// </summary>
public sealed class HtmxResponse : Node
{
    /// <summary>
    /// Initializes a new instance with the specified main swap content.
    /// </summary>
    /// <param name="mainContent">The primary content to swap into the target element.</param>
    public HtmxResponse(Node mainContent)
    {
        AddChild(mainContent);
    }

    /// <summary>
    /// Adds an out-of-band swap element to the response.
    /// </summary>
    /// <param name="oobNode">The element to swap out-of-band (must have <c>hx-swap-oob</c> set).</param>
    /// <returns>The current <see cref="HtmxResponse"/> for chaining.</returns>
    public HtmxResponse Oob(Node oobNode)
    {
        AddChild(oobNode);
        return this;
    }
}
