using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class TableElement : Element
{
    public TableElement(params Node[] children) : base(children) => SetTag("table");
    public TableElement(string textContent) : base(textContent) => SetTag("table");

    public new TableElement Id(string id) { base.Id(id); return this; }
    public new TableElement Class(string className) { base.Class(className); return this; }
}

public static class TableExtensions
{
    public static TableElement Table(params Node[] children) => new(children);
    public static TableElement Table(string textContent) => new(textContent);
}
