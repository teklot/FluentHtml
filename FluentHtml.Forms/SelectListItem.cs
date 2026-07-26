namespace FluentHtml.Forms;

/// <summary>
/// Represents an option within a select element, holding the display text, underlying value, and selection state.
/// </summary>
public sealed class SelectListItem
{
    /// <summary>
    /// Gets or sets the display text shown to the user for this option.
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the underlying value submitted with the form when this option is selected.
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether this option is pre-selected.
    /// </summary>
    public bool Selected { get; set; }
}
