using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class HrElement : Element
{
    public HrElement() => SetTag("hr", selfClosing: true);
}

public static class HrExtensions
{
    public static HrElement Hr() => new();
}
