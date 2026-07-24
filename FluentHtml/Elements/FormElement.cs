using FluentHtml.Nodes;

namespace FluentHtml.Elements;

public sealed class FormElement : Element
{
    public FormElement(params Node[] children) : base(children) => SetTag("form");
    public FormElement(string textContent) : base(textContent) => SetTag("form");

    public FormElement Action(string action) { Attributes.Set("action", action); return this; }
    public FormElement Method(string method) { Attributes.Set("method", method); return this; }
    public new FormElement Id(string id) { base.Id(id); return this; }
    public new FormElement Class(string className) { base.Class(className); return this; }
    public new FormElement Disabled() { base.Disabled(); return this; }
}

public static class FormExtensions
{
    public static FormElement Form(params Node[] children) => new(children);
    public static FormElement Form(string textContent) => new(textContent);
}
