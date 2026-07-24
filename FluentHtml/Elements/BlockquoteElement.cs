using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class BlockquoteElement : Element
{
    public BlockquoteElement(params Node[] children) : base(children) => SetTag("blockquote");
    public BlockquoteElement(string textContent) : base(textContent) => SetTag("blockquote");
}

public static class BlockquoteExtensions
{
    public static BlockquoteElement Blockquote(params Node[] children) => new(children);
    public static BlockquoteElement Blockquote(string textContent) => new(textContent);
}
