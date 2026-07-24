using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class TimeElement : Element
{
    public TimeElement(params Node[] children) : base(children) => SetTag("time");
    public TimeElement(string textContent) : base(textContent) => SetTag("time");

    public TimeElement DateTime(string datetime) { Attributes.Set("datetime", datetime); return this; }
}

public static class TimeExtensions
{
    public static TimeElement Time(params Node[] children) => new(children);
    public static TimeElement Time(string textContent) => new(textContent);
}
