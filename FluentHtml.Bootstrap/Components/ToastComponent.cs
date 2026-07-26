using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap toast component for displaying lightweight notifications.
/// </summary>
public sealed class ToastComponent : Element<ToastComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ToastComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the toast.</param>
    public ToastComponent(params Node[] children) : base(children) { SetTag("div"); Class("toast"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ToastComponent"/> class.
    /// </summary>
    public ToastComponent() { SetTag("div"); Class("toast"); }

    /// <summary>
    /// Makes the toast visible by applying the show class.
    /// </summary>
    /// <returns>The current <see cref="ToastComponent"/> instance.</returns>
    public ToastComponent Show() => Class("show");

    /// <summary>
    /// Applies the fade animation transition.
    /// </summary>
    /// <returns>The current <see cref="ToastComponent"/> instance.</returns>
    public ToastComponent Fade() => Class("fade");

    /// <summary>
    /// Enables the toast to automatically hide after the specified delay.
    /// </summary>
    /// <returns>The current <see cref="ToastComponent"/> instance.</returns>
    public ToastComponent Autohide() => Class("autohide");

    /// <summary>
    /// Sets the delay in milliseconds before the toast automatically hides.
    /// </summary>
    /// <param name="milliseconds">The delay in milliseconds.</param>
    /// <returns>The current <see cref="ToastComponent"/> instance.</returns>
    public ToastComponent Delay(int milliseconds) => Data("bs-delay", milliseconds.ToString());
}

/// <summary>
/// A Bootstrap toast header component containing the toast title and close button.
/// </summary>
public sealed class ToastHeaderComponent : Element<ToastHeaderComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ToastHeaderComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the toast header.</param>
    public ToastHeaderComponent(params Node[] children) : base(children) { SetTag("div"); Class("toast-header"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ToastHeaderComponent"/> class.
    /// </summary>
    public ToastHeaderComponent() { SetTag("div"); Class("toast-header"); }
}

/// <summary>
/// A Bootstrap toast body component containing the primary content of the toast.
/// </summary>
public sealed class ToastBodyComponent : Element<ToastBodyComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ToastBodyComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the toast body.</param>
    public ToastBodyComponent(params Node[] children) : base(children) { SetTag("div"); Class("toast-body"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ToastBodyComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the toast body.</param>
    public ToastBodyComponent(string textContent) : base(textContent) { SetTag("div"); Class("toast-body"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ToastBodyComponent"/> class.
    /// </summary>
    public ToastBodyComponent() { SetTag("div"); Class("toast-body"); }
}

/// <summary>
/// A Bootstrap toast close button component for dismissing the toast.
/// </summary>
public sealed class ToastCloseButtonComponent : Element<ToastCloseButtonComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ToastCloseButtonComponent"/> class.
    /// </summary>
    public ToastCloseButtonComponent() { SetTag("button"); Class("btn-close"); Attributes.Set("type", "button"); }

    /// <summary>
    /// Sets the aria-label attribute for the close button to provide an accessible label.
    /// </summary>
    /// <param name="label">The aria-label text for the close button.</param>
    /// <returns>The current <see cref="ToastCloseButtonComponent"/> instance.</returns>
    public ToastCloseButtonComponent DismissLabel(string label) { Attributes.Set("aria-label", label); return this; }
}

/// <summary>
/// A Bootstrap toast container component for positioning and managing multiple toasts.
/// </summary>
public sealed class ToastContainerComponent : Element<ToastContainerComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ToastContainerComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the toast container.</param>
    public ToastContainerComponent(params Node[] children) : base(children) { SetTag("div"); Class("toast-container"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ToastContainerComponent"/> class.
    /// </summary>
    public ToastContainerComponent() { SetTag("div"); Class("toast-container"); }

    /// <summary>
    /// Positions the toast container at the top-left corner.
    /// </summary>
    /// <returns>The current <see cref="ToastContainerComponent"/> instance.</returns>
    public ToastContainerComponent PositionTopStart() => Class("toast-top-start");

    /// <summary>
    /// Positions the toast container at the top-center.
    /// </summary>
    /// <returns>The current <see cref="ToastContainerComponent"/> instance.</returns>
    public ToastContainerComponent PositionTopCenter() => Class("toast-top-center");

    /// <summary>
    /// Positions the toast container at the top-right corner.
    /// </summary>
    /// <returns>The current <see cref="ToastContainerComponent"/> instance.</returns>
    public ToastContainerComponent PositionTopEnd() => Class("toast-top-end");

    /// <summary>
    /// Positions the toast container at the middle-left.
    /// </summary>
    /// <returns>The current <see cref="ToastContainerComponent"/> instance.</returns>
    public ToastContainerComponent PositionMiddleStart() => Class("toast-middle-start");

    /// <summary>
    /// Positions the toast container at the middle-center.
    /// </summary>
    /// <returns>The current <see cref="ToastContainerComponent"/> instance.</returns>
    public ToastContainerComponent PositionMiddleCenter() => Class("toast-middle-center");

    /// <summary>
    /// Positions the toast container at the middle-right.
    /// </summary>
    /// <returns>The current <see cref="ToastContainerComponent"/> instance.</returns>
    public ToastContainerComponent PositionMiddleEnd() => Class("toast-middle-end");

    /// <summary>
    /// Positions the toast container at the bottom-left corner.
    /// </summary>
    /// <returns>The current <see cref="ToastContainerComponent"/> instance.</returns>
    public ToastContainerComponent PositionBottomStart() => Class("toast-bottom-start");

    /// <summary>
    /// Positions the toast container at the bottom-center.
    /// </summary>
    /// <returns>The current <see cref="ToastContainerComponent"/> instance.</returns>
    public ToastContainerComponent PositionBottomCenter() => Class("toast-bottom-center");

    /// <summary>
    /// Positions the toast container at the bottom-right corner.
    /// </summary>
    /// <returns>The current <see cref="ToastContainerComponent"/> instance.</returns>
    public ToastContainerComponent PositionBottomEnd() => Class("toast-bottom-end");
}

/// <summary>
/// Extension methods for creating Bootstrap toast components.
/// </summary>
public static class ToastExtensions
{
    /// <summary>
    /// Creates a new <see cref="ToastComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="ToastComponent"/> instance.</returns>
    public static ToastComponent Toast(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="ToastComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ToastComponent"/> instance.</returns>
    public static ToastComponent Toast() => new();

    /// <summary>
    /// Creates a new <see cref="ToastHeaderComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="ToastHeaderComponent"/> instance.</returns>
    public static ToastHeaderComponent ToastHeader(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="ToastHeaderComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ToastHeaderComponent"/> instance.</returns>
    public static ToastHeaderComponent ToastHeader() => new();

    /// <summary>
    /// Creates a new <see cref="ToastBodyComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="ToastBodyComponent"/> instance.</returns>
    public static ToastBodyComponent ToastBody(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="ToastBodyComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the toast body.</param>
    /// <returns>A new <see cref="ToastBodyComponent"/> instance.</returns>
    public static ToastBodyComponent ToastBody(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="ToastBodyComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ToastBodyComponent"/> instance.</returns>
    public static ToastBodyComponent ToastBody() => new();

    /// <summary>
    /// Creates a new <see cref="ToastCloseButtonComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ToastCloseButtonComponent"/> instance.</returns>
    public static ToastCloseButtonComponent ToastCloseButton() => new();

    /// <summary>
    /// Creates a new <see cref="ToastContainerComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="ToastContainerComponent"/> instance.</returns>
    public static ToastContainerComponent ToastContainer(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="ToastContainerComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ToastContainerComponent"/> instance.</returns>
    public static ToastContainerComponent ToastContainer() => new();
}
