using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap modal dialog component for overlaying content on top of the current page.
/// </summary>
public sealed class ModalComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModalComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the modal.</param>
    public ModalComponent(params Node[] children) : base(children) { SetTag("div"); Class("modal"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ModalComponent"/> class.
    /// </summary>
    public ModalComponent() { SetTag("div"); Class("modal"); }

    /// <summary>
    /// Applies the fade animation transition.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent Fade() => (ModalComponent)Class("fade");

    /// <summary>
    /// Makes the modal visible by applying the show class.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent Show() => (ModalComponent)Class("show");

    /// <summary>
    /// Uses a static backdrop that cannot be dismissed by clicking outside the modal.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent StaticBackdrop() => (ModalComponent)Class("modal-static");

    /// <summary>
    /// Makes the modal body scrollable when content overflows.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent Scrollable() => (ModalComponent)Class("modal-dialog-scrollable");

    /// <summary>
    /// Vertically centers the modal dialog.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent Centered() => (ModalComponent)Class("modal-dialog-centered");

    /// <summary>
    /// Makes the modal fullscreen on all viewport sizes.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent Fullscreen() => (ModalComponent)Class("modal-fullscreen");

    /// <summary>
    /// Makes the modal fullscreen below the small breakpoint.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent FullscreenSm() => (ModalComponent)Class("modal-fullscreen-sm-down");

    /// <summary>
    /// Makes the modal fullscreen below the medium breakpoint.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent FullscreenMd() => (ModalComponent)Class("modal-fullscreen-md-down");

    /// <summary>
    /// Makes the modal fullscreen below the large breakpoint.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent FullscreenLg() => (ModalComponent)Class("modal-fullscreen-lg-down");

    /// <summary>
    /// Makes the modal fullscreen below the extra-large breakpoint.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent FullscreenXl() => (ModalComponent)Class("modal-fullscreen-xl-down");

    /// <summary>
    /// Makes the modal fullscreen below the double extra-large breakpoint.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent FullscreenXxl() => (ModalComponent)Class("modal-fullscreen-xxl-down");

    /// <summary>
    /// Applies the small modal size.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent SizeSm() => (ModalComponent)Class("modal-sm");

    /// <summary>
    /// Applies the large modal size.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent SizeLg() => (ModalComponent)Class("modal-lg");

    /// <summary>
    /// Applies the extra-large modal size.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent SizeXl() => (ModalComponent)Class("modal-xl");

    /// <summary>
    /// Applies the double extra-large modal size.
    /// </summary>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent SizeXxl() => (ModalComponent)Class("modal-xxl");

    /// <summary>
    /// Configures the modal to be toggled by a trigger element targeting the specified modal ID.
    /// </summary>
    /// <param name="id">The ID of the modal to toggle.</param>
    /// <returns>The current <see cref="ModalComponent"/> instance.</returns>
    public ModalComponent Toggle(string id) { Data("bs-toggle", "modal"); Data("bs-target", $"#{id}"); return this; }
}

/// <summary>
/// A Bootstrap modal dialog component that wraps the modal content.
/// </summary>
public sealed class ModalDialogComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModalDialogComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the modal dialog.</param>
    public ModalDialogComponent(params Node[] children) : base(children) { SetTag("div"); Class("modal-dialog"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ModalDialogComponent"/> class.
    /// </summary>
    public ModalDialogComponent() { SetTag("div"); Class("modal-dialog"); }
}

/// <summary>
/// A Bootstrap modal content component containing the header, body, and footer.
/// </summary>
public sealed class ModalContentComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModalContentComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the modal content.</param>
    public ModalContentComponent(params Node[] children) : base(children) { SetTag("div"); Class("modal-content"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ModalContentComponent"/> class.
    /// </summary>
    public ModalContentComponent() { SetTag("div"); Class("modal-content"); }
}

/// <summary>
/// A Bootstrap modal header component containing the title and close button.
/// </summary>
public sealed class ModalHeaderComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModalHeaderComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the modal header.</param>
    public ModalHeaderComponent(params Node[] children) : base(children) { SetTag("div"); Class("modal-header"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ModalHeaderComponent"/> class.
    /// </summary>
    public ModalHeaderComponent() { SetTag("div"); Class("modal-header"); }
}

/// <summary>
/// A Bootstrap modal title component displayed in the modal header.
/// </summary>
public sealed class ModalTitleComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModalTitleComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the modal title.</param>
    public ModalTitleComponent(params Node[] children) : base(children) => SetTag("h5");

    /// <summary>
    /// Initializes a new instance of the <see cref="ModalTitleComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the modal title.</param>
    public ModalTitleComponent(string textContent) : base(textContent) => SetTag("h5");

    /// <summary>
    /// Initializes a new instance of the <see cref="ModalTitleComponent"/> class.
    /// </summary>
    public ModalTitleComponent() => SetTag("h5");
}

/// <summary>
/// A Bootstrap modal body component containing the primary content of the modal.
/// </summary>
public sealed class ModalBodyComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModalBodyComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the modal body.</param>
    public ModalBodyComponent(params Node[] children) : base(children) { SetTag("div"); Class("modal-body"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ModalBodyComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the modal body.</param>
    public ModalBodyComponent(string textContent) : base(textContent) { SetTag("div"); Class("modal-body"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ModalBodyComponent"/> class.
    /// </summary>
    public ModalBodyComponent() { SetTag("div"); Class("modal-body"); }
}

/// <summary>
/// A Bootstrap modal footer component typically containing action buttons.
/// </summary>
public sealed class ModalFooterComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModalFooterComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the modal footer.</param>
    public ModalFooterComponent(params Node[] children) : base(children) { SetTag("div"); Class("modal-footer"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="ModalFooterComponent"/> class.
    /// </summary>
    public ModalFooterComponent() { SetTag("div"); Class("modal-footer"); }
}

/// <summary>
/// A Bootstrap modal close button component for dismissing the modal.
/// </summary>
public sealed class ModalCloseButtonComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModalCloseButtonComponent"/> class.
    /// </summary>
    public ModalCloseButtonComponent() { SetTag("button"); Class("btn-close"); Attributes.Set("type", "button"); }

    /// <summary>
    /// Sets the aria-label attribute for the close button to provide an accessible label.
    /// </summary>
    /// <param name="label">The aria-label text for the close button.</param>
    /// <returns>The current <see cref="ModalCloseButtonComponent"/> instance.</returns>
    public ModalCloseButtonComponent DismissLabel(string label) { Attributes.Set("aria-label", label); return this; }
}

/// <summary>
/// Extension methods for creating Bootstrap modal components.
/// </summary>
public static class ModalExtensions
{
    /// <summary>
    /// Creates a new <see cref="ModalComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="ModalComponent"/> instance.</returns>
    public static ModalComponent Modal(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="ModalComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ModalComponent"/> instance.</returns>
    public static ModalComponent Modal() => new();

    /// <summary>
    /// Creates a new <see cref="ModalDialogComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="ModalDialogComponent"/> instance.</returns>
    public static ModalDialogComponent ModalDialog(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="ModalDialogComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ModalDialogComponent"/> instance.</returns>
    public static ModalDialogComponent ModalDialog() => new();

    /// <summary>
    /// Creates a new <see cref="ModalContentComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="ModalContentComponent"/> instance.</returns>
    public static ModalContentComponent ModalContent(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="ModalContentComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ModalContentComponent"/> instance.</returns>
    public static ModalContentComponent ModalContent() => new();

    /// <summary>
    /// Creates a new <see cref="ModalHeaderComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="ModalHeaderComponent"/> instance.</returns>
    public static ModalHeaderComponent ModalHeader(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="ModalHeaderComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ModalHeaderComponent"/> instance.</returns>
    public static ModalHeaderComponent ModalHeader() => new();

    /// <summary>
    /// Creates a new <see cref="ModalTitleComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="ModalTitleComponent"/> instance.</returns>
    public static ModalTitleComponent ModalTitle(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="ModalTitleComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the modal title.</param>
    /// <returns>A new <see cref="ModalTitleComponent"/> instance.</returns>
    public static ModalTitleComponent ModalTitle(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="ModalTitleComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ModalTitleComponent"/> instance.</returns>
    public static ModalTitleComponent ModalTitle() => new();

    /// <summary>
    /// Creates a new <see cref="ModalBodyComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="ModalBodyComponent"/> instance.</returns>
    public static ModalBodyComponent ModalBody(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="ModalBodyComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the modal body.</param>
    /// <returns>A new <see cref="ModalBodyComponent"/> instance.</returns>
    public static ModalBodyComponent ModalBody(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="ModalBodyComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ModalBodyComponent"/> instance.</returns>
    public static ModalBodyComponent ModalBody() => new();

    /// <summary>
    /// Creates a new <see cref="ModalFooterComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="ModalFooterComponent"/> instance.</returns>
    public static ModalFooterComponent ModalFooter(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="ModalFooterComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ModalFooterComponent"/> instance.</returns>
    public static ModalFooterComponent ModalFooter() => new();

    /// <summary>
    /// Creates a new <see cref="ModalCloseButtonComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="ModalCloseButtonComponent"/> instance.</returns>
    public static ModalCloseButtonComponent ModalCloseButton() => new();
}
