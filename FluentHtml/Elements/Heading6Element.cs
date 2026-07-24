using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class Heading6Element : Element
{
    public Heading6Element(params Node[] children) : base(children) => SetTag("h6");
    public Heading6Element(string textContent) : base(textContent) => SetTag("h6");
}

public static class Heading6Extensions
{
    public static Heading6Element H6(params Node[] children) => new(children);
    public static Heading6Element H6(string textContent) => new(textContent);
}
