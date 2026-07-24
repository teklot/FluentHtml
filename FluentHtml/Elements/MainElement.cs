using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class MainElement : Element
{
    public MainElement(params Node[] children) : base(children) => SetTag("main");
    public MainElement(string textContent) : base(textContent) => SetTag("main");

    public new MainElement Id(string id) { base.Id(id); return this; }
    public new MainElement Class(string className) { base.Class(className); return this; }
}

public static class MainExtensions
{
    public static MainElement Main(params Node[] children) => new(children);
    public static MainElement Main(string textContent) => new(textContent);
}
