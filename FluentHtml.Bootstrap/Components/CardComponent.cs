using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap card component. Cards provide a flexible and extensible
/// content container with multiple variants and options.
/// </summary>
public sealed class CardComponent : Element<CardComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CardComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public CardComponent(params Node[] children) : base(children) => SetTag("div");

    /// <summary>
    /// Initializes a new instance of the <see cref="CardComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The card text content.</param>
    public CardComponent(string textContent) : base(textContent) => SetTag("div");

    /// <summary>
    /// Initializes a new instance of the <see cref="CardComponent"/> class.
    /// </summary>
    public CardComponent() => SetTag("div");

    /// <summary>
    /// Adds a card body section to this card.
    /// </summary>
    /// <param name="children">The child nodes for the card body.</param>
    /// <returns>The current card for method chaining.</returns>
    public CardComponent CardBody(params Node[] children)
    {
        AddChild(new CardBodyComponent(children));
        return this;
    }

    /// <summary>
    /// Adds a card header section to this card.
    /// </summary>
    /// <param name="children">The child nodes for the card header.</param>
    /// <returns>The current card for method chaining.</returns>
    public CardComponent CardHeader(params Node[] children)
    {
        AddChild(new CardHeaderComponent(children));
        return this;
    }

    /// <summary>
    /// Adds a card footer section to this card.
    /// </summary>
    /// <param name="children">The child nodes for the card footer.</param>
    /// <returns>The current card for method chaining.</returns>
    public CardComponent CardFooter(params Node[] children)
    {
        AddChild(new CardFooterComponent(children));
        return this;
    }
}

/// <summary>
/// Represents a Bootstrap card header section.
/// </summary>
public sealed class CardHeaderComponent : Element<CardHeaderComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CardHeaderComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public CardHeaderComponent(params Node[] children) : base(children) => SetTag("div");

    /// <summary>
    /// Initializes a new instance of the <see cref="CardHeaderComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The header text content.</param>
    public CardHeaderComponent(string textContent) : base(textContent) => SetTag("div");

    /// <summary>
    /// Initializes a new instance of the <see cref="CardHeaderComponent"/> class.
    /// </summary>
    public CardHeaderComponent() => SetTag("div");
}

/// <summary>
/// Represents a Bootstrap card body section.
/// </summary>
public sealed class CardBodyComponent : Element<CardBodyComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CardBodyComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public CardBodyComponent(params Node[] children) : base(children) => SetTag("div");

    /// <summary>
    /// Initializes a new instance of the <see cref="CardBodyComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The body text content.</param>
    public CardBodyComponent(string textContent) : base(textContent) => SetTag("div");

    /// <summary>
    /// Initializes a new instance of the <see cref="CardBodyComponent"/> class.
    /// </summary>
    public CardBodyComponent() => SetTag("div");
}

/// <summary>
/// Represents a Bootstrap card footer section.
/// </summary>
public sealed class CardFooterComponent : Element<CardFooterComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CardFooterComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public CardFooterComponent(params Node[] children) : base(children) => SetTag("div");

    /// <summary>
    /// Initializes a new instance of the <see cref="CardFooterComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The footer text content.</param>
    public CardFooterComponent(string textContent) : base(textContent) => SetTag("div");

    /// <summary>
    /// Initializes a new instance of the <see cref="CardFooterComponent"/> class.
    /// </summary>
    public CardFooterComponent() => SetTag("div");
}

/// <summary>
/// Represents a Bootstrap card title (renders as &lt;h5&gt;).
/// </summary>
public sealed class CardTitleComponent : Element<CardTitleComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CardTitleComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public CardTitleComponent(params Node[] children) : base(children) => SetTag("h5");

    /// <summary>
    /// Initializes a new instance of the <see cref="CardTitleComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The title text.</param>
    public CardTitleComponent(string textContent) : base(textContent) => SetTag("h5");
}

/// <summary>
/// Represents a Bootstrap card text (renders as &lt;p&gt;).
/// </summary>
public sealed class CardTextComponent : Element<CardTextComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CardTextComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public CardTextComponent(params Node[] children) : base(children) => SetTag("p");

    /// <summary>
    /// Initializes a new instance of the <see cref="CardTextComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public CardTextComponent(string textContent) : base(textContent) => SetTag("p");
}

/// <summary>
/// Represents a Bootstrap card link (renders as &lt;a&gt;).
/// </summary>
public sealed class CardLinkComponent : Element<CardLinkComponent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CardLinkComponent"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public CardLinkComponent(params Node[] children) : base(children) => SetTag("a");

    /// <summary>
    /// Initializes a new instance of the <see cref="CardLinkComponent"/> class with text content.
    /// </summary>
    /// <param name="textContent">The link text.</param>
    public CardLinkComponent(string textContent) : base(textContent) => SetTag("a");

    /// <summary>
    /// Sets the href attribute for this card link.
    /// </summary>
    /// <param name="href">The URL to link to.</param>
    /// <returns>The current card link for method chaining.</returns>
    public CardLinkComponent Href(string href) { Attributes.Set("href", href); return this; }
}

/// <summary>
/// Factory methods for creating Bootstrap card components.
/// </summary>
public static class CardExtensions
{
    /// <summary>
    /// Creates a new Bootstrap card with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="CardComponent"/> with the "card" CSS class.</returns>
    public static CardComponent Card(params Node[] children)
    {
        var card = new CardComponent(children);
        card.Class("card");
        return card;
    }

    /// <summary>
    /// Creates a new Bootstrap card with the specified text content.
    /// </summary>
    /// <param name="textContent">The card text content.</param>
    /// <returns>A new <see cref="CardComponent"/> with the "card" CSS class.</returns>
    public static CardComponent Card(string textContent)
    {
        var card = new CardComponent(textContent);
        card.Class("card");
        return card;
    }

    /// <summary>
    /// Creates a new empty Bootstrap card.
    /// </summary>
    /// <returns>A new <see cref="CardComponent"/> with the "card" CSS class.</returns>
    public static CardComponent Card()
    {
        var card = new CardComponent();
        card.Class("card");
        return card;
    }

    /// <summary>
    /// Creates a new Bootstrap card header with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="CardHeaderComponent"/> with the "card-header" CSS class.</returns>
    public static CardHeaderComponent CardHeader(params Node[] children)
    {
        var header = new CardHeaderComponent(children);
        header.Class("card-header");
        return header;
    }

    /// <summary>
    /// Creates a new Bootstrap card header with the specified text content.
    /// </summary>
    /// <param name="textContent">The header text content.</param>
    /// <returns>A new <see cref="CardHeaderComponent"/> with the "card-header" CSS class.</returns>
    public static CardHeaderComponent CardHeader(string textContent)
    {
        var header = new CardHeaderComponent(textContent);
        header.Class("card-header");
        return header;
    }

    /// <summary>
    /// Creates a new Bootstrap card body with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="CardBodyComponent"/> with the "card-body" CSS class.</returns>
    public static CardBodyComponent CardBody(params Node[] children)
    {
        var body = new CardBodyComponent(children);
        body.Class("card-body");
        return body;
    }

    /// <summary>
    /// Creates a new Bootstrap card body with the specified text content.
    /// </summary>
    /// <param name="textContent">The body text content.</param>
    /// <returns>A new <see cref="CardBodyComponent"/> with the "card-body" CSS class.</returns>
    public static CardBodyComponent CardBody(string textContent)
    {
        var body = new CardBodyComponent(textContent);
        body.Class("card-body");
        return body;
    }

    /// <summary>
    /// Creates a new Bootstrap card footer with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="CardFooterComponent"/> with the "card-footer" CSS class.</returns>
    public static CardFooterComponent CardFooter(params Node[] children)
    {
        var footer = new CardFooterComponent(children);
        footer.Class("card-footer");
        return footer;
    }

    /// <summary>
    /// Creates a new Bootstrap card footer with the specified text content.
    /// </summary>
    /// <param name="textContent">The footer text content.</param>
    /// <returns>A new <see cref="CardFooterComponent"/> with the "card-footer" CSS class.</returns>
    public static CardFooterComponent CardFooter(string textContent)
    {
        var footer = new CardFooterComponent(textContent);
        footer.Class("card-footer");
        return footer;
    }

    /// <summary>
    /// Creates a new Bootstrap card title with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="CardTitleComponent"/> with the "card-title" CSS class.</returns>
    public static CardTitleComponent CardTitle(params Node[] children)
    {
        var title = new CardTitleComponent(children);
        title.Class("card-title");
        return title;
    }

    /// <summary>
    /// Creates a new Bootstrap card title with the specified text content.
    /// </summary>
    /// <param name="textContent">The title text.</param>
    /// <returns>A new <see cref="CardTitleComponent"/> with the "card-title" CSS class.</returns>
    public static CardTitleComponent CardTitle(string textContent)
    {
        var title = new CardTitleComponent(textContent);
        title.Class("card-title");
        return title;
    }

    /// <summary>
    /// Creates a new Bootstrap card text with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="CardTextComponent"/> with the "card-text" CSS class.</returns>
    public static CardTextComponent CardText(params Node[] children)
    {
        var text = new CardTextComponent(children);
        text.Class("card-text");
        return text;
    }

    /// <summary>
    /// Creates a new Bootstrap card text with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="CardTextComponent"/> with the "card-text" CSS class.</returns>
    public static CardTextComponent CardText(string textContent)
    {
        var text = new CardTextComponent(textContent);
        text.Class("card-text");
        return text;
    }

    /// <summary>
    /// Creates a new Bootstrap card link with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="CardLinkComponent"/> with the "card-link" CSS class.</returns>
    public static CardLinkComponent CardLink(params Node[] children)
    {
        var link = new CardLinkComponent(children);
        link.Class("card-link");
        return link;
    }

    /// <summary>
    /// Creates a new Bootstrap card link with the specified text content.
    /// </summary>
    /// <param name="textContent">The link text.</param>
    /// <returns>A new <see cref="CardLinkComponent"/> with the "card-link" CSS class.</returns>
    public static CardLinkComponent CardLink(string textContent)
    {
        var link = new CardLinkComponent(textContent);
        link.Class("card-link");
        return link;
    }
}