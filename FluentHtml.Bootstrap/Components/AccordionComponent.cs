using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// A Bootstrap accordion container component for grouping collapsible content.
/// </summary>
public sealed class AccordionComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccordionComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the accordion.</param>
    public AccordionComponent(params Node[] children) : base(children) { SetTag("div"); Class("accordion"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccordionComponent"/> class.
    /// </summary>
    public AccordionComponent() { SetTag("div"); Class("accordion"); }

    /// <summary>
    /// Applies the flush style, removing borders and rounded corners for edge-to-edge accordion items.
    /// </summary>
    /// <returns>The current <see cref="AccordionComponent"/> instance.</returns>
    public AccordionComponent Flush() => (AccordionComponent)Class("accordion-flush");
}

/// <summary>
/// A Bootstrap accordion item component representing a single collapsible section.
/// </summary>
public sealed class AccordionItemComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccordionItemComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the accordion item.</param>
    public AccordionItemComponent(params Node[] children) : base(children) { SetTag("div"); Class("accordion-item"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccordionItemComponent"/> class.
    /// </summary>
    public AccordionItemComponent() { SetTag("div"); Class("accordion-item"); }
}

/// <summary>
/// A Bootstrap accordion header component that wraps the accordion button.
/// </summary>
public sealed class AccordionHeaderComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccordionHeaderComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the accordion header.</param>
    public AccordionHeaderComponent(params Node[] children) : base(children) { SetTag("h2"); Class("accordion-header"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccordionHeaderComponent"/> class.
    /// </summary>
    public AccordionHeaderComponent() { SetTag("h2"); Class("accordion-header"); }
}

/// <summary>
/// A Bootstrap accordion button component used as the clickable toggle for expanding and collapsing accordion items.
/// </summary>
public sealed class AccordionButtonComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccordionButtonComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the accordion button.</param>
    public AccordionButtonComponent(params Node[] children) : base(children)
    {
        SetTag("button");
        Class("accordion-button");
        Attributes.Set("type", "button");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccordionButtonComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the accordion button.</param>
    public AccordionButtonComponent(string textContent) : base(textContent)
    {
        SetTag("button");
        Class("accordion-button");
        Attributes.Set("type", "button");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccordionButtonComponent"/> class.
    /// </summary>
    public AccordionButtonComponent() { SetTag("button"); Class("accordion-button"); Attributes.Set("type", "button"); }

    /// <summary>
    /// Sets the button to its collapsed state.
    /// </summary>
    /// <returns>The current <see cref="AccordionButtonComponent"/> instance.</returns>
    public AccordionButtonComponent Collapsed() => (AccordionButtonComponent)Class("collapsed");

    /// <summary>
    /// Sets the button to its expanded state.
    /// </summary>
    /// <returns>The current <see cref="AccordionButtonComponent"/> instance.</returns>
    public AccordionButtonComponent Expanded() => (AccordionButtonComponent)Class("accordion-button");
}

/// <summary>
/// A Bootstrap accordion collapse component that contains the collapsible body content.
/// </summary>
public sealed class AccordionCollapseComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccordionCollapseComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the collapse section.</param>
    public AccordionCollapseComponent(params Node[] children) : base(children)
    {
        SetTag("div");
        Class("accordion-collapse collapse");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccordionCollapseComponent"/> class.
    /// </summary>
    public AccordionCollapseComponent() { SetTag("div"); Class("accordion-collapse collapse"); }

    /// <summary>
    /// Makes the collapse section visible.
    /// </summary>
    /// <returns>The current <see cref="AccordionCollapseComponent"/> instance.</returns>
    public AccordionCollapseComponent Show() => (AccordionCollapseComponent)Class("show");

    /// <summary>
    /// Sets the parent accordion container ID for exclusive collapse behavior.
    /// </summary>
    /// <param name="parentId">The ID of the parent accordion container.</param>
    /// <returns>The current <see cref="AccordionCollapseComponent"/> instance.</returns>
    public AccordionCollapseComponent DataParent(string parentId) => (AccordionCollapseComponent)Data("bs-parent", parentId);
}

/// <summary>
/// A Bootstrap accordion body component containing the collapsible content.
/// </summary>
public sealed class AccordionBodyComponent : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccordionBodyComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include in the accordion body.</param>
    public AccordionBodyComponent(params Node[] children) : base(children) { SetTag("div"); Class("accordion-body"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccordionBodyComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content of the accordion body.</param>
    public AccordionBodyComponent(string textContent) : base(textContent) { SetTag("div"); Class("accordion-body"); }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccordionBodyComponent"/> class.
    /// </summary>
    public AccordionBodyComponent() { SetTag("div"); Class("accordion-body"); }
}

/// <summary>
/// Extension methods for creating Bootstrap accordion components.
/// </summary>
public static class AccordionExtensions
{
    /// <summary>
    /// Creates a new <see cref="AccordionComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="AccordionComponent"/> instance.</returns>
    public static AccordionComponent Accordion(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="AccordionComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="AccordionComponent"/> instance.</returns>
    public static AccordionComponent Accordion() => new();

    /// <summary>
    /// Creates a new <see cref="AccordionItemComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="AccordionItemComponent"/> instance.</returns>
    public static AccordionItemComponent AccordionItem(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="AccordionItemComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="AccordionItemComponent"/> instance.</returns>
    public static AccordionItemComponent AccordionItem() => new();

    /// <summary>
    /// Creates a new <see cref="AccordionHeaderComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="AccordionHeaderComponent"/> instance.</returns>
    public static AccordionHeaderComponent AccordionHeader(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="AccordionHeaderComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="AccordionHeaderComponent"/> instance.</returns>
    public static AccordionHeaderComponent AccordionHeader() => new();

    /// <summary>
    /// Creates a new <see cref="AccordionButtonComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="AccordionButtonComponent"/> instance.</returns>
    public static AccordionButtonComponent AccordionButton(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="AccordionButtonComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the button.</param>
    /// <returns>A new <see cref="AccordionButtonComponent"/> instance.</returns>
    public static AccordionButtonComponent AccordionButton(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="AccordionButtonComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="AccordionButtonComponent"/> instance.</returns>
    public static AccordionButtonComponent AccordionButton() => new();

    /// <summary>
    /// Creates a new <see cref="AccordionCollapseComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="AccordionCollapseComponent"/> instance.</returns>
    public static AccordionCollapseComponent AccordionCollapse(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new empty <see cref="AccordionCollapseComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="AccordionCollapseComponent"/> instance.</returns>
    public static AccordionCollapseComponent AccordionCollapse() => new();

    /// <summary>
    /// Creates a new <see cref="AccordionBodyComponent"/> with child nodes.
    /// </summary>
    /// <param name="children">The child nodes to include.</param>
    /// <returns>A new <see cref="AccordionBodyComponent"/> instance.</returns>
    public static AccordionBodyComponent AccordionBody(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new <see cref="AccordionBodyComponent"/> with text content.
    /// </summary>
    /// <param name="textContent">The text content of the body.</param>
    /// <returns>A new <see cref="AccordionBodyComponent"/> instance.</returns>
    public static AccordionBodyComponent AccordionBody(string textContent) => new(textContent);

    /// <summary>
    /// Creates a new empty <see cref="AccordionBodyComponent"/>.
    /// </summary>
    /// <returns>A new <see cref="AccordionBodyComponent"/> instance.</returns>
    public static AccordionBodyComponent AccordionBody() => new();
}
