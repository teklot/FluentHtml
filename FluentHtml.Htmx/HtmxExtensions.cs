using FluentHtml.Nodes;

namespace FluentHtml.Htmx;

public static class HtmxExtensions
{
    public static T HxGet<T>(this T element, string url) where T : Element
    {
        element.Attributes.Set("hx-get", url);
        return element;
    }

    public static T HxPost<T>(this T element, string url) where T : Element
    {
        element.Attributes.Set("hx-post", url);
        return element;
    }

    public static T HxPut<T>(this T element, string url) where T : Element
    {
        element.Attributes.Set("hx-put", url);
        return element;
    }

    public static T HxDelete<T>(this T element, string url) where T : Element
    {
        element.Attributes.Set("hx-delete", url);
        return element;
    }

    public static T HxPatch<T>(this T element, string url) where T : Element
    {
        element.Attributes.Set("hx-patch", url);
        return element;
    }

    public static T HxSwap<T>(this T element, string swapStyle) where T : Element
    {
        element.Attributes.Set("hx-swap", swapStyle);
        return element;
    }

    public static T HxTarget<T>(this T element, string target) where T : Element
    {
        element.Attributes.Set("hx-target", target);
        return element;
    }

    public static T HxTrigger<T>(this T element, string trigger) where T : Element
    {
        element.Attributes.Set("hx-trigger", trigger);
        return element;
    }

    public static T HxBoost<T>(this T element, bool boost = true) where T : Element
    {
        if (boost)
            element.Attributes.SetBool("hx-boost");
        else
            element.Attributes.Remove("hx-boost");
        return element;
    }

    public static T HxIndicator<T>(this T element, string indicator) where T : Element
    {
        element.Attributes.Set("hx-indicator", indicator);
        return element;
    }

    public static T HxConfirm<T>(this T element, string message) where T : Element
    {
        element.Attributes.Set("hx-confirm", message);
        return element;
    }

    public static T HxPushUrl<T>(this T element, string url) where T : Element
    {
        element.Attributes.Set("hx-push-url", url);
        return element;
    }

    public static T HxSelect<T>(this T element, string selector) where T : Element
    {
        element.Attributes.Set("hx-select", selector);
        return element;
    }

    public static T HxSelectOob<T>(this T element, string selector) where T : Element
    {
        element.Attributes.Set("hx-select-oob", selector);
        return element;
    }

    public static T HxSwapOob<T>(this T element, string swapStyle) where T : Element
    {
        element.Attributes.Set("hx-swap-oob", swapStyle);
        return element;
    }

    public static T HxVals<T>(this T element, string vals) where T : Element
    {
        element.Attributes.Set("hx-vals", vals);
        return element;
    }

    public static T HxHeaders<T>(this T element, string headers) where T : Element
    {
        element.Attributes.Set("hx-headers", headers);
        return element;
    }

    public static T HxInclude<T>(this T element, string include) where T : Element
    {
        element.Attributes.Set("hx-include", include);
        return element;
    }

    public static T HxParams<T>(this T element, string @params) where T : Element
    {
        element.Attributes.Set("hx-params", @params);
        return element;
    }

    public static T HxDisabled<T>(this T element, string disabled) where T : Element
    {
        element.Attributes.Set("hx-disabled", disabled);
        return element;
    }

    public static T HxDisinherit<T>(this T element, string inherit) where T : Element
    {
        element.Attributes.Set("hx-disinherit", inherit);
        return element;
    }

    public static T HxEncoding<T>(this T element, string encoding) where T : Element
    {
        element.Attributes.Set("hx-encoding", encoding);
        return element;
    }

    public static T HxValidate<T>(this T element, bool validate = true) where T : Element
    {
        if (validate)
            element.Attributes.SetBool("hx-validate");
        else
            element.Attributes.Remove("hx-validate");
        return element;
    }

    public static T HxSync<T>(this T element, string sync) where T : Element
    {
        element.Attributes.Set("hx-sync", sync);
        return element;
    }
}
