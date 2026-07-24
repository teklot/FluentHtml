using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class Heading3Element : Element
{
    public Heading3Element(params Node[] children) : base(children) => SetTag("h3");
    public Heading3Element(string textContent) : base(textContent) => SetTag("h3");
}

public static class Heading3Extensions
{
    public static Heading3Element H3(params Node[] children) => new(children);
    public static Heading3Element H3(string textContent) => new(textContent);
}
