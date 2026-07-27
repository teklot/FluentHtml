using FluentHtml.Enums;
using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;a&gt; element. Use the A() factory methods to create instances.
/// </summary>
public sealed class AnchorElement : Element<AnchorElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AnchorElement"/> class with child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    public AnchorElement(params Node[] children) : base(children) => SetTag("a");

    /// <summary>
    /// Initializes a new instance of the <see cref="AnchorElement"/> class with text content.
    /// </summary>
    /// <param name="textContent">The link text.</param>
    public AnchorElement(string textContent) : base(textContent) => SetTag("a");

    /// <summary>
    /// Sets the href attribute for this anchor element.
    /// </summary>
    /// <param name="href">The URL to link to.</param>
    /// <returns>The current anchor for method chaining.</returns>
    public AnchorElement Href(string href)
    {
        Ensure.NotEmpty(href, nameof(href));
        Attributes.Set("href", href);
        return this;
    }

    /// <summary>
    /// Sets the target attribute for this anchor element.
    /// </summary>
    /// <param name="target">The target frame (e.g., "_blank", "_self").</param>
    /// <returns>The current anchor for method chaining.</returns>
    public AnchorElement Target(string target)
    {
        Ensure.NotEmpty(target, nameof(target));
        Attributes.Set("target", target);
        return this;
    }

    /// <summary>
    /// Sets the rel attribute for this anchor element.
    /// </summary>
    /// <param name="rel">The relationship value (e.g., "noopener", "noreferrer").</param>
    /// <returns>The current anchor for method chaining.</returns>
    public AnchorElement Rel(string rel)
    {
        Ensure.NotEmpty(rel, nameof(rel));
        Attributes.Set("rel", rel);
        return this;
    }

    /// <summary>
    /// Sets the download attribute on this anchor element.
    /// </summary>
    /// <returns>The current anchor for method chaining.</returns>
    public AnchorElement Download()
    {
        Attributes.SetBool("download");
        return this;
    }

    /// <summary>
    /// Sets the referrerpolicy attribute for this anchor element.
    /// </summary>
    /// <param name="policy">The referrer policy.</param>
    /// <returns>The current anchor for method chaining.</returns>
    public AnchorElement ReferrerPolicy(ReferrerPolicy policy) => ReferrerPolicy(policy.ToString());

    /// <summary>
    /// Sets the referrerpolicy attribute for this anchor element.
    /// </summary>
    /// <param name="policy">The referrer policy value.</param>
    /// <returns>The current anchor for method chaining.</returns>
    public AnchorElement ReferrerPolicy(string policy)
    {
        Ensure.NotEmpty(policy, nameof(policy));
        Attributes.Set("referrerpolicy", policy);
        return this;
    }
}

/// <summary>
/// Factory methods for creating <see cref="AnchorElement"/> instances.
/// </summary>
public static class AnchorExtensions
{
    /// <summary>
    /// Creates a new &lt;a&gt; element with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes.</param>
    /// <returns>A new <see cref="AnchorElement"/>.</returns>
    public static AnchorElement A(params Node[] children) => new(children);

    /// <summary>
    /// Creates a new &lt;a&gt; element with the specified text content.
    /// </summary>
    /// <param name="textContent">The link text.</param>
    /// <returns>A new <see cref="AnchorElement"/>.</returns>
    public static AnchorElement A(string textContent) => new(textContent);
}
