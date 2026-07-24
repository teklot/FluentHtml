using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class OutputElement : Element
{
    public OutputElement(params Node[] children) : base(children) => SetTag("output");
    public OutputElement(string textContent) : base(textContent) => SetTag("output");
}

public static class OutputExtensions
{
    public static OutputElement Output(params Node[] children) => new(children);
    public static OutputElement Output(string textContent) => new(textContent);
}
