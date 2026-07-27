namespace FluentHtml.Nodes;

/// <summary>
/// CRTP base class for HTML elements. Provides fluent methods that return the concrete
/// element type, enabling strongly-typed method chaining without <c>new</c> keyword hiding.
/// </summary>
/// <typeparam name="TSelf">The concrete element type.</typeparam>
public abstract class Element<TSelf> : Element where TSelf : Element<TSelf>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Element{TSelf}"/> class with no children.
    /// </summary>
    protected Element()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Element{TSelf}"/> class with the specified child nodes.
    /// </summary>
    /// <param name="children">The child nodes to add.</param>
    protected Element(params Node[] children)
        : base(children)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Element{TSelf}"/> class with a text content child.
    /// </summary>
    /// <param name="textContent">The text content to add as a child text node.</param>
    protected Element(string textContent)
        : base(textContent)
    {
    }

    /// <summary>
    /// Sets the id attribute for this element.
    /// </summary>
    /// <param name="id">The element id.</param>
    /// <returns>The current element for method chaining.</returns>
    public TSelf Id(string id)
    {
        Ensure.NotEmpty(id, nameof(id));
        Attributes.Set("id", id);
        return (TSelf)this;
    }

    /// <summary>
    /// Adds one or more CSS classes to this element. Multiple classes are separated by spaces.
    /// Duplicate classes are ignored.
    /// </summary>
    /// <param name="className">The CSS class name(s) to add.</param>
    /// <returns>The current element for method chaining.</returns>
    public TSelf Class(string className)
    {
        AddClasses(className);
        return (TSelf)this;
    }

    /// <summary>
    /// Sets the style attribute for this element.
    /// </summary>
    /// <param name="style">The inline CSS style string.</param>
    /// <returns>The current element for method chaining.</returns>
    public TSelf Style(string style)
    {
        Attributes.Set("style", style);
        return (TSelf)this;
    }

    /// <summary>
    /// Sets the title attribute for this element.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <returns>The current element for method chaining.</returns>
    public TSelf Title(string title)
    {
        Attributes.Set("title", title);
        return (TSelf)this;
    }

    /// <summary>
    /// Sets a data attribute on this element.
    /// </summary>
    /// <param name="key">The data attribute key (without the "data-" prefix).</param>
    /// <param name="value">The data attribute value.</param>
    /// <returns>The current element for method chaining.</returns>
    public TSelf Data(string key, string value)
    {
        Ensure.NotNull(key, nameof(key));
        Ensure.NotNull(value, nameof(value));
        Attributes.Set($"data-{key}", value);
        return (TSelf)this;
    }

    /// <summary>
    /// Sets an ARIA attribute on this element.
    /// </summary>
    /// <param name="key">The ARIA attribute key (without the "aria-" prefix).</param>
    /// <param name="value">The ARIA attribute value.</param>
    /// <returns>The current element for method chaining.</returns>
    public TSelf Aria(string key, string value)
    {
        Ensure.NotNull(key, nameof(key));
        Ensure.NotNull(value, nameof(value));
        Attributes.Set($"aria-{key}", value);
        return (TSelf)this;
    }

    /// <summary>
    /// Sets the role attribute for this element.
    /// </summary>
    /// <param name="role">The ARIA role value.</param>
    /// <returns>The current element for method chaining.</returns>
    public TSelf Role(string role)
    {
        Ensure.NotEmpty(role, nameof(role));
        Attributes.Set("role", role);
        return (TSelf)this;
    }

    /// <summary>
    /// Sets the tabindex attribute for this element.
    /// </summary>
    /// <param name="index">The tab order index.</param>
    /// <returns>The current element for method chaining.</returns>
    public TSelf TabIndex(int index)
    {
        Attributes.Set("tabindex", index.ToString());
        return (TSelf)this;
    }

    /// <summary>
    /// Sets the hidden attribute on this element.
    /// </summary>
    /// <returns>The current element for method chaining.</returns>
    public TSelf Hidden()
    {
        Attributes.SetBool("hidden");
        return (TSelf)this;
    }

    /// <summary>
    /// Sets the disabled attribute on this element.
    /// </summary>
    /// <returns>The current element for method chaining.</returns>
    public TSelf Disabled()
    {
        Attributes.SetBool("disabled");
        return (TSelf)this;
    }

    /// <summary>
    /// Sets the required attribute on this element.
    /// </summary>
    /// <returns>The current element for method chaining.</returns>
    public TSelf Required()
    {
        Attributes.SetBool("required");
        return (TSelf)this;
    }

    /// <summary>
    /// Sets the readonly attribute on this element.
    /// </summary>
    /// <returns>The current element for method chaining.</returns>
    public TSelf ReadOnly()
    {
        Attributes.SetBool("readonly");
        return (TSelf)this;
    }

    /// <summary>
    /// Sets the checked attribute on this element.
    /// </summary>
    /// <returns>The current element for method chaining.</returns>
    public TSelf Checked()
    {
        Attributes.SetBool("checked");
        return (TSelf)this;
    }

    /// <summary>
    /// Sets a custom attribute on this element.
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <param name="value">The attribute value.</param>
    /// <returns>The current element for method chaining.</returns>
    public TSelf Custom(string name, string value)
    {
        Ensure.NotNull(name, nameof(name));
        Ensure.NotNull(value, nameof(value));
        Attributes.Set(name, value);
        return (TSelf)this;
    }

    /// <summary>
    /// Sets an inline event handler attribute on this element.
    /// </summary>
    /// <param name="eventName">The event name (e.g., "click", "submit").</param>
    /// <param name="handler">The JavaScript event handler.</param>
    /// <returns>The current element for method chaining.</returns>
    public TSelf On(string eventName, string handler)
    {
        Ensure.NotNull(eventName, nameof(eventName));
        Ensure.NotNull(handler, nameof(handler));
        Attributes.Set($"on{eventName}", handler);
        return (TSelf)this;
    }
}
