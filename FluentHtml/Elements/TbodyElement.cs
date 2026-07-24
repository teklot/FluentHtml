using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class TbodyElement : Element
{
    public TbodyElement(params Node[] children) : base(children) => SetTag("tbody");
    public TbodyElement(string textContent) : base(textContent) => SetTag("tbody");
}

public static class TbodyExtensions
{
    public static TbodyElement Tbody(params Node[] children) => new(children);
    public static TbodyElement Tbody(string textContent) => new(textContent);
}
