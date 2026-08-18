using FluentHtml.Nodes;

namespace FluentHtml.Forms;

/// <summary>
/// Provides configuration options for AutoForm.
/// </summary>
/// <typeparam name="TModel">The model type.</typeparam>
public sealed class FieldConfiguration<TModel> where TModel : notnull
{
    private readonly HashSet<string> _excludedProperties = [];
    private readonly Dictionary<string, string> _customLabels = [];
    private readonly Dictionary<string, SelectListItem[]> _customOptions = [];
    private readonly Dictionary<string, string> _customInputTypes = [];

    /// <summary>
    /// Gets or sets the submit button text. Defaults to <c>"Submit"</c>.
    /// </summary>
    public string SubmitText { get; set; } = "Submit";

    /// <summary>
    /// Gets or sets the CSS class for the submit button. Defaults to <c>"btn btn-primary"</c>.
    /// </summary>
    public string SubmitClass { get; set; } = "btn btn-primary";

    /// <summary>
    /// Gets or sets the form CSS class.
    /// </summary>
    public string? FormClass { get; set; }

    /// <summary>
    /// Gets or sets the form CSS id.
    /// </summary>
    public string? FormId { get; set; }

    /// <summary>
    /// Gets the set of property names to exclude from the form.
    /// </summary>
    internal IReadOnlySet<string> ExcludedProperties => _excludedProperties;

    /// <summary>
    /// Gets the dictionary of custom labels keyed by property name.
    /// </summary>
    internal IReadOnlyDictionary<string, string> CustomLabels => _customLabels;

    /// <summary>
    /// Gets the dictionary of custom select options keyed by property name.
    /// </summary>
    internal IReadOnlyDictionary<string, SelectListItem[]> CustomOptions => _customOptions;

    /// <summary>
    /// Gets the dictionary of custom input types keyed by property name.
    /// </summary>
    internal IReadOnlyDictionary<string, string> CustomInputTypes => _customInputTypes;

    /// <summary>
    /// Excludes the specified property from the auto-generated form.
    /// </summary>
    /// <param name="property">A property selector expression (e.g., <c>m => m.Id</c>).</param>
    /// <returns>The current <see cref="FieldConfiguration{TModel}"/> for method chaining.</returns>
    public FieldConfiguration<TModel> Exclude(System.Linq.Expressions.Expression<Func<TModel, object?>> property)
    {
        var name = GetPropertyName(property);
        _excludedProperties.Add(name);
        return this;
    }

    /// <summary>
    /// Overrides the display label for the specified property.
    /// </summary>
    /// <param name="property">A property selector expression.</param>
    /// <param name="label">The custom label text.</param>
    /// <returns>The current <see cref="FieldConfiguration{TModel}"/> for method chaining.</returns>
    public FieldConfiguration<TModel> Label(System.Linq.Expressions.Expression<Func<TModel, object?>> property, string label)
    {
        var name = GetPropertyName(property);
        _customLabels[name] = label;
        return this;
    }

    /// <summary>
    /// Provides custom select options for the specified property (used for enum or select fields).
    /// </summary>
    /// <param name="property">A property selector expression.</param>
    /// <param name="items">The select items to populate the dropdown.</param>
    /// <returns>The current <see cref="FieldConfiguration{TModel}"/> for method chaining.</returns>
    public FieldConfiguration<TModel> Field(System.Linq.Expressions.Expression<Func<TModel, object?>> property, SelectListItem[] items)
    {
        var name = GetPropertyName(property);
        _customOptions[name] = items;
        return this;
    }

    /// <summary>
    /// Overrides the HTML input type for the specified property.
    /// </summary>
    /// <param name="property">A property selector expression.</param>
    /// <param name="inputType">The HTML input type (e.g., "text", "email", "password").</param>
    /// <returns>The current <see cref="FieldConfiguration{TModel}"/> for method chaining.</returns>
    public FieldConfiguration<TModel> FieldType(System.Linq.Expressions.Expression<Func<TModel, object?>> property, string inputType)
    {
        var name = GetPropertyName(property);
        _customInputTypes[name] = inputType;
        return this;
    }

    private static string GetPropertyName(System.Linq.Expressions.Expression<Func<TModel, object?>> expression)
    {
        var body = expression.Body;
        if (body is System.Linq.Expressions.UnaryExpression unary)
            body = unary.Operand;
        if (body is System.Linq.Expressions.MemberExpression member && member.Member is System.Reflection.PropertyInfo prop)
            return prop.Name;
        throw new InvalidOperationException($"Expression '{expression}' does not refer to a property.");
    }
}
