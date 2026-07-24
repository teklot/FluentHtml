using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class Heading5Element : Element
{
    public Heading5Element(params Node[] children) : base(children) => SetTag("h5");
    public Heading5Element(string textContent) : base(textContent) => SetTag("h5");
}

public static class Heading5Extensions
{
    public static Heading5Element H5(params Node[] children) => new(children);
    public static Heading5Element H5(string textContent) => new(textContent);
}
