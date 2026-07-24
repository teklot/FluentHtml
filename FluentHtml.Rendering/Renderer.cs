using FluentHtml.Nodes;

namespace FluentHtml.Rendering;

public sealed class Renderer
{
    private readonly HtmlWriter _writer = new();

    public string Render(Node node)
    {
        RenderNode(node);
        return _writer.ToStringAndClear();
    }

    public void Render(Node node, System.IO.TextWriter writer)
    {
        RenderNode(node);
        writer.Write(_writer.ToStringAndClear());
    }

    private void RenderNode(Node node)
    {
        switch (node)
        {
            case Element element:
                RenderElement(element);
                break;
            case TextNode textNode:
                _writer.WriteText(textNode.Content);
                break;
            case RawHtml rawHtml:
                _writer.WriteRaw(rawHtml.Content);
                break;
            case Fragment fragment:
                RenderChildren(fragment);
                break;
            case Components.Component component:
                RenderNode(component.Render());
                break;
            default:
                RenderChildren(node);
                break;
        }
    }

    private void RenderElement(Element element)
    {
        _writer.WriteOpenTag(element.TagName);
        WriteAttributes(element);

        if (element.IsSelfClosing)
        {
            _writer.WriteRaw(" />");
            return;
        }

        _writer.WriteRaw(">");

        RenderChildren(element);

        _writer.WriteCloseTag(element.TagName);
    }

    private void WriteAttributes(Element element)
    {
        foreach (var (name, value, isBoolean) in element.Attributes.GetAll())
        {
            if (isBoolean)
                _writer.WriteBooleanAttribute(name);
            else if (value is not null)
                _writer.WriteAttribute(name, value);
        }

        if (element.Classes.Count > 0)
        {
            _writer.WriteAttribute("class", element.GetClassesAsString());
        }
    }

    private void RenderChildren(Node node)
    {
        foreach (var child in node.Children)
        {
            RenderNode(child);
        }
    }
}
