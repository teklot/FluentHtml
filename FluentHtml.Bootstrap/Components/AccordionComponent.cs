using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

public sealed class AccordionComponent : Element
{
    public AccordionComponent(params Node[] children) : base(children) { SetTag("div"); Class("accordion"); }

    public AccordionComponent() { SetTag("div"); Class("accordion"); }

    public AccordionComponent Flush() => (AccordionComponent)Class("accordion-flush");
}

public sealed class AccordionItemComponent : Element
{
    public AccordionItemComponent(params Node[] children) : base(children) { SetTag("div"); Class("accordion-item"); }

    public AccordionItemComponent() { SetTag("div"); Class("accordion-item"); }
}

public sealed class AccordionHeaderComponent : Element
{
    public AccordionHeaderComponent(params Node[] children) : base(children) { SetTag("h2"); Class("accordion-header"); }

    public AccordionHeaderComponent() { SetTag("h2"); Class("accordion-header"); }
}

public sealed class AccordionButtonComponent : Element
{
    public AccordionButtonComponent(params Node[] children) : base(children)
    {
        SetTag("button");
        Class("accordion-button");
        Attributes.Set("type", "button");
    }

    public AccordionButtonComponent(string textContent) : base(textContent)
    {
        SetTag("button");
        Class("accordion-button");
        Attributes.Set("type", "button");
    }

    public AccordionButtonComponent() { SetTag("button"); Class("accordion-button"); Attributes.Set("type", "button"); }

    public AccordionButtonComponent Collapsed() => (AccordionButtonComponent)Class("collapsed");

    public AccordionButtonComponent Expanded() => (AccordionButtonComponent)Class("accordion-button");
}

public sealed class AccordionCollapseComponent : Element
{
    public AccordionCollapseComponent(params Node[] children) : base(children)
    {
        SetTag("div");
        Class("accordion-collapse collapse");
    }

    public AccordionCollapseComponent() { SetTag("div"); Class("accordion-collapse collapse"); }

    public AccordionCollapseComponent Show() => (AccordionCollapseComponent)Class("show");

    public AccordionCollapseComponent DataParent(string parentId) => (AccordionCollapseComponent)Data("bs-parent", parentId);
}

public sealed class AccordionBodyComponent : Element
{
    public AccordionBodyComponent(params Node[] children) : base(children) { SetTag("div"); Class("accordion-body"); }

    public AccordionBodyComponent(string textContent) : base(textContent) { SetTag("div"); Class("accordion-body"); }

    public AccordionBodyComponent() { SetTag("div"); Class("accordion-body"); }
}

public static class AccordionExtensions
{
    public static AccordionComponent Accordion(params Node[] children) => new(children);

    public static AccordionComponent Accordion() => new();

    public static AccordionItemComponent AccordionItem(params Node[] children) => new(children);

    public static AccordionItemComponent AccordionItem() => new();

    public static AccordionHeaderComponent AccordionHeader(params Node[] children) => new(children);

    public static AccordionHeaderComponent AccordionHeader() => new();

    public static AccordionButtonComponent AccordionButton(params Node[] children) => new(children);

    public static AccordionButtonComponent AccordionButton(string textContent) => new(textContent);

    public static AccordionButtonComponent AccordionButton() => new();

    public static AccordionCollapseComponent AccordionCollapse(params Node[] children) => new(children);

    public static AccordionCollapseComponent AccordionCollapse() => new();

    public static AccordionBodyComponent AccordionBody(params Node[] children) => new(children);

    public static AccordionBodyComponent AccordionBody(string textContent) => new(textContent);

    public static AccordionBodyComponent AccordionBody() => new();
}
