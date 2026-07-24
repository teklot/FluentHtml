using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class SummaryElement : Element
{
    public SummaryElement(params Node[] children) : base(children) => SetTag("summary");
    public SummaryElement(string textContent) : base(textContent) => SetTag("summary");
}

public static class SummaryExtensions
{
    public static SummaryElement Summary(params Node[] children) => new(children);
    public static SummaryElement Summary(string textContent) => new(textContent);
}
