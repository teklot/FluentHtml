namespace FluentHtml.Nodes;

public sealed class Fragment : Node
{
    public Fragment(params Node[] children)
        : base(children)
    {
    }

    public Fragment(string textContent)
        : base(textContent)
    {
    }
}
