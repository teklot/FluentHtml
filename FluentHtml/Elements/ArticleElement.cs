using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class ArticleElement : Element
{
    public ArticleElement(params Node[] children) : base(children) => SetTag("article");
    public ArticleElement(string textContent) : base(textContent) => SetTag("article");
}

public static class ArticleExtensions
{
    public static ArticleElement Article(params Node[] children) => new(children);
    public static ArticleElement Article(string textContent) => new(textContent);
}
