using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class AddressElement : Element
{
    public AddressElement(params Node[] children) : base(children) => SetTag("address");
    public AddressElement(string textContent) : base(textContent) => SetTag("address");
}

public static class AddressExtensions
{
    public static AddressElement Address(params Node[] children) => new(children);
    public static AddressElement Address(string textContent) => new(textContent);
}
