using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class KbdElement : Element
{
    public KbdElement(params Node[] children) : base(children) => SetTag("kbd");
    public KbdElement(string textContent) : base(textContent) => SetTag("kbd");
}

public static class KbdExtensions
{
    public static KbdElement Kbd(params Node[] children) => new(children);
    public static KbdElement Kbd(string textContent) => new(textContent);
}
