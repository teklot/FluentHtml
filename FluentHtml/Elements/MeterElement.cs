using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class MeterElement : Element
{
    public MeterElement(params Node[] children) : base(children) => SetTag("meter");
    public MeterElement(string textContent) : base(textContent) => SetTag("meter");
}

public static class MeterExtensions
{
    public static MeterElement Meter(params Node[] children) => new(children);
    public static MeterElement Meter(string textContent) => new(textContent);
}
