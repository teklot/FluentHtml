namespace FluentHtml.Attributes;

/// <summary>
/// Stores HTML attributes for an element, supporting both value attributes and boolean attributes.
/// Attribute names are case-insensitive.
/// </summary>
public sealed class AttributeCollection
{
    private readonly Dictionary<string, string> _attributes = new(StringComparer.OrdinalIgnoreCase);
    private readonly HashSet<string> _booleanAttributes = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Gets the dictionary of value attributes.
    /// </summary>
    public IReadOnlyDictionary<string, string> Attributes => _attributes;

    /// <summary>
    /// Gets the set of boolean attribute names.
    /// </summary>
    public IReadOnlySet<string> BooleanAttributes => _booleanAttributes;

    /// <summary>
    /// Sets a value attribute. Overwrites any existing value for the same name.
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <param name="value">The attribute value.</param>
    public void Set(string name, string value)
    {
        _attributes[name] = value;
    }

    /// <summary>
    /// Adds a boolean attribute (an attribute with no value, e.g., "disabled").
    /// </summary>
    /// <param name="name">The attribute name.</param>
    public void SetBool(string name)
    {
        _booleanAttributes.Add(name);
    }

    /// <summary>
    /// Determines whether the collection contains the specified attribute.
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <returns>true if the attribute exists; otherwise, false.</returns>
    public bool Has(string name)
    {
        return _attributes.ContainsKey(name) || _booleanAttributes.Contains(name);
    }

    /// <summary>
    /// Gets the value of the specified attribute, or null if not found.
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <returns>The attribute value, or null if not found.</returns>
    public string? Get(string name)
    {
        return _attributes.TryGetValue(name, out var value) ? value : null;
    }

    /// <summary>
    /// Removes the specified attribute from the collection.
    /// </summary>
    /// <param name="name">The attribute name.</param>
    public void Remove(string name)
    {
        _attributes.Remove(name);
        _booleanAttributes.Remove(name);
    }

    /// <summary>
    /// Removes all attributes from the collection.
    /// </summary>
    public void Clear()
    {
        _attributes.Clear();
        _booleanAttributes.Clear();
    }

    /// <summary>
    /// Enumerates all attributes as tuples of name, value, and whether it is a boolean attribute.
    /// </summary>
    /// <returns>A sequence of attribute tuples.</returns>
    public IEnumerable<(string Name, string? Value, bool IsBoolean)> GetAll()
    {
        foreach (var kvp in _attributes)
        {
            yield return (kvp.Key, kvp.Value, false);
        }
        foreach (var name in _booleanAttributes)
        {
            yield return (name, null, true);
        }
    }
}
