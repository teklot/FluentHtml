using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class VarElement : Element
{
    public VarElement(params Node[] children) : base(children) => SetTag("var");
    public VarElement(string textContent) : base(textContent) => SetTag("var");
}

public static class VarExtensions
{
    public static VarElement Var(params Node[] children) => new(children);
    public static VarElement Var(string textContent) => new(textContent);
}
