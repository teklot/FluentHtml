using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class DialogElement : Element
{
    public DialogElement(params Node[] children) : base(children) => SetTag("dialog");
    public DialogElement(string textContent) : base(textContent) => SetTag("dialog");
}

public static class DialogExtensions
{
    public static DialogElement Dialog(params Node[] children) => new(children);
    public static DialogElement Dialog(string textContent) => new(textContent);
}
