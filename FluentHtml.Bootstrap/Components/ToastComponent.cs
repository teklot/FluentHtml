using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

public sealed class ToastComponent : Element
{
    public ToastComponent(params Node[] children) : base(children) { SetTag("div"); Class("toast"); }

    public ToastComponent() { SetTag("div"); Class("toast"); }

    public ToastComponent Show() => (ToastComponent)Class("show");

    public ToastComponent Fade() => (ToastComponent)Class("fade");

    public ToastComponent Autohide() => (ToastComponent)Class("autohide");

    public ToastComponent Delay(int milliseconds) => (ToastComponent)Data("bs-delay", milliseconds.ToString());
}

public sealed class ToastHeaderComponent : Element
{
    public ToastHeaderComponent(params Node[] children) : base(children) { SetTag("div"); Class("toast-header"); }

    public ToastHeaderComponent() { SetTag("div"); Class("toast-header"); }
}

public sealed class ToastBodyComponent : Element
{
    public ToastBodyComponent(params Node[] children) : base(children) { SetTag("div"); Class("toast-body"); }

    public ToastBodyComponent(string textContent) : base(textContent) { SetTag("div"); Class("toast-body"); }

    public ToastBodyComponent() { SetTag("div"); Class("toast-body"); }
}

public sealed class ToastCloseButtonComponent : Element
{
    public ToastCloseButtonComponent() { SetTag("button"); Class("btn-close"); Attributes.Set("type", "button"); }

    public ToastCloseButtonComponent DismissLabel(string label) { Attributes.Set("aria-label", label); return this; }
}

public sealed class ToastContainerComponent : Element
{
    public ToastContainerComponent(params Node[] children) : base(children) { SetTag("div"); Class("toast-container"); }

    public ToastContainerComponent() { SetTag("div"); Class("toast-container"); }

    public ToastContainerComponent PositionTopStart() => (ToastContainerComponent)Class("toast-top-start");

    public ToastContainerComponent PositionTopCenter() => (ToastContainerComponent)Class("toast-top-center");

    public ToastContainerComponent PositionTopEnd() => (ToastContainerComponent)Class("toast-top-end");

    public ToastContainerComponent PositionMiddleStart() => (ToastContainerComponent)Class("toast-middle-start");

    public ToastContainerComponent PositionMiddleCenter() => (ToastContainerComponent)Class("toast-middle-center");

    public ToastContainerComponent PositionMiddleEnd() => (ToastContainerComponent)Class("toast-middle-end");

    public ToastContainerComponent PositionBottomStart() => (ToastContainerComponent)Class("toast-bottom-start");

    public ToastContainerComponent PositionBottomCenter() => (ToastContainerComponent)Class("toast-bottom-center");

    public ToastContainerComponent PositionBottomEnd() => (ToastContainerComponent)Class("toast-bottom-end");
}

public static class ToastExtensions
{
    public static ToastComponent Toast(params Node[] children) => new(children);

    public static ToastComponent Toast() => new();

    public static ToastHeaderComponent ToastHeader(params Node[] children) => new(children);

    public static ToastHeaderComponent ToastHeader() => new();

    public static ToastBodyComponent ToastBody(params Node[] children) => new(children);

    public static ToastBodyComponent ToastBody(string textContent) => new(textContent);

    public static ToastBodyComponent ToastBody() => new();

    public static ToastCloseButtonComponent ToastCloseButton() => new();

    public static ToastContainerComponent ToastContainer(params Node[] children) => new(children);

    public static ToastContainerComponent ToastContainer() => new();
}
