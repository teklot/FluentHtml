using FluentHtml.Attributes;

namespace FluentHtml.Nodes;

public abstract class Element : Node
{
    private readonly AttributeCollection _attributes = new();
    private readonly List<string> _classes = [];

    protected Element()
    {
    }

    protected Element(params Node[] children)
        : base(children)
    {
    }

    protected Element(string textContent)
        : base(textContent)
    {
    }

    public string TagName { get; protected set; } = string.Empty;

    public bool IsSelfClosing { get; protected set; }

    public AttributeCollection Attributes => _attributes;

    public IReadOnlyList<string> Classes => _classes;

    public Element Id(string id)
    {
        _attributes.Set("id", id);
        return this;
    }

    public Element Class(string className)
    {
        if (!string.IsNullOrWhiteSpace(className))
        {
            foreach (var cls in className.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                if (!_classes.Contains(cls))
                    _classes.Add(cls);
            }
        }
        return this;
    }

    public Element Style(string style)
    {
        _attributes.Set("style", style);
        return this;
    }

    public Element Title(string title)
    {
        _attributes.Set("title", title);
        return this;
    }

    public Element Data(string key, string value)
    {
        _attributes.Set($"data-{key}", value);
        return this;
    }

    public Element Aria(string key, string value)
    {
        _attributes.Set($"aria-{key}", value);
        return this;
    }

    public Element Role(string role)
    {
        _attributes.Set("role", role);
        return this;
    }

    public Element TabIndex(int index)
    {
        _attributes.Set("tabindex", index.ToString());
        return this;
    }

    public Element Hidden()
    {
        _attributes.SetBool("hidden");
        return this;
    }

    public Element Disabled()
    {
        _attributes.SetBool("disabled");
        return this;
    }

    public Element Required()
    {
        _attributes.SetBool("required");
        return this;
    }

    public Element ReadOnly()
    {
        _attributes.SetBool("readonly");
        return this;
    }

    public Element Checked()
    {
        _attributes.SetBool("checked");
        return this;
    }

    public Element Custom(string name, string value)
    {
        _attributes.Set(name, value);
        return this;
    }

    public Element On(string eventName, string handler)
    {
        _attributes.Set($"on{eventName}", handler);
        return this;
    }

    protected void SetTag(string tagName, bool selfClosing = false)
    {
        TagName = tagName;
        IsSelfClosing = selfClosing;
    }

    public string GetClassesAsString() => string.Join(" ", _classes);

    public bool HasClass(string className) => _classes.Contains(className);
}
