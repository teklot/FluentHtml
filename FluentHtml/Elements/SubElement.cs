using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class SubElement : Element
{
    public SubElement(params Node[] children) : base(children) => SetTag("sub");
    public SubElement(string textContent) : base(textContent) => SetTag("sub");
}

public static class SubExtensions
{
    public static SubElement Sub(params Node[] children) => new(children);
    public static SubElement Sub(string textContent) => new(textContent);
}
