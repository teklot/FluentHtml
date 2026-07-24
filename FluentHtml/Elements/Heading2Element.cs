using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class Heading2Element : Element
{
    public Heading2Element(params Node[] children) : base(children) => SetTag("h2");
    public Heading2Element(string textContent) : base(textContent) => SetTag("h2");

    public new Heading2Element Id(string id) { base.Id(id); return this; }
    public new Heading2Element Class(string className) { base.Class(className); return this; }
}

public static class Heading2Extensions
{
    public static Heading2Element H2(params Node[] children) => new(children);
    public static Heading2Element H2(string textContent) => new(textContent);
}
