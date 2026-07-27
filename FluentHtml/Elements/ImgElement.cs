using FluentHtml.Enums;
using FluentHtml.Nodes;

namespace FluentHtml.Elements;

/// <summary>
/// Represents an HTML &lt;img&gt; element. Use the <see cref="ImgExtensions.Img"/> factory method to create instances.
/// </summary>
public sealed class ImgElement : Element<ImgElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImgElement"/> class. The element is self-closing.
    /// </summary>
    public ImgElement() => SetTag("img", selfClosing: true);

    /// <summary>
    /// Sets the src attribute for this image element.
    /// </summary>
    /// <param name="src">The image URL.</param>
    /// <returns>The current image for method chaining.</returns>
    public ImgElement Src(string src)
    {
        Ensure.NotEmpty(src, nameof(src));
        Attributes.Set("src", src);
        return this;
    }

    /// <summary>
    /// Sets the alt attribute for this image element.
    /// </summary>
    /// <param name="alt">The alternative text description.</param>
    /// <returns>The current image for method chaining.</returns>
    public ImgElement Alt(string alt)
    {
        Ensure.NotNull(alt, nameof(alt));
        Attributes.Set("alt", alt);
        return this;
    }

    /// <summary>
    /// Sets the loading attribute for this image element.
    /// </summary>
    /// <param name="loading">The loading behavior.</param>
    /// <returns>The current image for method chaining.</returns>
    public ImgElement Loading(Loading loading) => Loading(loading.ToString().ToLower());

    /// <summary>
    /// Sets the loading attribute for this image element.
    /// </summary>
    /// <param name="loading">The loading value (e.g., "lazy", "eager").</param>
    /// <returns>The current image for method chaining.</returns>
    public ImgElement Loading(string loading)
    {
        Ensure.NotEmpty(loading, nameof(loading));
        Attributes.Set("loading", loading);
        return this;
    }

    /// <summary>
    /// Sets the width attribute for this image element.
    /// </summary>
    /// <param name="width">The image width in pixels.</param>
    /// <returns>The current image for method chaining.</returns>
    public ImgElement Width(int width) => Width(width.ToString());

    /// <summary>
    /// Sets the width attribute for this image element.
    /// </summary>
    /// <param name="width">The width value (e.g., "100%", "300").</param>
    /// <returns>The current image for method chaining.</returns>
    public ImgElement Width(string width)
    {
        Ensure.NotEmpty(width, nameof(width));
        Attributes.Set("width", width);
        return this;
    }

    /// <summary>
    /// Sets the height attribute for this image element.
    /// </summary>
    /// <param name="height">The image height in pixels.</param>
    /// <returns>The current image for method chaining.</returns>
    public ImgElement Height(int height) => Height(height.ToString());

    /// <summary>
    /// Sets the height attribute for this image element.
    /// </summary>
    /// <param name="height">The height value (e.g., "100%", "200").</param>
    /// <returns>The current image for method chaining.</returns>
    public ImgElement Height(string height)
    {
        Ensure.NotEmpty(height, nameof(height));
        Attributes.Set("height", height);
        return this;
    }
}

/// <summary>
/// Factory methods for creating <see cref="ImgElement"/> instances.
/// </summary>
public static class ImgExtensions
{
    /// <summary>
    /// Creates a new &lt;img&gt; element.
    /// </summary>
    /// <returns>A new <see cref="ImgElement"/>.</returns>
    public static ImgElement Img() => new();
}
