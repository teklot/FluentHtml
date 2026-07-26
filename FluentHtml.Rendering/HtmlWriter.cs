using System.Text;

namespace FluentHtml.Rendering;

/// <summary>
/// Builds HTML output using a string builder. Provides methods for writing
/// tags, attributes, text, and raw HTML content.
/// </summary>
public sealed class HtmlWriter
{
    private readonly StringBuilder _sb = new();

    /// <summary>
    /// Writes raw HTML content without encoding.
    /// </summary>
    /// <param name="html">The raw HTML content.</param>
    /// <returns>The current writer for method chaining.</returns>
    public HtmlWriter WriteRaw(string html)
    {
        _sb.Append(html);
        return this;
    }

    /// <summary>
    /// Writes an opening HTML tag (e.g., &lt;div).
    /// </summary>
    /// <param name="tagName">The tag name.</param>
    /// <returns>The current writer for method chaining.</returns>
    public HtmlWriter WriteOpenTag(string tagName)
    {
        _sb.Append('<').Append(tagName);
        return this;
    }

    /// <summary>
    /// Writes a closing HTML tag (e.g., &lt;/div&gt;).
    /// </summary>
    /// <param name="tagName">The tag name.</param>
    /// <returns>The current writer for method chaining.</returns>
    public HtmlWriter WriteCloseTag(string tagName)
    {
        _sb.Append("</").Append(tagName).Append('>');
        return this;
    }

    /// <summary>
    /// Writes a self-closing HTML tag (e.g., &lt;input /&gt;).
    /// </summary>
    /// <param name="tagName">The tag name.</param>
    /// <returns>The current writer for method chaining.</returns>
    public HtmlWriter WriteSelfClosingTag(string tagName)
    {
        _sb.Append('<').Append(tagName).Append(" />");
        return this;
    }

    /// <summary>
    /// Writes an HTML attribute with a value (e.g., name="value").
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <param name="value">The attribute value (will be HTML-encoded).</param>
    /// <returns>The current writer for method chaining.</returns>
    public HtmlWriter WriteAttribute(string name, string value)
    {
        _sb.Append(' ').Append(name).Append("=\"").Append(HtmlEncoder.Encode(value)).Append('"');
        return this;
    }

    /// <summary>
    /// Writes a boolean HTML attribute (e.g., disabled).
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <returns>The current writer for method chaining.</returns>
    public HtmlWriter WriteBooleanAttribute(string name)
    {
        _sb.Append(' ').Append(name);
        return this;
    }

    /// <summary>
    /// Writes text content with HTML encoding.
    /// </summary>
    /// <param name="text">The text content.</param>
    /// <returns>The current writer for method chaining.</returns>
    public HtmlWriter WriteText(string text)
    {
        HtmlEncoder.Encode(text, _sb);
        return this;
    }

    /// <summary>
    /// Writes a newline character.
    /// </summary>
    /// <returns>The current writer for method chaining.</returns>
    public HtmlWriter WriteLine()
    {
        _sb.AppendLine();
        return this;
    }

    /// <inheritdoc/>
    public override string ToString() => _sb.ToString();

    /// <summary>
    /// Gets the accumulated HTML content and clears the internal buffer.
    /// </summary>
    /// <returns>The HTML content.</returns>
    public string ToStringAndClear()
    {
        var result = _sb.ToString();
        _sb.Clear();
        return result;
    }
}