using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class TfootElement : Element
{
    public TfootElement(params Node[] children) : base(children) => SetTag("tfoot");
    public TfootElement(string textContent) : base(textContent) => SetTag("tfoot");
}

public static class TfootExtensions
{
    public static TfootElement Tfoot(params Node[] children) => new(children);
    public static TfootElement Tfoot(string textContent) => new(textContent);
}
