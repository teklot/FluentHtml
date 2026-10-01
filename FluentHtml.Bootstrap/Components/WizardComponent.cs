using FluentHtml.Components;
using FluentHtml.Elements;
using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap multi-step wizard component for linear, step-by-step flows. Renders a tab-style
/// step indicator, a content panel for the active step, and Back/Next/Finish navigation.
/// Steps that have a URL are navigated over HTMX, swapping the panel content; inline steps render
/// their content directly. Validation is handled server-side by the step endpoints.
/// </summary>
public sealed class WizardComponent : Component
{
    private string _id = string.Empty;
    private int _activeStep;
    private bool _linear = true;
    private string _prevText = "Back";
    private string _nextText = "Next";
    private string _finishText = "Finish";
    private string? _label;
    private string? _include;
    private string? _finishHref;
    private string? _finishHxMethod;
    private string? _finishHxUrl;

    private readonly List<WizardStep> _steps = new();

    private sealed class WizardStep
    {
        public required string Title { get; init; }
        public Node[] Content { get; init; } = System.Array.Empty<Node>();
        public string? HxUrl { get; init; }
    }

    /// <summary>
    /// Sets the unique identifier of the wizard, used as the step panel id.
    /// </summary>
    /// <param name="id">The wizard id.</param>
    /// <returns>The current instance for method chaining.</returns>
    public WizardComponent Id(string id)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);
        _id = id;
        return this;
    }

    /// <summary>
    /// Adds a step with inline content rendered directly into the panel.
    /// </summary>
    /// <param name="title">The step title shown in the step indicator.</param>
    /// <param name="content">The step content nodes.</param>
    /// <returns>The current instance for method chaining.</returns>
    public WizardComponent Step(string title, params Node[] content)
    {
        ArgumentNullException.ThrowIfNull(title);
        _steps.Add(new WizardStep { Title = title, Content = content });
        return this;
    }

    /// <summary>
    /// Adds a step whose content is loaded over HTMX when navigated to.
    /// </summary>
    /// <param name="title">The step title shown in the step indicator.</param>
    /// <param name="hxUrl">The endpoint that renders the step content.</param>
    /// <returns>The current instance for method chaining.</returns>
    public WizardComponent Step(string title, string hxUrl)
    {
        ArgumentNullException.ThrowIfNull(title);
        ArgumentNullException.ThrowIfNull(hxUrl);
        _steps.Add(new WizardStep { Title = title, HxUrl = hxUrl });
        return this;
    }

    /// <summary>
    /// Sets the zero-based index of the active step.
    /// </summary>
    /// <param name="index">The active step index.</param>
    /// <returns>The current instance for method chaining.</returns>
    public WizardComponent ActiveStep(int index)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(index);
        _activeStep = index;
        return this;
    }

    /// <summary>
    /// Enables or disables linear navigation. When enabled (the default), steps after the active
    /// step cannot be selected directly.
    /// </summary>
    /// <param name="linear">Whether navigation is strictly linear.</param>
    /// <returns>The current instance for method chaining.</returns>
    public WizardComponent Linear(bool linear = true)
    {
        _linear = linear;
        return this;
    }

    /// <summary>
    /// Sets the label text for the step counter (e.g. "Step 2 of 4").
    /// </summary>
    /// <param name="label">The label text.</param>
    /// <returns>The current instance for method chaining.</returns>
    public WizardComponent Label(string label)
    {
        ArgumentNullException.ThrowIfNull(label);
        _label = label;
        return this;
    }

    /// <summary>
    /// Sets the Back button text.
    /// </summary>
    /// <param name="text">The button text.</param>
    /// <returns>The current instance for method chaining.</returns>
    public WizardComponent PrevText(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        _prevText = text;
        return this;
    }

    /// <summary>
    /// Sets the Next button text.
    /// </summary>
    /// <param name="text">The button text.</param>
    /// <returns>The current instance for method chaining.</returns>
    public WizardComponent NextText(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        _nextText = text;
        return this;
    }

    /// <summary>
    /// Sets a CSS selector whose form values are submitted with every step navigation request.
    /// Use this to carry collected form state from one step to the next.
    /// </summary>
    /// <param name="selector">A CSS selector, for example <c>#billing-form</c>.</param>
    /// <returns>The current instance for method chaining.</returns>
    public WizardComponent Include(string selector)
    {
        ArgumentNullException.ThrowIfNull(selector);
        _include = selector;
        return this;
    }

    /// <summary>
    /// Sets the Finish button text.
    /// </summary>
    /// <param name="text">The button text.</param>
    /// <returns>The current instance for method chaining.</returns>
    public WizardComponent FinishText(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        _finishText = text;
        return this;
    }

    /// <summary>
    /// Makes the Finish button navigate to the specified URL.
    /// </summary>
    /// <param name="url">The URL to navigate to.</param>
    /// <returns>The current instance for method chaining.</returns>
    public WizardComponent FinishHref(string url)
    {
        ArgumentNullException.ThrowIfNull(url);
        _finishHref = url;
        _finishHxMethod = null;
        _finishHxUrl = null;
        return this;
    }

    /// <summary>
    /// Makes the Finish button issue an HTMX GET request to the specified URL.
    /// </summary>
    /// <param name="url">The URL to request.</param>
    /// <returns>The current instance for method chaining.</returns>
    public WizardComponent FinishHxGet(string url) => SetFinishHx("GET", url);

    /// <summary>
    /// Makes the Finish button issue an HTMX POST request to the specified URL.
    /// </summary>
    /// <param name="url">The URL to request.</param>
    /// <returns>The current instance for method chaining.</returns>
    public WizardComponent FinishHxPost(string url) => SetFinishHx("POST", url);

    private WizardComponent SetFinishHx(string method, string url)
    {
        ArgumentNullException.ThrowIfNull(url);
        _finishHref = null;
        _finishHxMethod = method;
        _finishHxUrl = url;
        return this;
    }

    private string PanelId => $"{_id}-panel";

    private string StepUrl(int index) => _steps[index].HxUrl ?? string.Empty;

    /// <inheritdoc/>
    public override Node Render()
    {
        if (string.IsNullOrEmpty(_id))
            throw new InvalidOperationException("WizardComponent.Id must be set before rendering.");

        if (_steps.Count == 0)
            throw new InvalidOperationException("WizardComponent requires at least one step before rendering.");

        if (_activeStep >= _steps.Count)
            throw new InvalidOperationException(
                $"WizardComponent.ActiveStep index {_activeStep} is out of range for {_steps.Count} step(s).");

        var indicator = BuildIndicator();
        var panel = BuildPanel();
        var footer = BuildFooter();

        var body = new List<Node> { indicator };
        if (_label is not null)
            body.Add(new ParagraphElement(_label).Class("wizard-label text-muted small mt-2 mb-2"));
        body.Add(panel);

        var children = new List<Node> { new DivElement(body.ToArray()).Class("wizard-body mb-3") };
        children.Add(footer);
        children.Add(new ScriptElement(WizardScript.Js));

        var root = new DivElement(children.ToArray()).Id(_id).Class("wizard");

        // Navigation happens client-side, so the chrome (indicator, locked steps, Back/Next/Finish)
        // cannot be baked from ActiveStep alone: those values would stay frozen at the server-rendered
        // step while the panel moved on. The script owns that state and reads this metadata.
        root.Attributes.Set("data-wizard-linear", _linear ? "true" : "false");
        root.Attributes.Set("data-wizard-current", _activeStep.ToString());
        for (var i = 0; i < _steps.Count; i++)
        {
            if (_steps[i].HxUrl is not null)
                root.Attributes.Set($"data-wizard-url-{i}", _steps[i].HxUrl!);
        }

        if (_include is not null)
            root.Attributes.Set("data-wizard-include", _include);

        return root;
    }

    private Node BuildIndicator()
    {
        var items = new List<Node>();

        for (var i = 0; i < _steps.Count; i++)
        {
            var step = _steps[i];
            var isActive = i == _activeStep;
            var isLocked = _linear && i > _activeStep;

            var link = new AnchorElement(step.Title).Class("nav-link wizard-step-link");
            link.Attributes.Set("data-wizard-step", i.ToString());
            link.Attributes.Set("href", $"#{_id}-step-{i + 1}");

            if (isActive)
            {
                link.Class("active").Aria("current", "step");
            }
            else
            {
                link.Aria("current", "false");
            }

            if (isLocked)
            {
                link.Disabled();
                link.Aria("disabled", "true");
            }

            items.Add(new LiElement(link).Class("nav-item wizard-step"));
        }

        return new UlElement(items.ToArray()).Class("nav nav-tabs wizard-steps");
    }

    private Node BuildPanel()
    {
        var panel = new DivElement().Id(PanelId).Class("tab-content wizard-panel");

        // Every inline step is rendered up front so moving between them is a client-side toggle.
        // Bootstrap hides non-active .tab-pane children of .tab-content.
        for (var i = 0; i < _steps.Count; i++)
        {
            if (_steps[i].Content.Length == 0)
                continue;

            var pane = new DivElement(_steps[i].Content).Id($"{_id}-step-{i + 1}");
            pane.Class("tab-pane fade");
            if (i == _activeStep)
                pane.Class("show active");

            panel.AddChild(pane);
        }

        // URL-backed steps have no pane: the script fetches their content on demand.
        return panel;
    }

    private Node BuildFooter()
    {
        var buttons = new List<Node>();

        var prev = new ButtonComponent(_prevText).Type("button").Class("btn-outline-secondary");
        prev.Attributes.Set("data-wizard-nav", "prev");
        if (_activeStep == 0)
            prev.Disabled();
        buttons.Add(prev);

        var next = new ButtonComponent(_nextText).Type("button").Primary();
        next.Attributes.Set("data-wizard-nav", "next");
        if (_activeStep == _steps.Count - 1)
            next.Style("display: none;");
        buttons.Add(next);

        // A Finish button with no configured action would be dead on arrival: the script only
        // knows how to issue an HTMX finish, and FinishHref carries its own navigation. Better to
        // render nothing than a button that silently does nothing.
        if (_finishHref is not null || _finishHxMethod is not null)
        {
            var finish = new ButtonComponent(_finishText).Type("button").Primary();
            finish.Attributes.Set("data-wizard-nav", "finish");
            if (_activeStep != _steps.Count - 1)
                finish.Style("display: none;");

            if (_finishHref is not null)
            {
                finish.On("click", $"window.location.href='{_finishHref}';");
            }
            else
            {
                // The finish request is issued by the script, not by htmx reading baked attributes.
                // hx-include can only reach fields that are in the DOM right now, and a swapped-out
                // step's fields are long gone, so the declarative attributes could not carry every
                // step's values. Routing finish through the script reuses the collected-value store
                // and lets it clear the navigation afterwards.
                finish.Attributes.Set("data-wizard-finish-method", _finishHxMethod!);
                finish.Attributes.Set("data-wizard-finish-url", _finishHxUrl!);
            }

            buttons.Add(finish);
        }

        return new DivElement(buttons.ToArray()).Class("wizard-footer d-flex gap-2");
    }
}

/// <summary>
/// Owns wizard navigation state. The server renders the chrome once, so anything derived from the
/// active step (locked steps, Back/Next/Finish availability) would otherwise stay frozen at the
/// initial step while the panel moved on. Registered once per page and delegated from every wizard.
/// </summary>
internal static class WizardScript
{
    public const string Js = """
        (function () {
          if (window.__fluentHtmlWizard) { return; }
          window.__fluentHtmlWizard = true;

          function links(root) { return root.querySelectorAll('.wizard-step-link'); }
          function panels(root) { return root.querySelectorAll('.wizard-panel > .tab-pane'); }

          // A step's fields only exist while that step's content is on screen: navigating swaps the
          // panel and destroys them. Values are therefore kept here for the life of the wizard, so
          // Back restores what was typed and later steps still receive earlier answers.
          function store(root) {
            if (!root.__wizardValues) { root.__wizardValues = {}; }
            return root.__wizardValues;
          }

          function collect(root) {
            var values = store(root);
            var selector = root.getAttribute('data-wizard-include');
            if (selector) {
              document.querySelectorAll(selector).forEach(function (el) {
                if (el.name && el.value !== undefined) { values[el.name] = el.value; }
              });
            }
            return values;
          }

          // Repopulate a freshly swapped step with the values already collected for it.
          function restore(root) {
            var selector = root.getAttribute('data-wizard-include');
            if (!selector) { return; }
            var values = store(root);
            var panel = root.querySelector('.wizard-panel');
            if (!panel) { return; }
            panel.querySelectorAll('input, select, textarea').forEach(function (el) {
              if (el.name && values[el.name] !== undefined && !el.value) { el.value = values[el.name]; }
            });
          }

          

          function load(root, index, previous) {
            var url = root.getAttribute('data-wizard-url-' + index);
            if (!url || typeof htmx === 'undefined') { return; }

            var panel = root.querySelector('.wizard-panel');

            // A step endpoint may reject the move (for example when a required field is empty).
            // It signals this by putting data-wizard-reject="true" on its root element, and the
            // indicator returns to the step the user came from so the error stays on that tab.
            var onSwap = function (event) {
              if (event.detail.target !== panel) { return; }
              htmx.off('htmx:afterSwap', onSwap);

              var content = panel.firstElementChild;
              if (!content) { return; }

              restore(root);

              if (previous === undefined) { return; }
              if (content.getAttribute('data-wizard-reject') === 'true') {
                apply(root, previous);
              }
            };
            htmx.on('htmx:afterSwap', onSwap);

            htmx.ajax('GET', url, {
              target: '#' + root.id + '-panel',
              swap: 'innerHTML',
              values: collect(root)
            });
          }

          function apply(root, index) {
            var linear = root.getAttribute('data-wizard-linear') === 'true';
            var items = links(root);
            var count = items.length;

            for (var i = 0; i < count; i++) {
              var locked = linear && i > index;
              items[i].classList.toggle('active', i === index);
              items[i].setAttribute('aria-current', i === index ? 'step' : 'false');
              if (locked) {
                items[i].setAttribute('disabled', '');
                items[i].setAttribute('aria-disabled', 'true');
              } else {
                items[i].removeAttribute('disabled');
                items[i].removeAttribute('aria-disabled');
              }
            }

            var targetId = root.id + '-step-' + (index + 1);
            panels(root).forEach(function (pane) {
              var on = pane.id === targetId;
              pane.classList.toggle('show', on);
              pane.classList.toggle('active', on);
            });

            var label = root.querySelector('.wizard-label');
            if (label) { label.textContent = 'Step ' + (index + 1) + ' of ' + count; }

            var back = root.querySelector('[data-wizard-nav="prev"]');
            var next = root.querySelector('[data-wizard-nav="next"]');
            var finish = root.querySelector('[data-wizard-nav="finish"]');
            var last = index === count - 1;

            if (back) {
              if (index === 0) { back.setAttribute('disabled', ''); }
              else { back.removeAttribute('disabled'); }
            }
            if (next) { next.style.display = last ? 'none' : ''; }
            if (finish) { finish.style.display = last ? '' : 'none'; }

            root.setAttribute('data-wizard-current', String(index));
          }

          // Finishing issues the configured request with every value collected so far, then retires the
            // navigation: the flow is over, so Back and Next no longer apply.
            function finish(root, button) {
              var method = button.getAttribute('data-wizard-finish-method');
              var url = button.getAttribute('data-wizard-finish-url');
              if (!method || !url) { return; }

              if (root.getAttribute('data-wizard-finished')) { return; }
              root.setAttribute('data-wizard-finished', 'true');

              if (typeof htmx !== 'undefined') {
                htmx.ajax(method, url, {
                  target: '#' + root.id + '-panel',
                  swap: 'innerHTML',
                  values: collect(root)
                });
              }

              root.querySelectorAll('[data-wizard-nav]').forEach(function (nav) {
                nav.style.display = 'none';
              });
              root.querySelectorAll('.wizard-step-link').forEach(function (link) {
                link.setAttribute('disabled', '');
                link.setAttribute('aria-disabled', 'true');
              });
            }

            function go(root, index) {
            var items = links(root);
            if (index < 0 || index >= items.length) { return; }
            var previous = parseInt(root.getAttribute('data-wizard-current') || '0', 10);
            apply(root, index);
            load(root, index, previous);
          }

          function init(root) {
            if (root.getAttribute('data-wizard-ready')) { return; }
            root.setAttribute('data-wizard-ready', 'true');
            var index = parseInt(root.getAttribute('data-wizard-current') || '0', 10);
            apply(root, index);
            // A URL-backed step never has a pane of its own, so fetch its content to fill the
            // panel. This must not depend on other steps having panes: a wizard may mix inline
            // and URL-backed steps, and the active one still needs loading.
            if (root.getAttribute('data-wizard-url-' + index)) {
              load(root, index);
            }

            // A finished wizard stays retired: the panel holds the completion message.
            if (root.getAttribute('data-wizard-finished')) {
              root.querySelectorAll('[data-wizard-nav]').forEach(function (nav) {
                nav.style.display = 'none';
              });
            }
          }

          document.addEventListener('click', function (event) {
            var step = event.target.closest('.wizard-step-link[data-wizard-step]');
            if (step) {
              event.preventDefault();
              if (step.hasAttribute('disabled')) { return; }
              var root = step.closest('.wizard');
              if (root) { go(root, parseInt(step.getAttribute('data-wizard-step'), 10)); }
              return;
            }

            var nav = event.target.closest('[data-wizard-nav]');
            if (!nav) { return; }
            if (nav.hasAttribute('disabled')) { return; }

            if (nav.getAttribute('data-wizard-nav') === 'finish') {
              // Only HTMX finishes are handled here. FinishHref wires its own inline navigation.
              var finRoot = nav.closest('.wizard');
              if (finRoot) { finish(finRoot, nav); }
              return;
            }

            var host = nav.closest('.wizard');
            if (!host) { return; }
            event.preventDefault();

            var current = parseInt(host.getAttribute('data-wizard-current') || '0', 10);
            go(host, current + (nav.getAttribute('data-wizard-nav') === 'next' ? 1 : -1));
          });

          function initAll(scope) {
            (scope || document).querySelectorAll('.wizard').forEach(init);
          }

          document.addEventListener('DOMContentLoaded', function () { initAll(); });
          if (typeof htmx !== 'undefined') {
            htmx.onLoad(function (content) { initAll(content); });
          }
        })();
        """;
}

/// <summary>
/// Extension methods for creating Bootstrap wizard components.
/// </summary>
public static class WizardExtensions
{
    /// <summary>
    /// Creates a new <see cref="WizardComponent"/>.
    /// </summary>
    /// <returns>A new wizard instance.</returns>
    public static WizardComponent Wizard() => new();
}
