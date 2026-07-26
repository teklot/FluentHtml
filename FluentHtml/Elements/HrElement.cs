using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;hr&gt; element.
/// </summary>
public sealed class HrElement : Element
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HrElement"/> class. The element is self-closing.
    /// </summary>
    public HrElement() => SetTag("hr", selfClosing: true);
}

/// <summary>
/// Factory methods for creating <see cref="HrElement"/> instances.
/// </summary>
public static class HrExtensions
{
    /// <summary>
    /// Creates a new &lt;hr&gt; element.
    /// </summary>
    /// <returns>A new <see cref="HrElement"/>.</returns>
    public static HrElement Hr() => new();
}
