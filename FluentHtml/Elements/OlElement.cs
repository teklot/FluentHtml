using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class OlElement : Element
{
    public OlElement(params Node[] children) : base(children) => SetTag("ol");
    public OlElement(string textContent) : base(textContent) => SetTag("ol");
}

public static class OlExtensions
{
    public static OlElement Ol(params Node[] children) => new(children);
    public static OlElement Ol(string textContent) => new(textContent);
}
