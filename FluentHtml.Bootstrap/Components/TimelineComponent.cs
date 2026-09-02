using FluentHtml.Components;
using FluentHtml.Elements;
using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A vertical timeline component for displaying ordered events with icons, dates,
/// titles, and descriptions. Uses Bootstrap-compatible utility classes along with a
/// minimal injected stylesheet for the connector line and event dots.
/// </summary>
public sealed class TimelineComponent : Component
{
    private readonly System.Collections.Generic.List<TimelineItemComponent> _items = new();

    /// <summary>
    /// Adds an event to the timeline.
    /// </summary>
    /// <param name="item">The timeline item to add.</param>
    /// <returns>The current instance for method chaining.</returns>
    public TimelineComponent Add(TimelineItemComponent item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _items.Add(item);
        return this;
    }

    /// <summary>
    /// Adds an event to the timeline with the specified properties.
    /// </summary>
    /// <param name="date">The event date label.</param>
    /// <param name="title">The event title.</param>
    /// <param name="description">The event description.</param>
    /// <returns>The current instance for method chaining.</returns>
    public TimelineComponent Add(string date, string title, string description)
    {
        _items.Add(new TimelineItemComponent(date, title, description));
        return this;
    }

    /// <inheritdoc/>
    public override Node Render()
    {
        var items = new System.Collections.Generic.List<Node>(_items.Count);
        foreach (var item in _items)
        {
            items.Add(item.Render());
        }

        var root = new UlElement(items.ToArray())
            .Class("timeline list-unstyled position-relative ms-3");

        return new Fragment(
            new StyleElement(TimelineStyles.Css),
            root
        );
    }
}

/// <summary>
/// A single event within a <see cref="TimelineComponent"/>.
/// </summary>
public sealed class TimelineItemComponent
{
    private string _date = string.Empty;
    private string _title = string.Empty;
    private string _description = string.Empty;
    private string? _icon;
    private string _iconColor = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="TimelineItemComponent"/> class.
    /// </summary>
    public TimelineItemComponent()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TimelineItemComponent"/> class with
    /// a date, title, and description.
    /// </summary>
    /// <param name="date">The event date label.</param>
    /// <param name="title">The event title.</param>
    /// <param name="description">The event description.</param>
    public TimelineItemComponent(string date, string title, string description)
    {
        _date = date;
        _title = title;
        _description = description;
    }

    /// <summary>
    /// Sets the event date label.
    /// </summary>
    /// <param name="date">The date label.</param>
    /// <returns>The current instance for method chaining.</returns>
    public TimelineItemComponent Date(string date)
    {
        ArgumentNullException.ThrowIfNull(date);
        _date = date;
        return this;
    }

    /// <summary>
    /// Sets the event title.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <returns>The current instance for method chaining.</returns>
    public TimelineItemComponent Title(string title)
    {
        ArgumentNullException.ThrowIfNull(title);
        _title = title;
        return this;
    }

    /// <summary>
    /// Sets the event description.
    /// </summary>
    /// <param name="description">The description text.</param>
    /// <returns>The current instance for method chaining.</returns>
    public TimelineItemComponent Description(string description)
    {
        ArgumentNullException.ThrowIfNull(description);
        _description = description;
        return this;
    }

    /// <summary>
    /// Sets a Bootstrap Icon to display as the event marker.
    /// </summary>
    /// <param name="icon">The Bootstrap Icon name (e.g., "check-circle").</param>
    /// <returns>The current instance for method chaining.</returns>
    public TimelineItemComponent Icon(string icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        _icon = icon;
        return this;
    }

    /// <summary>
    /// Applies a text color to the icon marker (e.g., "text-primary", "text-success").
    /// </summary>
    /// <param name="color">The Bootstrap text color class.</param>
    /// <returns>The current instance for method chaining.</returns>
    public TimelineItemComponent IconColor(string color)
    {
        ArgumentNullException.ThrowIfNull(color);
        _iconColor = color;
        return this;
    }

    /// <summary>
    /// Renders this timeline item into a node tree.
    /// </summary>
    /// <returns>The rendered item.</returns>
    public Node Render()
    {
        var nodes = new System.Collections.Generic.List<Node>();

        if (_icon is not null)
        {
            var marker = BootstrapIconExtensions.BiIcon(_icon);
            marker.Class("me-2");
            if (!string.IsNullOrEmpty(_iconColor))
                marker.Class(_iconColor);
            nodes.Add(marker);
        }

        if (!string.IsNullOrEmpty(_date))
            nodes.Add(new SmallElement(_date).Class("text-muted"));

        nodes.Add(new Heading6Element(_title).Class("fw-semibold mb-1"));
        nodes.Add(new ParagraphElement(_description).Class("text-muted mb-0").Style("max-width:500px"));

        return new LiElement(nodes.ToArray())
            .Class("timeline-item position-relative ps-4 pb-4");
    }
}

/// <summary>
/// Extension methods for creating Bootstrap timeline components.
/// </summary>
public static class TimelineExtensions
{
    /// <summary>
    /// Creates a new empty <see cref="TimelineComponent"/>.
    /// </summary>
    /// <returns>A new timeline instance.</returns>
    public static TimelineComponent Timeline() => new();
}

internal static class TimelineStyles
{
    internal const string Css = @"
        .timeline { border-left: 2px solid var(--bs-border-color); }
        .timeline-item::before {
            content: '';
            position: absolute;
            left: -7px;
            top: 0.25rem;
            width: 12px;
            height: 12px;
            border-radius: 50%;
            background: var(--bs-body-color);
            border: 2px solid var(--bs-body-bg);
        }";
}
