using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class Heading4Element : Element
{
    public Heading4Element(params Node[] children) : base(children) => SetTag("h4");
    public Heading4Element(string textContent) : base(textContent) => SetTag("h4");
}

public static class Heading4Extensions
{
    public static Heading4Element H4(params Node[] children) => new(children);
    public static Heading4Element H4(string textContent) => new(textContent);
}
