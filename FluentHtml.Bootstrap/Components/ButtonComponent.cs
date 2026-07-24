using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

public sealed class ButtonComponent : Element
{
    public ButtonComponent(params Node[] children) : base(children) { SetTag("button"); Class("btn"); }

    public ButtonComponent(string textContent) : base(textContent) { SetTag("button"); Class("btn"); }

    public ButtonComponent() { SetTag("button"); Class("btn"); }

    public ButtonComponent Primary() => (ButtonComponent)Class("btn-primary");

    public ButtonComponent Secondary() => (ButtonComponent)Class("btn-secondary");

    public ButtonComponent Success() => (ButtonComponent)Class("btn-success");

    public ButtonComponent Danger() => (ButtonComponent)Class("btn-danger");

    public ButtonComponent Warning() => (ButtonComponent)Class("btn-warning");

    public ButtonComponent Info() => (ButtonComponent)Class("btn-info");

    public ButtonComponent Light() => (ButtonComponent)Class("btn-light");

    public ButtonComponent Dark() => (ButtonComponent)Class("btn-dark");

    public ButtonComponent Link() => (ButtonComponent)Class("btn-link");

    public ButtonComponent OutlinePrimary() => (ButtonComponent)Class("btn-outline-primary");

    public ButtonComponent OutlineSecondary() => (ButtonComponent)Class("btn-outline-secondary");

    public ButtonComponent OutlineSuccess() => (ButtonComponent)Class("btn-outline-success");

    public ButtonComponent OutlineDanger() => (ButtonComponent)Class("btn-outline-danger");

    public ButtonComponent OutlineWarning() => (ButtonComponent)Class("btn-outline-warning");

    public ButtonComponent OutlineInfo() => (ButtonComponent)Class("btn-outline-info");

    public ButtonComponent OutlineLight() => (ButtonComponent)Class("btn-outline-light");

    public ButtonComponent OutlineDark() => (ButtonComponent)Class("btn-outline-dark");

    public ButtonComponent Small() => (ButtonComponent)Class("btn-sm");

    public ButtonComponent Large() => (ButtonComponent)Class("btn-lg");

    public ButtonComponent Type(string type) { Attributes.Set("type", type); return this; }

    public new ButtonComponent Disabled() => (ButtonComponent)base.Disabled();

    public ButtonComponent Active() => (ButtonComponent)Class("active");

    public ButtonComponent Block() => (ButtonComponent)Class("d-grid");

    public ButtonComponent HxGet(string url) { Attributes.Set("hx-get", url); return this; }
    public ButtonComponent HxPost(string url) { Attributes.Set("hx-post", url); return this; }
    public ButtonComponent HxPut(string url) { Attributes.Set("hx-put", url); return this; }
    public ButtonComponent HxDelete(string url) { Attributes.Set("hx-delete", url); return this; }
    public ButtonComponent HxPatch(string url) { Attributes.Set("hx-patch", url); return this; }
    public ButtonComponent HxSwap(string swapStyle) { Attributes.Set("hx-swap", swapStyle); return this; }
    public ButtonComponent HxTarget(string target) { Attributes.Set("hx-target", target); return this; }
    public ButtonComponent HxTrigger(string trigger) { Attributes.Set("hx-trigger", trigger); return this; }
    public ButtonComponent HxConfirm(string message) { Attributes.Set("hx-confirm", message); return this; }
    public ButtonComponent HxIndicator(string indicator) { Attributes.Set("hx-indicator", indicator); return this; }
    public ButtonComponent HxBoost(bool boost = true) { if (boost) Attributes.SetBool("hx-boost"); else Attributes.Remove("hx-boost"); return this; }
    public ButtonComponent HxPushUrl(string url) { Attributes.Set("hx-push-url", url); return this; }
    public ButtonComponent HxSelect(string selector) { Attributes.Set("hx-select", selector); return this; }
}

public static class ButtonExtensions
{
    public static ButtonComponent Btn(params Node[] children) => new(children);

    public static ButtonComponent Btn(string textContent) => new(textContent);

    public static ButtonComponent Btn() => new();
}
