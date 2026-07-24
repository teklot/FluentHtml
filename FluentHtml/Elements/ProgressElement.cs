using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class ProgressElement : Element
{
    public ProgressElement(params Node[] children) : base(children) => SetTag("progress");
    public ProgressElement(string textContent) : base(textContent) => SetTag("progress");

    public ProgressElement Value(double value) { Attributes.Set("value", value.ToString()); return this; }
    public ProgressElement Max(double max) { Attributes.Set("max", max.ToString()); return this; }
}

public static class ProgressExtensions
{
    public static ProgressElement Progress(params Node[] children) => new(children);
    public static ProgressElement Progress(string textContent) => new(textContent);
}
