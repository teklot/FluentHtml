using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap alert component for displaying contextual feedback messages.
/// </summary>
public sealed class AlertComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AlertComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the alert.</param>
    public AlertComponent(params Node[] children) : base(children) { SetTag("div"); Class("alert"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="AlertComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the alert.</param>
    public AlertComponent(string textContent) : base(textContent) { SetTag("div"); Class("alert"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="AlertComponent"/> class.
    /// </summary>
    public AlertComponent() { SetTag("div"); Class("alert"); }

    /// <summary>
    /// Applies the primary alert style.
    /// </summary>
    /// <returns>The current <see cref="AlertComponent"/> instance.</returns>
    public AlertComponent Primary() => (AlertComponent)Class("alert-primary");

    /// <summary>
    /// Applies the secondary alert style.
    /// </summary>
    /// <returns>The current <see cref="AlertComponent"/> instance.</returns>
    public AlertComponent Secondary() => (AlertComponent)Class("alert-secondary");

    /// <summary>
    /// Applies the success alert style.
    /// </summary>
    /// <returns>The current <see cref="AlertComponent"/> instance.</returns>
    public AlertComponent Success() => (AlertComponent)Class("alert-success");

    /// <summary>
    /// Applies the danger alert style.
    /// </summary>
    /// <returns>The current <see cref="AlertComponent"/> instance.</returns>
    public AlertComponent Danger() => (AlertComponent)Class("alert-danger");

    /// <summary>
    /// Applies the warning alert style.
    /// </summary>
    /// <returns>The current <see cref="AlertComponent"/> instance.</returns>
    public AlertComponent Warning() => (AlertComponent)Class("alert-warning");

    /// <summary>
    /// Applies the info alert style.
    /// </summary>
    /// <returns>The current <see cref="AlertComponent"/> instance.</returns>
    public AlertComponent Info() => (AlertComponent)Class("alert-info");

    /// <summary>
    /// Applies the light alert style.
    /// </summary>
    /// <returns>The current <see cref="AlertComponent"/> instance.</returns>
    public AlertComponent Light() => (AlertComponent)Class("alert-light");

    /// <summary>
    /// Applies the dark alert style.
    /// </summary>
    /// <returns>The current <see cref="AlertComponent"/> instance.</returns>
    public AlertComponent Dark() => (AlertComponent)Class("alert-dark");

    /// <summary>
    /// Makes the alert dismissible with a close button.
    /// </summary>
    /// <returns>The current <see cref="AlertComponent"/> instance.</returns>
    public AlertComponent Dismissible() => (AlertComponent)Class("alert-dismissible");

    /// <summary>
    /// Applies the fade animation transition.
    /// </summary>
    /// <returns>The current <see cref="AlertComponent"/> instance.</returns>
    public AlertComponent Fade() => (AlertComponent)Class("fade");

    /// <summary>
    /// Makes the alert visible by applying the show class.
    /// </summary>
    /// <returns>The current <see cref="AlertComponent"/> instance.</returns>
    public AlertComponent Show() => (AlertComponent)Class("show");
}

/// <summary>
/// Extension methods for creating Bootstrap alert components.
/// </summary>
public static class AlertExtensions
{
    /// <summary>
    /// Creates a new <see cref="AlertComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the alert.</param>
    /// <returns>A new <see cref="AlertComponent"/> instance.</returns>
    public static AlertComponent Alert(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="AlertComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the alert.</param>
    /// <returns>A new <see cref="AlertComponent"/> instance.</returns>
    public static AlertComponent Alert(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="AlertComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="AlertComponent"/> instance.</returns>
    public static AlertComponent Alert() => new();
}
