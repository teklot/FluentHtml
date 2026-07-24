using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class DatalistElement : Element
{
    public DatalistElement(params Node[] children) : base(children) => SetTag("datalist");
    public DatalistElement(string textContent) : base(textContent) => SetTag("datalist");
}

public static class DatalistExtensions
{
    public static DatalistElement Datalist(params Node[] children) => new(children);
    public static DatalistElement Datalist(string textContent) => new(textContent);
}
