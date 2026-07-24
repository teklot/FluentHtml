namespace FluentHtml.Samples.Components;

public static class SectionHelper
{
    public static DivElement ShowSection(string title, params Node[] content)
    {
        var el = Div(H2(title).Class("border-bottom pb-2 mb-3")).Class("mb-5");
        el.AddChildren(content);
        return el;
    }
}
