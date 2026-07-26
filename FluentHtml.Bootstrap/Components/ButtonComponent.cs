using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap button component with built-in styling and HTMX support.
/// </summary>
public sealed class ButtonComponent : Element<ButtonComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public ButtonComponent(params Node[] children) : base(children) { SetTag("button"); Class("btn"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The button text.</param>
    public ButtonComponent(string textContent) : base(textContent) { SetTag("button"); Class("btn"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonComponent"/> class.
    /// </summary>
    public ButtonComponent() { SetTag("button"); Class("btn"); }

    /// <summary>
    /// Applies the Bootstrap primary button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent Primary() => Class("btn-primary");

    /// <summary>
    /// Applies the Bootstrap secondary button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent Secondary() => Class("btn-secondary");

    /// <summary>
    /// Applies the Bootstrap success button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent Success() => Class("btn-success");

    /// <summary>
    /// Applies the Bootstrap danger button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent Danger() => Class("btn-danger");

    /// <summary>
    /// Applies the Bootstrap warning button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent Warning() => Class("btn-warning");

    /// <summary>
    /// Applies the Bootstrap info button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent Info() => Class("btn-info");

    /// <summary>
    /// Applies the Bootstrap light button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent Light() => Class("btn-light");

    /// <summary>
    /// Applies the Bootstrap dark button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent Dark() => Class("btn-dark");

    /// <summary>
    /// Applies the Bootstrap link button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent Link() => Class("btn-link");

    /// <summary>
    /// Applies the Bootstrap outline primary button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent OutlinePrimary() => Class("btn-outline-primary");

    /// <summary>
    /// Applies the Bootstrap outline secondary button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent OutlineSecondary() => Class("btn-outline-secondary");

    /// <summary>
    /// Applies the Bootstrap outline success button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent OutlineSuccess() => Class("btn-outline-success");

    /// <summary>
    /// Applies the Bootstrap outline danger button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent OutlineDanger() => Class("btn-outline-danger");

    /// <summary>
    /// Applies the Bootstrap outline warning button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent OutlineWarning() => Class("btn-outline-warning");

    /// <summary>
    /// Applies the Bootstrap outline info button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent OutlineInfo() => Class("btn-outline-info");

    /// <summary>
    /// Applies the Bootstrap outline light button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent OutlineLight() => Class("btn-outline-light");

    /// <summary>
    /// Applies the Bootstrap outline dark button style.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent OutlineDark() => Class("btn-outline-dark");

    /// <summary>
    /// Applies the Bootstrap small button size.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent Small() => Class("btn-sm");

    /// <summary>
    /// Applies the Bootstrap large button size.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent Large() => Class("btn-lg");

    /// <summary>
    /// Sets the type attribute for this button.
    /// </summary>
    /// <param name="type">The button type (e.g., "submit", "button", "reset").</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent Type(string type) { Attributes.Set("type", type); return this; }

    /// <inheritdoc/>
    public new ButtonComponent Disabled() => (ButtonComponent)base.Disabled();

    /// <summary>
    /// Applies the Bootstrap active state to this button.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent Active() => Class("active");

    /// <summary>
    /// Makes this button full-width within its parent container.
    /// </summary>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent Block() => Class("d-grid");

    /// <summary>
    /// Sets the hx-get attribute to issue an HTMX GET request.
    /// </summary>
    /// <param name="url">The URL to request.</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent HxGet(string url) { Attributes.Set("hx-get", url); return this; }

    /// <summary>
    /// Sets the hx-post attribute to issue an HTMX POST request.
    /// </summary>
    /// <param name="url">The URL to request.</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent HxPost(string url) { Attributes.Set("hx-post", url); return this; }

    /// <summary>
    /// Sets the hx-put attribute to issue an HTMX PUT request.
    /// </summary>
    /// <param name="url">The URL to request.</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent HxPut(string url) { Attributes.Set("hx-put", url); return this; }

    /// <summary>
    /// Sets the hx-delete attribute to issue an HTMX DELETE request.
    /// </summary>
    /// <param name="url">The URL to request.</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent HxDelete(string url) { Attributes.Set("hx-delete", url); return this; }

    /// <summary>
    /// Sets the hx-patch attribute to issue an HTMX PATCH request.
    /// </summary>
    /// <param name="url">The URL to request.</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent HxPatch(string url) { Attributes.Set("hx-patch", url); return this; }

    /// <summary>
    /// Sets the hx-swap attribute to control how the response HTML is swapped into the DOM.
    /// </summary>
    /// <param name="swapStyle">The swap strategy (e.g., "innerHTML", "outerHTML").</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent HxSwap(string swapStyle) { Attributes.Set("hx-swap", swapStyle); return this; }

    /// <summary>
    /// Sets the hx-target attribute to specify which element should receive the response HTML.
    /// </summary>
    /// <param name="target">The CSS selector for the target element.</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent HxTarget(string target) { Attributes.Set("hx-target", target); return this; }

    /// <summary>
    /// Sets the hx-trigger attribute to specify when an HTMX request should be triggered.
    /// </summary>
    /// <param name="trigger">The trigger event (e.g., "click", "submit").</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent HxTrigger(string trigger) { Attributes.Set("hx-trigger", trigger); return this; }

    /// <summary>
    /// Sets the hx-confirm attribute to display a confirmation dialog before making a request.
    /// </summary>
    /// <param name="message">The confirmation message to display.</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent HxConfirm(string message) { Attributes.Set("hx-confirm", message); return this; }

    /// <summary>
    /// Sets the hx-indicator attribute to specify a CSS class for the loading state.
    /// </summary>
    /// <param name="indicator">The CSS class to apply during loading.</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent HxIndicator(string indicator) { Attributes.Set("hx-indicator", indicator); return this; }

    /// <summary>
    /// Sets the hx-boost attribute to enable or disable HTMX boost.
    /// </summary>
    /// <param name="boost">If true, enables boost; if false, disables it.</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent HxBoost(bool boost = true) { if (boost) Attributes.SetBool("hx-boost"); else Attributes.Remove("hx-boost"); return this; }

    /// <summary>
    /// Sets the hx-push-url attribute to push a new URL into the browser history.
    /// </summary>
    /// <param name="url">The URL to push to the history.</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent HxPushUrl(string url) { Attributes.Set("hx-push-url", url); return this; }

    /// <summary>
    /// Sets the hx-select attribute to select content from the response to swap.
    /// </summary>
    /// <param name="selector">The CSS selector to select from the response.</param>
    /// <returns>The current button for method chaining.</returns>
    public ButtonComponent HxSelect(string selector) { Attributes.Set("hx-select", selector); return this; }
}

/// <summary>
/// Factory methods for creating Bootstrap button components.
/// </summary>
public static class ButtonExtensions
{
    /// <summary>
    /// Creates a new Bootstrap button with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="ButtonComponent"/>.</returns>
    public static ButtonComponent Btn(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new Bootstrap button with the specified text content.
    /// </summary>
    /// <param name="textContent">The button text.</param>
    /// <returns>A new <see cref="ButtonComponent"/>.</returns>
    public static ButtonComponent Btn(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty Bootstrap button.
    /// </summary>
    /// <returns>A new <see cref="ButtonComponent"/>.</returns>
    public static ButtonComponent Btn() => new();
}