namespace FluentHtml.Attributes;

public sealed class AttributeCollection
{
    private readonly Dictionary<string, string> _attributes = new(StringComparer.OrdinalIgnoreCase);
    private readonly HashSet<string> _booleanAttributes = new(StringComparer.OrdinalIgnoreCase);

    public IReadOnlyDictionary<string, string> Attributes => _attributes;

    public IReadOnlySet<string> BooleanAttributes => _booleanAttributes;

    public void Set(string name, string value)
    {
        _attributes[name] = value;
    }

    public void SetBool(string name)
    {
        _booleanAttributes.Add(name);
    }

    public bool Has(string name)
    {
        return _attributes.ContainsKey(name) || _booleanAttributes.Contains(name);
    }

    public string? Get(string name)
    {
        return _attributes.TryGetValue(name, out var value) ? value : null;
    }

    public void Remove(string name)
    {
        _attributes.Remove(name);
        _booleanAttributes.Remove(name);
    }

    public void Clear()
    {
        _attributes.Clear();
        _booleanAttributes.Clear();
    }

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
