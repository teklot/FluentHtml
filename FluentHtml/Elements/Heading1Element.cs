using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class Heading1Element : Element
{
    public Heading1Element(params Node[] children) : base(children) => SetTag("h1");
    public Heading1Element(string textContent) : base(textContent) => SetTag("h1");

    public new Heading1Element Id(string id) { base.Id(id); return this; }
    public new Heading1Element Class(string className) { base.Class(className); return this; }
}

public static class Heading1Extensions
{
    public static Heading1Element H1(params Node[] children) => new(children);
    public static Heading1Element H1(string textContent) => new(textContent);
}
