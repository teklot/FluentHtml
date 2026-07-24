using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class ScriptElement : Element
{
    public ScriptElement(params Node[] children) : base(children) => SetTag("script");
    public ScriptElement(string textContent) : base(new RawHtml(textContent ?? string.Empty)) => SetTag("script");

    public ScriptElement Src(string src) { Attributes.Set("src", src); return this; }
    public ScriptElement Defer() { Attributes.SetBool("defer"); return this; }
}

public static class ScriptExtensions
{
    public static ScriptElement Script(params Node[] children) => new(children);
    public static ScriptElement Script(string textContent) => new(textContent);
}
