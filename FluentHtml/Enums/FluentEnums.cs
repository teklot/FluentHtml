namespace FluentHtml.Enums;

/// <summary>
/// Represents the type attribute for HTML button elements.
/// </summary>
public enum ButtonType
{
    /// <summary>The button submits the form data.</summary>
    Submit,
    /// <summary>The button is a normal clickable button.</summary>
    Button,
    /// <summary>The button resets the form data.</summary>
    Reset
}

/// <summary>
/// Represents the type attribute for HTML input elements.
/// </summary>
public enum InputType
{
    /// <summary>Single-line text input.</summary>
    Text,
    /// <summary>Email address input with validation.</summary>
    Email,
    /// <summary>Password input with masked characters.</summary>
    Password,
    /// <summary>Checkbox for multi-select options.</summary>
    Checkbox,
    /// <summary>Radio button for single-select options.</summary>
    Radio,
    /// <summary>Numeric input.</summary>
    Number,
    /// <summary>Date picker input.</summary>
    Date,
    /// <summary>File upload input.</summary>
    File,
    /// <summary>Hidden input not visible to the user.</summary>
    Hidden,
    /// <summary>URL input with validation.</summary>
    Url,
    /// <summary>Telephone number input.</summary>
    Tel,
    /// <summary>Search input.</summary>
    Search,
    /// <summary>Color picker input.</summary>
    Color,
    /// <summary>Range slider input.</summary>
    Range,
    /// <summary>Date and time input.</summary>
    DateTimeLocal,
    /// <summary>Month picker input.</summary>
    Month,
    /// <summary>Time picker input.</summary>
    Time,
    /// <summary>Week picker input.</summary>
    Week
}

/// <summary>
/// Represents the method attribute for HTML form elements.
/// </summary>
public enum MethodType
{
    /// <summary>HTTP GET method.</summary>
    Get,
    /// <summary>HTTP POST method.</summary>
    Post,
    /// <summary>HTTP PUT method.</summary>
    Put,
    /// <summary>HTTP DELETE method.</summary>
    Delete,
    /// <summary>HTTP PATCH method.</summary>
    Patch
}

/// <summary>
/// Represents the autocomplete attribute for HTML input elements.
/// </summary>
public enum AutoComplete
{
    /// <summary>Autocomplete is enabled.</summary>
    On,
    /// <summary>Autocomplete is disabled.</summary>
    Off
}

/// <summary>
/// Represents the loading attribute for HTML img elements.
/// </summary>
public enum Loading
{
    /// <summary>Deferred loading until near the viewport.</summary>
    Lazy,
    /// <summary>Load immediately regardless of viewport.</summary>
    Eager
}

/// <summary>
/// Represents the referrerpolicy attribute for HTML anchor and iframe elements.
/// </summary>
public enum ReferrerPolicy
{
    /// <summary>No referrer header is sent.</summary>
    NoReferrer,
    /// <summary>Sends full referrer for same-origin, nothing for downgrade.</summary>
    NoReferrerWhenDowngrade,
    /// <summary>Only sends the origin, not the full URL.</summary>
    Origin,
    /// <summary>Sends origin for same-origin, full URL for cross-origin.</summary>
    OriginWhenCrossOrigin,
    /// <summary>Referrer only sent for same-origin requests.</summary>
    SameOrigin,
    /// <summary>Sends origin for cross-origin, origin+path for same-origin.</summary>
    StrictOrigin,
    /// <summary>Sends origin for cross-origin, full URL for same-origin.</summary>
    StrictOriginWhenCrossOrigin,
    /// <summary>Always sends the full URL as referrer.</summary>
    UnsafeUrl
}
