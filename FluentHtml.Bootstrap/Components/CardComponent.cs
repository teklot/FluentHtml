using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

public sealed class CardComponent : Element
{
    public CardComponent(params Node[] children) : base(children) => SetTag("div");

    public CardComponent(string textContent) : base(textContent) => SetTag("div");

    public CardComponent() => SetTag("div");

    public CardComponent CardBody(params Node[] children)
    {
        AddChild(new CardBodyComponent(children));
        return this;
    }

    public CardComponent CardHeader(params Node[] children)
    {
        AddChild(new CardHeaderComponent(children));
        return this;
    }

    public CardComponent CardFooter(params Node[] children)
    {
        AddChild(new CardFooterComponent(children));
        return this;
    }
}

public sealed class CardHeaderComponent : Element
{
    public CardHeaderComponent(params Node[] children) : base(children) => SetTag("div");

    public CardHeaderComponent(string textContent) : base(textContent) => SetTag("div");

    public CardHeaderComponent() => SetTag("div");
}

public sealed class CardBodyComponent : Element
{
    public CardBodyComponent(params Node[] children) : base(children) => SetTag("div");

    public CardBodyComponent(string textContent) : base(textContent) => SetTag("div");

    public CardBodyComponent() => SetTag("div");
}

public sealed class CardFooterComponent : Element
{
    public CardFooterComponent(params Node[] children) : base(children) => SetTag("div");

    public CardFooterComponent(string textContent) : base(textContent) => SetTag("div");

    public CardFooterComponent() => SetTag("div");
}

public sealed class CardTitleComponent : Element
{
    public CardTitleComponent(params Node[] children) : base(children) => SetTag("h5");

    public CardTitleComponent(string textContent) : base(textContent) => SetTag("h5");
}

public sealed class CardTextComponent : Element
{
    public CardTextComponent(params Node[] children) : base(children) => SetTag("p");

    public CardTextComponent(string textContent) : base(textContent) => SetTag("p");
}

public sealed class CardLinkComponent : Element
{
    public CardLinkComponent(params Node[] children) : base(children) => SetTag("a");

    public CardLinkComponent(string textContent) : base(textContent) => SetTag("a");

    public CardLinkComponent Href(string href) { Attributes.Set("href", href); return this; }
}

public static class CardExtensions
{
    public static CardComponent Card(params Node[] children)
    {
        var card = new CardComponent(children);
        card.Class("card");
        return card;
    }

    public static CardComponent Card(string textContent)
    {
        var card = new CardComponent(textContent);
        card.Class("card");
        return card;
    }

    public static CardComponent Card()
    {
        var card = new CardComponent();
        card.Class("card");
        return card;
    }

    public static CardHeaderComponent CardHeader(params Node[] children)
    {
        var header = new CardHeaderComponent(children);
        header.Class("card-header");
        return header;
    }

    public static CardHeaderComponent CardHeader(string textContent)
    {
        var header = new CardHeaderComponent(textContent);
        header.Class("card-header");
        return header;
    }

    public static CardBodyComponent CardBody(params Node[] children)
    {
        var body = new CardBodyComponent(children);
        body.Class("card-body");
        return body;
    }

    public static CardBodyComponent CardBody(string textContent)
    {
        var body = new CardBodyComponent(textContent);
        body.Class("card-body");
        return body;
    }

    public static CardFooterComponent CardFooter(params Node[] children)
    {
        var footer = new CardFooterComponent(children);
        footer.Class("card-footer");
        return footer;
    }

    public static CardFooterComponent CardFooter(string textContent)
    {
        var footer = new CardFooterComponent(textContent);
        footer.Class("card-footer");
        return footer;
    }

    public static CardTitleComponent CardTitle(params Node[] children)
    {
        var title = new CardTitleComponent(children);
        title.Class("card-title");
        return title;
    }

    public static CardTitleComponent CardTitle(string textContent)
    {
        var title = new CardTitleComponent(textContent);
        title.Class("card-title");
        return title;
    }

    public static CardTextComponent CardText(params Node[] children)
    {
        var text = new CardTextComponent(children);
        text.Class("card-text");
        return text;
    }

    public static CardTextComponent CardText(string textContent)
    {
        var text = new CardTextComponent(textContent);
        text.Class("card-text");
        return text;
    }

    public static CardLinkComponent CardLink(params Node[] children)
    {
        var link = new CardLinkComponent(children);
        link.Class("card-link");
        return link;
    }

    public static CardLinkComponent CardLink(string textContent)
    {
        var link = new CardLinkComponent(textContent);
        link.Class("card-link");
        return link;
    }
}
