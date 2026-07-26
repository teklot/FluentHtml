using FluentHtml.Attributes;

namespace FluentHtml.Nodes;

/// <summary>
/// Abstract base class for all HTML elements. Provides fluent methods for configuring
/// common attributes and managing CSS classes. All HTML element types derive from this class.
/// </summary>
public abstract class Element : Node
{
    private readonly AttributeCollection _attributes = new();
    private readonly List<string> _classes = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="Element"/> class with no children.
    /// </summary>
    protected Element()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Element"/> class with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes to add.</param>
    protected Element(params Node[] children)
        : base(children)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Element"/> class with a text content child.
    /// </summary>
    /// <param name="textContent">The text content to add as a child text node.</param>
    protected Element(string textContent)
        : base(textContent)
    {
    }

    /// <summary>
    /// Gets or sets the HTML tag name for this element.
    /// </summary>
    public string TagName { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets a value indicating whether this element is self-closing (e.g., &lt;input/&gt;, &lt;br/&gt;).
    /// </summary>
    public bool IsSelfClosing { get; protected set; }

    /// <summary>
    /// Gets the attribute collection for this element.
    /// </summary>
    public AttributeCollection Attributes => _attributes;

    /// <summary>
    /// Gets the list of CSS classes applied to this element.
    /// </summary>
    public IReadOnlyList<string> Classes => _classes;

    /// <summary>
    /// Sets the id attribute for this element.
    /// </summary>
    /// <param name="id">The element id.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element Id(string id)
    {
        _attributes.Set("id", id);
        return this;
    }

    /// <summary>
    /// Adds one or more CSS classes to this element. Multiple classes are separated by spaces.
    /// Duplicate classes are ignored.
    /// </summary>
    /// <param name="className">The CSS class name(s) to add.</param>
    /// <returns>The current element for method chaining.</returns>
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

    /// <summary>
    /// Sets the style attribute for this element.
    /// </summary>
    /// <param name="style">The inline CSS style string.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element Style(string style)
    {
        _attributes.Set("style", style);
        return this;
    }

    /// <summary>
    /// Sets the title attribute for this element.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element Title(string title)
    {
        _attributes.Set("title", title);
        return this;
    }

    /// <summary>
    /// Sets a data attribute on this element.
    /// </summary>
    /// <param name="key">The data attribute key (without the "data-" prefix).</param>
    /// <param name="value">The data attribute value.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element Data(string key, string value)
    {
        _attributes.Set($"data-{key}", value);
        return this;
    }

    /// <summary>
    /// Sets an ARIA attribute on this element.
    /// </summary>
    /// <param name="key">The ARIA attribute key (without the "aria-" prefix).</param>
    /// <param name="value">The ARIA attribute value.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element Aria(string key, string value)
    {
        _attributes.Set($"aria-{key}", value);
        return this;
    }

    /// <summary>
    /// Sets the role attribute for this element.
    /// </summary>
    /// <param name="role">The ARIA role value.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element Role(string role)
    {
        _attributes.Set("role", role);
        return this;
    }

    /// <summary>
    /// Sets the tabindex attribute for this element.
    /// </summary>
    /// <param name="index">The tab order index.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element TabIndex(int index)
    {
        _attributes.Set("tabindex", index.ToString());
        return this;
    }

    /// <summary>
    /// Sets the hidden attribute on this element.
    /// </summary>
    /// <returns>The current element for method chaining.</returns>
    public Element Hidden()
    {
        _attributes.SetBool("hidden");
        return this;
    }

    /// <summary>
    /// Sets the disabled attribute on this element.
    /// </summary>
    /// <returns>The current element for method chaining.</returns>
    public Element Disabled()
    {
        _attributes.SetBool("disabled");
        return this;
    }

    /// <summary>
    /// Sets the required attribute on this element.
    /// </summary>
    /// <returns>The current element for method chaining.</returns>
    public Element Required()
    {
        _attributes.SetBool("required");
        return this;
    }

    /// <summary>
    /// Sets the readonly attribute on this element.
    /// </summary>
    /// <returns>The current element for method chaining.</returns>
    public Element ReadOnly()
    {
        _attributes.SetBool("readonly");
        return this;
    }

    /// <summary>
    /// Sets the checked attribute on this element.
    /// </summary>
    /// <returns>The current element for method chaining.</returns>
    public Element Checked()
    {
        _attributes.SetBool("checked");
        return this;
    }

    /// <summary>
    /// Sets a custom attribute on this element.
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <param name="value">The attribute value.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element Custom(string name, string value)
    {
        _attributes.Set(name, value);
        return this;
    }

    /// <summary>
    /// Sets an inline event handler attribute on this element.
    /// </summary>
    /// <param name="eventName">The event name (e.g., "click", "submit").</param>
    /// <param name="handler">The JavaScript event handler.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element On(string eventName, string handler)
    {
        _attributes.Set($"on{eventName}", handler);
        return this;
    }

    /// <summary>
    /// Sets the tag name and self-closing flag for this element.
    /// </summary>
    /// <param name="tagName">The HTML tag name.</param>
    /// <param name="selfClosing">If true, the element renders as self-closing.</param>
    protected void SetTag(string tagName, bool selfClosing = false)
    {
        TagName = tagName;
        IsSelfClosing = selfClosing;
    }

    /// <summary>
    /// Gets all CSS classes as a space-separated string.
    /// </summary>
    /// <returns>A string containing all CSS classes.</returns>
    public string GetClassesAsString() => string.Join(" ", _classes);

    /// <summary>
    /// Determines whether this element has the specified CSS class.
    /// </summary>
    /// <param name="className">The CSS class name to check.</param>
    /// <returns>true if the element has the class; otherwise, false.</returns>
    public bool HasClass(string className) => _classes.Contains(className);
}