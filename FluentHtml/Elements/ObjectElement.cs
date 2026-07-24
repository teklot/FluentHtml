using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class ObjectElement : Element
{
    public ObjectElement(params Node[] children) : base(children) => SetTag("object");
    public ObjectElement(string textContent) : base(textContent) => SetTag("object");
}

public static class ObjectExtensions
{
    public static ObjectElement Object(params Node[] children) => new(children);
    public static ObjectElement Object(string textContent) => new(textContent);
}
