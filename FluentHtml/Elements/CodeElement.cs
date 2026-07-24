using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class CodeElement : Element
{
    public CodeElement(params Node[] children) : base(children) => SetTag("code");
    public CodeElement(string textContent) : base(textContent) => SetTag("code");
}

public static class CodeExtensions
{
    public static CodeElement Code(params Node[] children) => new(children);
    public static CodeElement Code(string textContent) => new(textContent);
}
