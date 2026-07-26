using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;address&gt; element.
/// </summary>
public sealed class AddressElement : Element<AddressElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddressElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public AddressElement(params Node[] children) : base(children) => SetTag("address");

    /// <summary>
    /// Initializes a new instance of the <see cref="AddressElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    public AddressElement(string textContent) : base(textContent) => SetTag("address");
}

/// <summary>
/// Factory methods for creating <see cref="AddressElement"/> instances.
/// </summary>
public static class AddressExtensions
{
    /// <summary>
    /// Creates a new &lt;address&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="AddressElement"/>.</returns>
    public static AddressElement Address(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;address&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The text content.</param>
    /// <returns>A new <see cref="AddressElement"/>.</returns>
    public static AddressElement Address(string textContent) => new(textContent);
}
