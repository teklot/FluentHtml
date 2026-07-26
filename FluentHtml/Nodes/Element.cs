using FluentHtml.Attributes;

namespace FluentHtml.Nodes;

/// <summary>
/// Abstract base class for all HTML elements. Provides core infrastructure for
/// tag name, attributes, and CSS class management. Fluent methods that return
/// the concrete element type live in <see cref="Element{TSelf}"/>.
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
    /// Adds one or more CSS classes to this element. Multiple classes are separated by spaces.
    /// Duplicate classes are ignored.
    /// </summary>
    /// <param name="className">The CSS class name(s) to add.</param>
    protected void AddClasses(string className)
    {
        if (!string.IsNullOrWhiteSpace(className))
        {
            foreach (var cls in className.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                if (!_classes.Contains(cls))
                    _classes.Add(cls);
            }
        }
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
