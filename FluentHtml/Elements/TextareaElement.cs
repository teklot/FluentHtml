using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class TextareaElement : Element
{
    public TextareaElement(params Node[] children) : base(children) => SetTag("textarea");
    public TextareaElement(string textContent) : base(textContent) => SetTag("textarea");

    public TextareaElement Rows(int rows) { Attributes.Set("rows", rows.ToString()); return this; }
    public TextareaElement Cols(int cols) { Attributes.Set("cols", cols.ToString()); return this; }
    public TextareaElement Name(string name) { Attributes.Set("name", name); return this; }
}

public static class TextareaExtensions
{
    public static TextareaElement Textarea(params Node[] children) => new(children);
    public static TextareaElement Textarea(string textContent) => new(textContent);
}
