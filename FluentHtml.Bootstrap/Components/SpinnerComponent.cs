using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap spinner component displayed as a rotating border animation for indicating loading state.
/// </summary>
public sealed class SpinnerComponent : Element<SpinnerComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpinnerComponent"/> class.
    /// </summary>
    public SpinnerComponent() { SetTag("div"); Class("spinner-border"); }

    /// <summary>
    /// Applies the primary text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerComponent"/> instance.</returns>
    public SpinnerComponent Primary() => Class("text-primary");

    /// <summary>
    /// Applies the secondary text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerComponent"/> instance.</returns>
    public SpinnerComponent Secondary() => Class("text-secondary");

    /// <summary>
    /// Applies the success text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerComponent"/> instance.</returns>
    public SpinnerComponent Success() => Class("text-success");

    /// <summary>
    /// Applies the danger text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerComponent"/> instance.</returns>
    public SpinnerComponent Danger() => Class("text-danger");

    /// <summary>
    /// Applies the warning text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerComponent"/> instance.</returns>
    public SpinnerComponent Warning() => Class("text-warning");

    /// <summary>
    /// Applies the info text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerComponent"/> instance.</returns>
    public SpinnerComponent Info() => Class("text-info");

    /// <summary>
    /// Applies the light text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerComponent"/> instance.</returns>
    public SpinnerComponent Light() => Class("text-light");

    /// <summary>
    /// Applies the dark text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerComponent"/> instance.</returns>
    public SpinnerComponent Dark() => Class("text-dark");

    /// <summary>
    /// Applies the small spinner size.
    /// </summary>
    /// <returns>The current <see cref="SpinnerComponent"/> instance.</returns>
    public SpinnerComponent Small() => Class("spinner-border-sm");

    /// <summary>
    /// Sets the role attribute for accessibility.
    /// </summary>
    /// <param name="role">The ARIA role value (e.g., "status").</param>
    /// <returns>The current <see cref="SpinnerComponent"/> instance.</returns>
    public new SpinnerComponent Role(string role) { Attributes.Set("role", role); return this; }
}

/// <summary>
/// A Bootstrap spinner grow component displayed as a pulsing animation for indicating loading state.
/// </summary>
public sealed class SpinnerGrowComponent : Element<SpinnerGrowComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpinnerGrowComponent"/> class.
    /// </summary>
    public SpinnerGrowComponent() { SetTag("div"); Class("spinner-grow"); }

    /// <summary>
    /// Applies the primary text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerGrowComponent"/> instance.</returns>
    public SpinnerGrowComponent Primary() => Class("text-primary");

    /// <summary>
    /// Applies the secondary text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerGrowComponent"/> instance.</returns>
    public SpinnerGrowComponent Secondary() => Class("text-secondary");

    /// <summary>
    /// Applies the success text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerGrowComponent"/> instance.</returns>
    public SpinnerGrowComponent Success() => Class("text-success");

    /// <summary>
    /// Applies the danger text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerGrowComponent"/> instance.</returns>
    public SpinnerGrowComponent Danger() => Class("text-danger");

    /// <summary>
    /// Applies the warning text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerGrowComponent"/> instance.</returns>
    public SpinnerGrowComponent Warning() => Class("text-warning");

    /// <summary>
    /// Applies the info text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerGrowComponent"/> instance.</returns>
    public SpinnerGrowComponent Info() => Class("text-info");

    /// <summary>
    /// Applies the light text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerGrowComponent"/> instance.</returns>
    public SpinnerGrowComponent Light() => Class("text-light");

    /// <summary>
    /// Applies the dark text color.
    /// </summary>
    /// <returns>The current <see cref="SpinnerGrowComponent"/> instance.</returns>
    public SpinnerGrowComponent Dark() => Class("text-dark");

    /// <summary>
    /// Applies the small spinner grow size.
    /// </summary>
    /// <returns>The current <see cref="SpinnerGrowComponent"/> instance.</returns>
    public SpinnerGrowComponent Small() => Class("spinner-grow-sm");
}

/// <summary>
/// A Bootstrap spinner visibility component that wraps content with a small inline spinner for loading indicators.
/// </summary>
public sealed class SpinnerVisibilityComponent : Element<SpinnerVisibilityComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpinnerVisibilityComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include alongside the spinner.</param>
    public SpinnerVisibilityComponent(params Node[] children) : base(children) { SetTag("div"); Class("spinner-border spinner-border-sm"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpinnerVisibilityComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content to display alongside the spinner.</param>
    public SpinnerVisibilityComponent(string textContent) : base(textContent) { SetTag("div"); Class("spinner-border spinner-border-sm"); }
}

/// <summary>
/// Extension methods for creating Bootstrap spinner components.
/// </summary>
public static class SpinnerExtensions
{
    /// <summary>
    /// Creates a new <see cref="SpinnerComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="SpinnerComponent"/> instance.</returns>
    public static SpinnerComponent Spinner() => new();

    /// <summary>
    /// Creates a new <see cref="SpinnerGrowComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="SpinnerGrowComponent"/> instance.</returns>
    public static SpinnerGrowComponent SpinnerGrow() => new();

    /// <summary>
    /// Creates a new <see cref="SpinnerVisibilityComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include alongside the spinner.</param>
    /// <returns>A new <see cref="SpinnerVisibilityComponent"/> instance.</returns>
    public static SpinnerVisibilityComponent SpinnerVisibility(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="SpinnerVisibilityComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content to display alongside the spinner.</param>
    /// <returns>A new <see cref="SpinnerVisibilityComponent"/> instance.</returns>
    public static SpinnerVisibilityComponent SpinnerVisibility(string textContent) => new(textContent);
}
