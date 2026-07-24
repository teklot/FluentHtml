using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class QElement : Element
{
    public QElement(params Node[] children) : base(children) => SetTag("q");
    public QElement(string textContent) : base(textContent) => SetTag("q");
}

public static class QExtensions
{
    public static QElement Q(params Node[] children) => new(children);
    public static QElement Q(string textContent) => new(textContent);
}
