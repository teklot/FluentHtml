using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap progress bar component for displaying completion progress.
/// </summary>
public sealed class ProgressBarComponent : Element<ProgressBarComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressBarComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the progress bar.</param>
    public ProgressBarComponent(params Node[] children) : base(children) { SetTag("div"); Class("progress"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressBarComponent"/> class.
    /// </summary>
    public ProgressBarComponent() { SetTag("div"); Class("progress"); }

    /// <summary>
    /// Sets a fixed height on the progress bar.
    /// </summary>
    /// <param name="height">The height value (e.g., "20px").</param>
    /// <returns>The current <see cref="ProgressBarComponent"/> instance.</returns>
    public ProgressBarComponent Height(string height) { Attributes.Set("style", $"height:{height}"); return this; }
}

/// <summary>
/// A Bootstrap progress bar inner component representing a single progress fill.
/// </summary>
public sealed class ProgressBarFillComponent : Element<ProgressBarFillComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressBarFillComponent"/> class.
    /// </summary>
    public ProgressBarFillComponent() { SetTag("div"); Class("progress-bar"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressBarFillComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    public ProgressBarFillComponent(params Node[] children) : base(children) { SetTag("div"); Class("progress-bar"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProgressBarFillComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content to display inside the progress bar.</param>
    public ProgressBarFillComponent(string textContent) : base(textContent) { SetTag("div"); Class("progress-bar"); }

    /// <summary>
    /// Sets the width percentage of the progress bar.
    /// </summary>
    /// <param name="percent">The width percentage (0-100).</param>
    /// <returns>The current <see cref="ProgressBarFillComponent"/> instance.</returns>
    public ProgressBarFillComponent Width(double percent) => Class($"w-{percent}");

    /// <summary>
    /// Applies the primary color style.
    /// </summary>
    /// <returns>The current <see cref="ProgressBarFillComponent"/> instance.</returns>
    public ProgressBarFillComponent Primary() => Class("bg-primary");

    /// <summary>
    /// Applies the secondary color style.
    /// </summary>
    /// <returns>The current <see cref="ProgressBarFillComponent"/> instance.</returns>
    public ProgressBarFillComponent Secondary() => Class("bg-secondary");

    /// <summary>
    /// Applies the success color style.
    /// </summary>
    /// <returns>The current <see cref="ProgressBarFillComponent"/> instance.</returns>
    public ProgressBarFillComponent Success() => Class("bg-success");

    /// <summary>
    /// Applies the danger color style.
    /// </summary>
    /// <returns>The current <see cref="ProgressBarFillComponent"/> instance.</returns>
    public ProgressBarFillComponent Danger() => Class("bg-danger");

    /// <summary>
    /// Applies the warning color style.
    /// </summary>
    /// <returns>The current <see cref="ProgressBarFillComponent"/> instance.</returns>
    public ProgressBarFillComponent Warning() => Class("bg-warning");

    /// <summary>
    /// Applies the info color style.
    /// </summary>
    /// <returns>The current <see cref="ProgressBarFillComponent"/> instance.</returns>
    public ProgressBarFillComponent Info() => Class("bg-info");

    /// <summary>
    /// Applies the light color style.
    /// </summary>
    /// <returns>The current <see cref="ProgressBarFillComponent"/> instance.</returns>
    public ProgressBarFillComponent Light() => Class("bg-light");

    /// <summary>
    /// Applies the dark color style.
    /// </summary>
    /// <returns>The current <see cref="ProgressBarFillComponent"/> instance.</returns>
    public ProgressBarFillComponent Dark() => Class("bg-dark");

    /// <summary>
    /// Adds a striped pattern to the progress bar.
    /// </summary>
    /// <returns>The current <see cref="ProgressBarFillComponent"/> instance.</returns>
    public ProgressBarFillComponent Striped() => Class("progress-bar-striped");

    /// <summary>
    /// Adds an animated stripe pattern to the progress bar.
    /// </summary>
    /// <returns>The current <see cref="ProgressBarFillComponent"/> instance.</returns>
    public ProgressBarFillComponent Animated() => Class("progress-bar-animated");
}

/// <summary>
/// Extension methods for creating Bootstrap progress bar components.
/// </summary>
public static class ProgressBarExtensions
{
    /// <summary>
    /// Creates a new <see cref="ProgressBarComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="ProgressBarComponent"/> instance.</returns>
    public static ProgressBarComponent ProgressBar(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="ProgressBarComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ProgressBarComponent"/> instance.</returns>
    public static ProgressBarComponent ProgressBar() => new();

    /// <summary>
    /// Creates a new <see cref="ProgressBarFillComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="ProgressBarFillComponent"/> instance.</returns>
    public static ProgressBarFillComponent ProgressBarFill(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="ProgressBarFillComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content to display inside the progress bar.</param>
    /// <returns>A new <see cref="ProgressBarFillComponent"/> instance.</returns>
    public static ProgressBarFillComponent ProgressBarFill(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="ProgressBarFillComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ProgressBarFillComponent"/> instance.</returns>
    public static ProgressBarFillComponent ProgressBarFill() => new();
}
