using System.Text;

namespace FluentHtml.Rendering;

public sealed class HtmlWriter
{
    private readonly StringBuilder _sb = new();

    public HtmlWriter WriteRaw(string html)
    {
        _sb.Append(html);
        return this;
    }

    public HtmlWriter WriteOpenTag(string tagName)
    {
        _sb.Append('<').Append(tagName);
        return this;
    }

    public HtmlWriter WriteCloseTag(string tagName)
    {
        _sb.Append("</").Append(tagName).Append('>');
        return this;
    }

    public HtmlWriter WriteSelfClosingTag(string tagName)
    {
        _sb.Append('<').Append(tagName).Append(" />");
        return this;
    }

    public HtmlWriter WriteAttribute(string name, string value)
    {
        _sb.Append(' ').Append(name).Append("=\"").Append(HtmlEncoder.Encode(value)).Append('"');
        return this;
    }

    public HtmlWriter WriteBooleanAttribute(string name)
    {
        _sb.Append(' ').Append(name);
        return this;
    }

    public HtmlWriter WriteText(string text)
    {
        HtmlEncoder.Encode(text, _sb);
        return this;
    }

    public HtmlWriter WriteLine()
    {
        _sb.AppendLine();
        return this;
    }

    public override string ToString() => _sb.ToString();

    public string ToStringAndClear()
    {
        var result = _sb.ToString();
        _sb.Clear();
        return result;
    }
}
