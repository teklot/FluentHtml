using FluentHtml.Nodes;

namespace FluentHtml.Htmx;

/// <summary>
/// HTMX attribute extension methods for FluentHtml elements. These methods allow
/// you to configure HTMX behavior using a fluent API.
/// </summary>
public static class HtmxExtensions
{
    /// <summary>
    /// Sets the hx-get attribute to issue an HTMX GET request to the specified URL.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="url">The URL to request.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxGet<T>(this T element, string url) where T : Element<T>
    {
        element.Attributes.Set("hx-get", url);
        return element;
    }

    /// <summary>
    /// Sets the hx-post attribute to issue an HTMX POST request to the specified URL.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="url">The URL to request.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxPost<T>(this T element, string url) where T : Element<T>
    {
        element.Attributes.Set("hx-post", url);
        return element;
    }

    /// <summary>
    /// Sets the hx-put attribute to issue an HTMX PUT request to the specified URL.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="url">The URL to request.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxPut<T>(this T element, string url) where T : Element<T>
    {
        element.Attributes.Set("hx-put", url);
        return element;
    }

    /// <summary>
    /// Sets the hx-delete attribute to issue an HTMX DELETE request to the specified URL.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="url">The URL to request.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxDelete<T>(this T element, string url) where T : Element<T>
    {
        element.Attributes.Set("hx-delete", url);
        return element;
    }

    /// <summary>
    /// Sets the hx-patch attribute to issue an HTMX PATCH request to the specified URL.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="url">The URL to request.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxPatch<T>(this T element, string url) where T : Element<T>
    {
        element.Attributes.Set("hx-patch", url);
        return element;
    }

    /// <summary>
    /// Sets the hx-swap attribute to control how the response HTML is swapped into the DOM.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="swapStyle">The swap strategy (e.g., "innerHTML", "outerHTML", "beforeend").</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxSwap<T>(this T element, string swapStyle) where T : Element<T>
    {
        element.Attributes.Set("hx-swap", swapStyle);
        return element;
    }

    /// <summary>
    /// Sets the hx-target attribute to specify which element should receive the response HTML.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="target">The CSS selector for the target element.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxTarget<T>(this T element, string target) where T : Element<T>
    {
        element.Attributes.Set("hx-target", target);
        return element;
    }

    /// <summary>
    /// Sets the hx-trigger attribute to specify when an HTMX request should be triggered.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="trigger">The trigger event (e.g., "click", "submit", "every 5s").</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxTrigger<T>(this T element, string trigger) where T : Element<T>
    {
        element.Attributes.Set("hx-trigger", trigger);
        return element;
    }

    /// <summary>
    /// Sets the hx-boost attribute to enable or disable HTMX boost for this element.
    /// When enabled, all anchor clicks and form submissions for this element will use HTMX.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="boost">If true, enables boost; if false, disables it.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxBoost<T>(this T element, bool boost = true) where T : Element<T>
    {
        if (boost)
            element.Attributes.SetBool("hx-boost");
        else
            element.Attributes.Remove("hx-boost");
        return element;
    }

    /// <summary>
    /// Sets the hx-indicator attribute to specify a CSS class for the element while a request is in flight.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="indicator">The CSS class to apply during loading.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxIndicator<T>(this T element, string indicator) where T : Element<T>
    {
        element.Attributes.Set("hx-indicator", indicator);
        return element;
    }

    /// <summary>
    /// Sets the hx-confirm attribute to display a confirmation dialog before making a request.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="message">The confirmation message to display.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxConfirm<T>(this T element, string message) where T : Element<T>
    {
        element.Attributes.Set("hx-confirm", message);
        return element;
    }

    /// <summary>
    /// Sets the hx-push-url attribute to push a new URL into the browser history.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="url">The URL to push to the history.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxPushUrl<T>(this T element, string url) where T : Element<T>
    {
        element.Attributes.Set("hx-push-url", url);
        return element;
    }

    /// <summary>
    /// Sets the hx-select attribute to select content from the response to swap.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="selector">The CSS selector to select from the response.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxSelect<T>(this T element, string selector) where T : Element<T>
    {
        element.Attributes.Set("hx-select", selector);
        return element;
    }

    /// <summary>
    /// Sets the hx-select-oob attribute to select content from the response for out-of-band swaps.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="selector">The CSS selector for out-of-band selection.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxSelectOob<T>(this T element, string selector) where T : Element<T>
    {
        element.Attributes.Set("hx-select-oob", selector);
        return element;
    }

    /// <summary>
    /// Sets the hx-swap-oob attribute to specify an out-of-band swap strategy.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="swapStyle">The out-of-band swap strategy.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxSwapOob<T>(this T element, string swapStyle) where T : Element<T>
    {
        element.Attributes.Set("hx-swap-oob", swapStyle);
        return element;
    }

    /// <summary>
    /// Sets the hx-vals attribute to include additional values in the request.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="vals">The additional values as JSON or a JavaScript expression.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxVals<T>(this T element, string vals) where T : Element<T>
    {
        element.Attributes.Set("hx-vals", vals);
        return element;
    }

    /// <summary>
    /// Sets the hx-headers attribute to include additional headers in the request.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="headers">The additional headers as JSON.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxHeaders<T>(this T element, string headers) where T : Element<T>
    {
        element.Attributes.Set("hx-headers", headers);
        return element;
    }

    /// <summary>
    /// Sets the hx-include attribute to include additional form values in the request.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="include">The CSS selector of elements to include.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxInclude<T>(this T element, string include) where T : Element<T>
    {
        element.Attributes.Set("hx-include", include);
        return element;
    }

    /// <summary>
    /// Sets the hx-params attribute to control which parameters are included in the request.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="params">The parameter filter (e.g., "none", "*, except foo").</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxParams<T>(this T element, string @params) where T : Element<T>
    {
        element.Attributes.Set("hx-params", @params);
        return element;
    }

    /// <summary>
    /// Sets the hx-disabled attribute to disable the element while a request is in flight.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="disabled">The CSS selector of elements to disable during requests.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxDisabled<T>(this T element, string disabled) where T : Element<T>
    {
        element.Attributes.Set("hx-disabled", disabled);
        return element;
    }

    /// <summary>
    /// Sets the hx-disinherit attribute to control attribute inheritance for child elements.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="inherit">The attributes to disinherit (space-separated).</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxDisinherit<T>(this T element, string inherit) where T : Element<T>
    {
        element.Attributes.Set("hx-disinherit", inherit);
        return element;
    }

    /// <summary>
    /// Sets the hx-encoding attribute to specify the encoding for the request.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="encoding">The encoding type (e.g., "multipart/form-data").</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxEncoding<T>(this T element, string encoding) where T : Element<T>
    {
        element.Attributes.Set("hx-encoding", encoding);
        return element;
    }

    /// <summary>
    /// Sets the hx-validate attribute to enable or disable validation for this element.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="validate">If true, enables validation; if false, disables it.</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxValidate<T>(this T element, bool validate = true) where T : Element<T>
    {
        if (validate)
            element.Attributes.SetBool("hx-validate");
        else
            element.Attributes.Remove("hx-validate");
        return element;
    }

    /// <summary>
    /// Sets the hx-sync attribute to control how multiple requests are synchronized.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to configure.</param>
    /// <param name="sync">The synchronization strategy (e.g., "drop", "replace", "queue first").</param>
    /// <returns>The element for method chaining.</returns>
    public static T HxSync<T>(this T element, string sync) where T : Element<T>
    {
        element.Attributes.Set("hx-sync", sync);
        return element;
    }
}