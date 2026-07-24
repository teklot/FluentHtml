using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class SampElement : Element
{
    public SampElement(params Node[] children) : base(children) => SetTag("samp");
    public SampElement(string textContent) : base(textContent) => SetTag("samp");
}

public static class SampExtensions
{
    public static SampElement Samp(params Node[] children) => new(children);
    public static SampElement Samp(string textContent) => new(textContent);
}
