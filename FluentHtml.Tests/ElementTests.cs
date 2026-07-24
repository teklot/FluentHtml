using FluentHtml.Elements;
using FluentHtml.Nodes;
using FluentHtml.Rendering;

namespace FluentHtml.Tests;

public class ElementTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void Div_Renders_Open_And_Close_Tags()
    {
        var div = new DivElement();
        var html = _renderer.Render(div);
        Assert.Equal("<div></div>", html);
    }

    [Fact]
    public void Div_With_Text_Content()
    {
        var div = new DivElement("Hello");
        var html = _renderer.Render(div);
        Assert.Equal("<div>Hello</div>", html);
    }

    [Fact]
    public void Div_With_Child_Elements()
    {
        var div = new DivElement(
            new Heading1Element("Title"),
            new ParagraphElement("Body")
        );
        var html = _renderer.Render(div);
        Assert.Equal("<div><h1>Title</h1><p>Body</p></div>", html);
    }

    [Fact]
    public void Element_Id_Sets_Attribute()
    {
        var div = new DivElement().Id("main");
        var html = _renderer.Render(div);
        Assert.Equal("<div id=\"main\"></div>", html);
    }

    [Fact]
    public void Element_Class_Merges_Classes()
    {
        var div = new DivElement().Class("container").Class("fluid");
        var html = _renderer.Render(div);
        Assert.Equal("<div class=\"container fluid\"></div>", html);
    }

    [Fact]
    public void Element_Style_Sets_Style_Attribute()
    {
        var div = new DivElement().Style("padding:20px");
        var html = _renderer.Render(div);
        Assert.Equal("<div style=\"padding:20px\"></div>", html);
    }

    [Fact]
    public void SelfClosing_Input()
    {
        var input = new InputElement().Type("text").Name("email").Placeholder("Enter email");
        var html = _renderer.Render(input);
        Assert.Equal("<input type=\"text\" name=\"email\" placeholder=\"Enter email\" />", html);
    }

    [Fact]
    public void SelfClosing_Img()
    {
        var img = new ImgElement().Src("/logo.png").Alt("Logo");
        var html = _renderer.Render(img);
        Assert.Equal("<img src=\"/logo.png\" alt=\"Logo\" />", html);
    }

    [Fact]
    public void Boolean_Attribute_Disabled()
    {
        var btn = new ButtonElement("Submit").Disabled();
        var html = _renderer.Render(btn);
        Assert.Equal("<button disabled>Submit</button>", html);
    }

    [Fact]
    public void Text_Is_Html_Encoded()
    {
        var p = new ParagraphElement("<script>alert('xss')</script>");
        var html = _renderer.Render(p);
        Assert.Equal("<p>&lt;script&gt;alert(&#39;xss&#39;)&lt;/script&gt;</p>", html);
    }

    [Fact]
    public void RawHtml_Is_Not_Encoded()
    {
        var raw = new RawHtml("<strong>Bold</strong>");
        var html = _renderer.Render(raw);
        Assert.Equal("<strong>Bold</strong>", html);
    }

    [Fact]
    public void Fragment_Renders_Multiple_Siblings()
    {
        var fragment = new Fragment(
            new Heading1Element("Title"),
            new ParagraphElement("Body")
        );
        var html = _renderer.Render(fragment);
        Assert.Equal("<h1>Title</h1><p>Body</p>", html);
    }

    [Fact]
    public void Anchor_Href()
    {
        var a = new AnchorElement("Click me").Href("/home");
        var html = _renderer.Render(a);
        Assert.Equal("<a href=\"/home\">Click me</a>", html);
    }

    [Fact]
    public void Table_With_Rows()
    {
        var table = new TableElement(
            new TbodyElement(
                new TrElement(
                    new TdElement("A"),
                    new TdElement("B")
                )
            )
        );
        var html = _renderer.Render(table);
        Assert.Equal("<table><tbody><tr><td>A</td><td>B</td></tr></tbody></table>", html);
    }

    [Fact]
    public void Nested_Components_Render()
    {
        var card = new DivElement(
            new Heading2Element("Card Title"),
            new ParagraphElement("Card content")
        ).Class("card");

        var html = _renderer.Render(card);
        Assert.Equal("<div class=\"card\"><h2>Card Title</h2><p>Card content</p></div>", html);
    }
}
