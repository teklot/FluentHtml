using FluentHtml.Components;
using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A reusable Bootstrap modal-based confirmation dialog that replaces the native browser
/// <c>confirm()</c> with a styled, customizable modal. A trigger button opens the dialog
/// using Bootstrap's <c>data-bs-toggle="modal"</c> mechanism (no custom JavaScript), and
/// the confirm button can be wired to an HTMX action (get/post/delete/put) or a plain URL.
/// </summary>
public sealed class ConfirmDialogComponent : Component
{
    private string _id = string.Empty;
    private string _title = "Are you sure?";
    private Node[] _message = System.Array.Empty<Node>();
    private string _confirmText = "Confirm";
    private string _confirmColor = "btn-primary";
    private string _cancelText = "Cancel";
    private string? _href;
    private string? _hxVerb;
    private string? _hxUrl;

    /// <summary>
    /// Sets the unique identifier of the dialog. Required for the trigger button to open it.
    /// </summary>
    /// <param name="id">The dialog id.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent Id(string id)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);
        _id = id;
        return this;
    }

    /// <summary>
    /// Sets the dialog title.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent Title(string title)
    {
        ArgumentNullException.ThrowIfNull(title);
        _title = title;
        return this;
    }

    /// <summary>
    /// Sets the dialog body message as plain text.
    /// </summary>
    /// <param name="message">The message text.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent Message(string message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _message = new Node[] { new TextNode(message) };
        return this;
    }

    /// <summary>
    /// Sets the dialog body message as child nodes, allowing rich content such as icons.
    /// </summary>
    /// <param name="message">The child nodes to display.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent Message(params Node[] message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _message = message;
        return this;
    }

    /// <summary>
    /// Sets the text of the confirm button.
    /// </summary>
    /// <param name="text">The confirm button text.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent ConfirmText(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        _confirmText = text;
        return this;
    }

    /// <summary>
    /// Applies the Bootstrap primary color to the confirm button.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent Primary() { _confirmColor = "btn-primary"; return this; }

    /// <summary>
    /// Applies the Bootstrap danger color to the confirm button (ideal for destructive actions).
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent Danger() { _confirmColor = "btn-danger"; return this; }

    /// <summary>
    /// Applies the Bootstrap success color to the confirm button.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent Success() { _confirmColor = "btn-success"; return this; }

    /// <summary>
    /// Applies the Bootstrap warning color to the confirm button.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent Warning() { _confirmColor = "btn-warning"; return this; }

    /// <summary>
    /// Sets the text of the cancel button.
    /// </summary>
    /// <param name="text">The cancel button text.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent CancelText(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        _cancelText = text;
        return this;
    }

    /// <summary>
    /// Sets the confirm button to navigate to the specified URL on confirmation.
    /// </summary>
    /// <param name="url">The URL to navigate to.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent ConfirmHref(string url)
    {
        ArgumentNullException.ThrowIfNull(url);
        _href = url;
        return this;
    }

    /// <summary>
    /// Sets the confirm button to issue an HTMX GET request to the specified URL.
    /// </summary>
    /// <param name="url">The URL to request.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent ConfirmHxGet(string url) => SetHx("hx-get", url);

    /// <summary>
    /// Sets the confirm button to issue an HTMX POST request to the specified URL.
    /// </summary>
    /// <param name="url">The URL to request.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent ConfirmHxPost(string url) => SetHx("hx-post", url);

    /// <summary>
    /// Sets the confirm button to issue an HTMX DELETE request to the specified URL.
    /// </summary>
    /// <param name="url">The URL to request.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent ConfirmHxDelete(string url) => SetHx("hx-delete", url);

    /// <summary>
    /// Sets the confirm button to issue an HTMX PUT request to the specified URL.
    /// </summary>
    /// <param name="url">The URL to request.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent ConfirmHxPut(string url) => SetHx("hx-put", url);

    private string? _hxTarget;
    private string? _hxSwap;
    private string? _hxConfirm;

    /// <summary>
    /// Sets the HTMX swap target for the confirm button (e.g., "closest .modal" or "#content").
    /// </summary>
    /// <param name="selector">The target selector.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent Target(string selector)
    {
        ArgumentNullException.ThrowIfNull(selector);
        _hxTarget = selector;
        return this;
    }

    /// <summary>
    /// Sets the HTMX swap style for the confirm button (e.g., "outerHTML").
    /// </summary>
    /// <param name="swapStyle">The swap style.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent Swap(string swapStyle)
    {
        ArgumentNullException.ThrowIfNull(swapStyle);
        _hxSwap = swapStyle;
        return this;
    }

    /// <summary>
    /// Sets a native confirmation message shown before the confirm action is issued.
    /// </summary>
    /// <param name="message">The confirmation message.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ConfirmDialogComponent ConfirmMessage(string message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _hxConfirm = message;
        return this;
    }

    private ConfirmDialogComponent SetHx(string verb, string url)
    {
        ArgumentNullException.ThrowIfNull(url);
        _href = null;
        _hxVerb = verb;
        _hxUrl = url;
        return this;
    }

    /// <summary>
    /// Creates a trigger button that opens this dialog using Bootstrap's modal toggling.
    /// </summary>
    /// <param name="children">The button content.</param>
    /// <returns>A new <see cref="ButtonComponent"/> configured to open this dialog.</returns>
    public ButtonComponent Trigger(params Node[] children)
    {
        return new ButtonComponent(children)
            .Data("bs-toggle", "modal")
            .Data("bs-target", $"#{_id}");
    }

    /// <summary>
    /// Creates a trigger button with the specified text that opens this dialog.
    /// </summary>
    /// <param name="text">The button text.</param>
    /// <returns>A new <see cref="ButtonComponent"/> configured to open this dialog.</returns>
    public ButtonComponent Trigger(string text)
    {
        return new ButtonComponent(text)
            .Data("bs-toggle", "modal")
            .Data("bs-target", $"#{_id}");
    }

    /// <inheritdoc/>
    public override Node Render()
    {
        if (string.IsNullOrEmpty(_id))
            throw new InvalidOperationException("ConfirmDialogComponent.Id must be set before rendering.");

        var confirm = new ButtonComponent(_confirmText).Class(_confirmColor);
        if (_href is not null)
        {
            confirm.On("click", $"window.location.href='{_href}';");
        }
        else if (_hxVerb is not null)
        {
            confirm.Attributes.Set(_hxVerb, _hxUrl!);
            if (_hxTarget is not null)
                confirm.Attributes.Set("hx-target", _hxTarget);
            if (_hxSwap is not null)
                confirm.Attributes.Set("hx-swap", _hxSwap);
            if (_hxConfirm is not null)
                confirm.Attributes.Set("hx-confirm", _hxConfirm);
            confirm.Data("bs-dismiss", "modal");
        }
        else
        {
            confirm.Data("bs-dismiss", "modal");
        }

        var cancel = new ButtonComponent(_cancelText)
            .Class("btn-secondary")
            .Data("bs-dismiss", "modal");

        return new ModalComponent(
            new ModalDialogComponent(
                new ModalContentComponent(
                    new ModalHeaderComponent(
                        new ModalTitleComponent(_title),
                        new ModalCloseButtonComponent()
                    ),
                    new ModalBodyComponent(_message),
                    new ModalFooterComponent(
                        cancel,
                        confirm
                    )
                )
            )
        ).Fade().Id(_id);
    }
}

/// <summary>
/// Extension methods for creating Bootstrap confirmation dialog components.
/// </summary>
public static class ConfirmDialogExtensions
{
    /// <summary>
    /// Creates a new <see cref="ConfirmDialogComponent"/>.
    /// </summary>
    /// <returns>A new confirmation dialog instance.</returns>
    public static ConfirmDialogComponent ConfirmDialog() => new();
}
