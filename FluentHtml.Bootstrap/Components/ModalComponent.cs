using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

public sealed class ModalComponent : Element
{
    public ModalComponent(params Node[] children) : base(children) { SetTag("div"); Class("modal"); }

    public ModalComponent() { SetTag("div"); Class("modal"); }

    public ModalComponent Fade() => (ModalComponent)Class("fade");

    public ModalComponent Show() => (ModalComponent)Class("show");

    public ModalComponent StaticBackdrop() => (ModalComponent)Class("modal-static");

    public ModalComponent Scrollable() => (ModalComponent)Class("modal-dialog-scrollable");

    public ModalComponent Centered() => (ModalComponent)Class("modal-dialog-centered");

    public ModalComponent Fullscreen() => (ModalComponent)Class("modal-fullscreen");

    public ModalComponent FullscreenSm() => (ModalComponent)Class("modal-fullscreen-sm-down");

    public ModalComponent FullscreenMd() => (ModalComponent)Class("modal-fullscreen-md-down");

    public ModalComponent FullscreenLg() => (ModalComponent)Class("modal-fullscreen-lg-down");

    public ModalComponent FullscreenXl() => (ModalComponent)Class("modal-fullscreen-xl-down");

    public ModalComponent FullscreenXxl() => (ModalComponent)Class("modal-fullscreen-xxl-down");

    public ModalComponent SizeSm() => (ModalComponent)Class("modal-sm");

    public ModalComponent SizeLg() => (ModalComponent)Class("modal-lg");

    public ModalComponent SizeXl() => (ModalComponent)Class("modal-xl");

    public ModalComponent SizeXxl() => (ModalComponent)Class("modal-xxl");

    public ModalComponent Toggle(string id) { Data("bs-toggle", "modal"); Data("bs-target", $"#{id}"); return this; }
}

public sealed class ModalDialogComponent : Element
{
    public ModalDialogComponent(params Node[] children) : base(children) { SetTag("div"); Class("modal-dialog"); }

    public ModalDialogComponent() { SetTag("div"); Class("modal-dialog"); }
}

public sealed class ModalContentComponent : Element
{
    public ModalContentComponent(params Node[] children) : base(children) { SetTag("div"); Class("modal-content"); }

    public ModalContentComponent() { SetTag("div"); Class("modal-content"); }
}

public sealed class ModalHeaderComponent : Element
{
    public ModalHeaderComponent(params Node[] children) : base(children) { SetTag("div"); Class("modal-header"); }

    public ModalHeaderComponent() { SetTag("div"); Class("modal-header"); }
}

public sealed class ModalTitleComponent : Element
{
    public ModalTitleComponent(params Node[] children) : base(children) => SetTag("h5");

    public ModalTitleComponent(string textContent) : base(textContent) => SetTag("h5");

    public ModalTitleComponent() => SetTag("h5");
}

public sealed class ModalBodyComponent : Element
{
    public ModalBodyComponent(params Node[] children) : base(children) { SetTag("div"); Class("modal-body"); }

    public ModalBodyComponent(string textContent) : base(textContent) { SetTag("div"); Class("modal-body"); }

    public ModalBodyComponent() { SetTag("div"); Class("modal-body"); }
}

public sealed class ModalFooterComponent : Element
{
    public ModalFooterComponent(params Node[] children) : base(children) { SetTag("div"); Class("modal-footer"); }

    public ModalFooterComponent() { SetTag("div"); Class("modal-footer"); }
}

public sealed class ModalCloseButtonComponent : Element
{
    public ModalCloseButtonComponent() { SetTag("button"); Class("btn-close"); Attributes.Set("type", "button"); }

    public ModalCloseButtonComponent DismissLabel(string label) { Attributes.Set("aria-label", label); return this; }
}

public static class ModalExtensions
{
    public static ModalComponent Modal(params Node[] children) => new(children);

    public static ModalComponent Modal() => new();

    public static ModalDialogComponent ModalDialog(params Node[] children) => new(children);

    public static ModalDialogComponent ModalDialog() => new();

    public static ModalContentComponent ModalContent(params Node[] children) => new(children);

    public static ModalContentComponent ModalContent() => new();

    public static ModalHeaderComponent ModalHeader(params Node[] children) => new(children);

    public static ModalHeaderComponent ModalHeader() => new();

    public static ModalTitleComponent ModalTitle(params Node[] children) => new(children);

    public static ModalTitleComponent ModalTitle(string textContent) => new(textContent);

    public static ModalTitleComponent ModalTitle() => new();

    public static ModalBodyComponent ModalBody(params Node[] children) => new(children);

    public static ModalBodyComponent ModalBody(string textContent) => new(textContent);

    public static ModalBodyComponent ModalBody() => new();

    public static ModalFooterComponent ModalFooter(params Node[] children) => new(children);

    public static ModalFooterComponent ModalFooter() => new();

    public static ModalCloseButtonComponent ModalCloseButton() => new();
}
