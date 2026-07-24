using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class PreElement : Element
{
    public PreElement(params Node[] children) : base(children) => SetTag("pre");
    public PreElement(string textContent) : base(textContent) => SetTag("pre");
}

public static class PreExtensions
{
    public static PreElement Pre(params Node[] children) => new(children);
    public static PreElement Pre(string textContent) => new(textContent);
}
