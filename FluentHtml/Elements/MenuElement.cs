using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class MenuElement : Element
{
    public MenuElement(params Node[] children) : base(children) => SetTag("menu");
    public MenuElement(string textContent) : base(textContent) => SetTag("menu");
}

public static class MenuExtensions
{
    public static MenuElement Menu(params Node[] children) => new(children);
    public static MenuElement Menu(string textContent) => new(textContent);
}
