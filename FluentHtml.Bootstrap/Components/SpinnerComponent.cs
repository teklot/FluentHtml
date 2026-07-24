using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

public sealed class SpinnerComponent : Element
{
    public SpinnerComponent() { SetTag("div"); Class("spinner-border"); }

    public SpinnerComponent Primary() => (SpinnerComponent)Class("text-primary");

    public SpinnerComponent Secondary() => (SpinnerComponent)Class("text-secondary");

    public SpinnerComponent Success() => (SpinnerComponent)Class("text-success");

    public SpinnerComponent Danger() => (SpinnerComponent)Class("text-danger");

    public SpinnerComponent Warning() => (SpinnerComponent)Class("text-warning");

    public SpinnerComponent Info() => (SpinnerComponent)Class("text-info");

    public SpinnerComponent Light() => (SpinnerComponent)Class("text-light");

    public SpinnerComponent Dark() => (SpinnerComponent)Class("text-dark");

    public SpinnerComponent Small() => (SpinnerComponent)Class("spinner-border-sm");

    public new SpinnerComponent Role(string role) { Attributes.Set("role", role); return this; }
}

public sealed class SpinnerGrowComponent : Element
{
    public SpinnerGrowComponent() { SetTag("div"); Class("spinner-grow"); }

    public SpinnerGrowComponent Primary() => (SpinnerGrowComponent)Class("text-primary");

    public SpinnerGrowComponent Secondary() => (SpinnerGrowComponent)Class("text-secondary");

    public SpinnerGrowComponent Success() => (SpinnerGrowComponent)Class("text-success");

    public SpinnerGrowComponent Danger() => (SpinnerGrowComponent)Class("text-danger");

    public SpinnerGrowComponent Warning() => (SpinnerGrowComponent)Class("text-warning");

    public SpinnerGrowComponent Info() => (SpinnerGrowComponent)Class("text-info");

    public SpinnerGrowComponent Light() => (SpinnerGrowComponent)Class("text-light");

    public SpinnerGrowComponent Dark() => (SpinnerGrowComponent)Class("text-dark");

    public SpinnerGrowComponent Small() => (SpinnerGrowComponent)Class("spinner-grow-sm");
}

public sealed class SpinnerVisibilityComponent : Element
{
    public SpinnerVisibilityComponent(params Node[] children) : base(children) { SetTag("div"); Class("spinner-border spinner-border-sm"); }

    public SpinnerVisibilityComponent(string textContent) : base(textContent) { SetTag("div"); Class("spinner-border spinner-border-sm"); }
}

public static class SpinnerExtensions
{
    public static SpinnerComponent Spinner() => new();

    public static SpinnerGrowComponent SpinnerGrow() => new();

    public static SpinnerVisibilityComponent SpinnerVisibility(params Node[] children) => new(children);

    public static SpinnerVisibilityComponent SpinnerVisibility(string textContent) => new(textContent);
}
