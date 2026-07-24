using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class AudioElement : Element
{
    public AudioElement(params Node[] children) : base(children) => SetTag("audio");
    public AudioElement(string textContent) : base(textContent) => SetTag("audio");

    public AudioElement Src(string src) { Attributes.Set("src", src); return this; }
    public AudioElement Controls() { Attributes.SetBool("controls"); return this; }
}

public static class AudioExtensions
{
    public static AudioElement Audio(params Node[] children) => new(children);
    public static AudioElement Audio(string textContent) => new(textContent);
}
