using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class StrongElement : Element
{
    public StrongElement(params Node[] children) : base(children) => SetTag("strong");
    public StrongElement(string textContent) : base(textContent) => SetTag("strong");
}

public static class StrongExtensions
{
    public static StrongElement Strong(params Node[] children) => new(children);
    public static StrongElement Strong(string textContent) => new(textContent);
}
