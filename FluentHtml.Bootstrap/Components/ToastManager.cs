using FluentHtml.Elements;
using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A server-side manager for building and rendering Bootstrap toasts. Collects toasts
/// into a queue and produces either a positioned <see cref="ToastContainerComponent"/>
/// for embedding in a page, or out-of-band swap fragments for HTMX responses.
/// </summary>
public sealed class ToastManager
{
    private readonly string _idBase = $"{Guid.NewGuid():N}";
    private readonly System.Collections.Generic.List<ToastComponent> _toasts = new();
    private string _position = "toast-top-end";
    private bool _autohide;
    private int _delay = 5000;
    private int? _maxVisible;

    /// <summary>
    /// Adds an existing toast to the manager.
    /// </summary>
    /// <param name="toast">The toast to add.</param>
    /// <returns>The current manager for method chaining.</returns>
    public ToastManager Add(ToastComponent toast)
    {
        ArgumentNullException.ThrowIfNull(toast);
        _toasts.Add(toast);
        return this;
    }

    /// <summary>
    /// Sets the position of the toast container.
    /// </summary>
    /// <param name="position">The Bootstrap toast position class (e.g., "toast-top-end").</param>
    /// <returns>The current manager for method chaining.</returns>
    public ToastManager Position(string position)
    {
        ArgumentException.ThrowIfNullOrEmpty(position);
        _position = position;
        return this;
    }

    /// <summary>
    /// Enables auto-dismiss on all queued toasts.
    /// </summary>
    /// <returns>The current manager for method chaining.</returns>
    public ToastManager Autohide()
    {
        _autohide = true;
        return this;
    }

    /// <summary>
    /// Sets the auto-dismiss delay in milliseconds on all queued toasts.
    /// </summary>
    /// <param name="milliseconds">The delay in milliseconds.</param>
    /// <returns>The current manager for method chaining.</returns>
    public ToastManager Delay(int milliseconds)
    {
        _delay = milliseconds;
        return this;
    }

    /// <summary>
    /// Limits the number of toasts rendered to the specified maximum.
    /// </summary>
    /// <param name="maxVisible">The maximum number of toasts to render.</param>
    /// <returns>The current manager for method chaining.</returns>
    public ToastManager MaxVisible(int maxVisible)
    {
        _maxVisible = maxVisible;
        return this;
    }

    /// <summary>
    /// Adds a success toast with a title and message, styled with the success accent color.
    /// </summary>
    /// <param name="title">The toast title.</param>
    /// <param name="message">The toast message.</param>
    /// <returns>The current manager for method chaining.</returns>
    public ToastManager Success(string title, string message) => AddTyped(title, message, "success", "check-circle-fill", "text-success");

    /// <summary>
    /// Adds an error toast with a title and message, styled with the danger accent color.
    /// </summary>
    /// <param name="title">The toast title.</param>
    /// <param name="message">The toast message.</param>
    /// <returns>The current manager for method chaining.</returns>
    public ToastManager Error(string title, string message) => AddTyped(title, message, "danger", "x-circle-fill", "text-danger");

    /// <summary>
    /// Adds a warning toast with a title and message, styled with the warning accent color.
    /// </summary>
    /// <param name="title">The toast title.</param>
    /// <param name="message">The toast message.</param>
    /// <returns>The current manager for method chaining.</returns>
    public ToastManager Warning(string title, string message) => AddTyped(title, message, "warning", "exclamation-triangle-fill", "text-warning");

    /// <summary>
    /// Adds an info toast with a title and message, styled with the info accent color.
    /// </summary>
    /// <param name="title">The toast title.</param>
    /// <param name="message">The toast message.</param>
    /// <returns>The current manager for method chaining.</returns>
    public ToastManager Info(string title, string message) => AddTyped(title, message, "info", "info-circle-fill", "text-info");

    private ToastManager AddTyped(string title, string message, string accent, string icon, string iconColor)
    {
        ArgumentNullException.ThrowIfNull(title);
        ArgumentNullException.ThrowIfNull(message);
        ArgumentException.ThrowIfNullOrEmpty(accent);

        var body = new ToastBodyComponent(message);
        var headerTitle = new StrongElement(title).Class("me-auto");

        var toast = new ToastComponent(
            new ToastHeaderComponent(
                BootstrapIconExtensions.BiIcon(icon).Class(iconColor).Class("me-2"),
                headerTitle,
                new ToastCloseButtonComponent()
            ),
            body
        );

        toast.AccentColor(accent).Fade();
        if (_autohide) toast.Autohide().Delay(_delay);

        _toasts.Add(toast);
        return this;
    }

    /// <summary>
    /// Clears all queued toasts.
    /// </summary>
    /// <returns>The current manager for method chaining.</returns>
    public ToastManager Clear()
    {
        _toasts.Clear();
        return this;
    }

    /// <summary>
    /// Renders the queued toasts into a positioned <see cref="ToastContainerComponent"/>
    /// together with the initializer script and styles. The returned fragment is a
    /// self-contained toast region that can be embedded in a page at load time.
    /// </summary>
    /// <param name="containerId">
    /// The id of the toast container element when provided. Out-of-band swaps can then
    /// address the region with a selector such as <c>beforeend:#site-toasts</c>.
    /// </param>
    /// <returns>The self-contained toast region node.</returns>
    public Node Render(string? containerId = null)
    {
        var container = new ToastContainerComponent();
        AddPosition(container);
        if (!string.IsNullOrEmpty(containerId)) container.Id(containerId);

        var visible = _maxVisible.HasValue ? _toasts.Take(_maxVisible.Value) : _toasts;
        foreach (var toast in visible)
        {
            container.AddChild(toast);
        }

        return new Fragment(BuildStyles(), BuildInitScript(), container);
    }

    /// <summary>
    /// Renders the queued toasts as out-of-band swap fragments suitable for an HTMX response.
    /// When an OOB swap uses a strategy other than <c>outerHTML</c>, htmx injects the *content*
    /// of the marked element, stripping its own tag. Each toast is therefore wrapped in a
    /// carrier element that carries the <c>hx-swap-oob</c> attribute so the toast itself is
    /// inserted into the named container. A container rendered by <see cref="Render(string)"/>
    /// installs a page-wide listener that shows toasts injected this way.
    /// </summary>
    /// <param name="anchor">
    /// The out-of-band swap target. Defaults to <c>"true"</c>, which swaps each toast into the
    /// body element whose <c>id</c> matches the toast's <c>id</c>. Pass a selector such as
    /// <c>"beforeend:#toast-anchor"</c> to append toasts into a named container.
    /// </param>
    /// <returns>A <see cref="Fragment"/> containing the OOB-marked toasts.</returns>
    public Fragment RenderOob(string anchor = "true")
    {
        ArgumentException.ThrowIfNullOrEmpty(anchor);

        var visible = _maxVisible.HasValue ? _toasts.Take(_maxVisible.Value) : _toasts;
        var nodes = new System.Collections.Generic.List<Node>();
        var index = 0;
        var useCarrier = anchor != "true" && anchor != "outerHTML";

        foreach (var toast in visible)
        {
            var id = $"toast-{_idBase}-{index++}";
            toast.Id(id);

            if (useCarrier)
            {
                var carrier = new DivElement();
                carrier.Attributes.Set("hx-swap-oob", anchor);
                carrier.AddChild(toast);
                nodes.Add(carrier);
            }
            else
            {
                toast.Attributes.Set("hx-swap-oob", anchor);
                nodes.Add(toast);
            }
        }

        return new Fragment(nodes.ToArray());
    }

    /// <summary>
    /// Builds the stylesheet that gives rendered toasts a solid, high-contrast background
    /// so they stand out clearly from the page behind them.
    /// </summary>
    /// <returns>A <see cref="StyleElement"/> with toast styling.</returns>
    private static StyleElement BuildStyles()
    {
        return new StyleElement(@"
.fluent-toast{
    background-color:#ffffff !important;
    border:1px solid rgba(0,0,0,.125) !important;
    box-shadow:0 .5rem 1.25rem rgba(0,0,0,.25) !important;
}
");
    }

    /// <summary>
    /// Builds the page-load initialization script. It shows any not-yet-initialized Bootstrap
    /// toasts and installs a page-wide listener that also shows toasts injected later via
    /// HTMX (out-of-band) swaps. Each toast is initialized at most once, guarded by a marker class.
    /// </summary>
    /// <returns>A <see cref="ScriptElement"/> containing the toast initializer.</returns>
    private static ScriptElement BuildInitScript()
    {
        return new ScriptElement(@"
(function(){
    var initialized = function(t){
        return t.classList.contains('toast-initialized');
    };
    var showToast = function(t){
        if (initialized(t) || typeof bootstrap === 'undefined') return;
        t.classList.add('toast-initialized');
        new bootstrap.Toast(t).show();
    };
    var showToasts = function(root){
        root = root && root.querySelectorAll ? root : document;
        var toasts = root.querySelectorAll('.toast');
        for (var i = 0; i < toasts.length; i++){
            showToast(toasts[i]);
        }
    };
    var init = function(){ showToasts(document); };
    if (document.readyState === 'loading'){
        document.addEventListener('DOMContentLoaded', init);
    } else {
        init();
    }
    document.addEventListener('htmx:oobAfterSwap', function(e){
        showToasts(e.detail && (e.detail.target || e.detail.elt));
        showToasts(document);
    });
    document.addEventListener('htmx:afterSwap', function(e){ showToasts(document); });
})();
");
    }

    private void AddPosition(ToastContainerComponent container)
    {
        if (_position == "toast-top-start") container.PositionTopStart();
        else if (_position == "toast-top-center") container.PositionTopCenter();
        else if (_position == "toast-top-end") container.PositionTopEnd();
        else if (_position == "toast-middle-start") container.PositionMiddleStart();
        else if (_position == "toast-middle-center") container.PositionMiddleCenter();
        else if (_position == "toast-middle-end") container.PositionMiddleEnd();
        else if (_position == "toast-bottom-start") container.PositionBottomStart();
        else if (_position == "toast-bottom-center") container.PositionBottomCenter();
        else if (_position == "toast-bottom-end") container.PositionBottomEnd();
        else container.Class(_position);
    }
}
