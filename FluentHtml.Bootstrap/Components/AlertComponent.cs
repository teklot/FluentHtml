using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

public sealed class AlertComponent : Element
{
    public AlertComponent(params Node[] children) : base(children) { SetTag("div"); Class("alert"); }

    public AlertComponent(string textContent) : base(textContent) { SetTag("div"); Class("alert"); }

    public AlertComponent() { SetTag("div"); Class("alert"); }

    public AlertComponent Primary() => (AlertComponent)Class("alert-primary");

    public AlertComponent Secondary() => (AlertComponent)Class("alert-secondary");

    public AlertComponent Success() => (AlertComponent)Class("alert-success");

    public AlertComponent Danger() => (AlertComponent)Class("alert-danger");

    public AlertComponent Warning() => (AlertComponent)Class("alert-warning");

    public AlertComponent Info() => (AlertComponent)Class("alert-info");

    public AlertComponent Light() => (AlertComponent)Class("alert-light");

    public AlertComponent Dark() => (AlertComponent)Class("alert-dark");

    public AlertComponent Dismissible() => (AlertComponent)Class("alert-dismissible");

    public AlertComponent Fade() => (AlertComponent)Class("fade");

    public AlertComponent Show() => (AlertComponent)Class("show");
}

public static class AlertExtensions
{
    public static AlertComponent Alert(params Node[] children) => new(children);

    public static AlertComponent Alert(string textContent) => new(textContent);

    public static AlertComponent Alert() => new();
}
