using FluentHtml.Elements;
using FluentHtml.Enums;
using FluentHtml.Nodes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace FluentHtml.Forms;

/// <summary>
/// Provides extension methods for auto-generating complete forms from model types.
/// </summary>
public static class AutoFormExtensions
{
    /// <summary>
    /// Generates a complete HTML form from the model type using reflection and DataAnnotations.
    /// </summary>
    /// <typeparam name="TModel">The model type.</typeparam>
    /// <param name="model">The model instance used for type inference.</param>
    /// <param name="action">The form action URL.</param>
    /// <param name="method">The HTTP method (GET or POST).</param>
    /// <returns>A <see cref="FormElement"/> containing all form fields, labels, and a submit button.</returns>
    public static FormElement AutoForm<TModel>(this TModel model, string action, MethodType method = MethodType.Post) where TModel : notnull
    {
        return AutoForm(model, action, method, null);
    }

    /// <summary>
    /// Generates a complete HTML form from the model type using reflection, DataAnnotations, and optional configuration.
    /// </summary>
    /// <typeparam name="TModel">The model type.</typeparam>
    /// <param name="model">The model instance used for type inference.</param>
    /// <param name="action">The form action URL.</param>
    /// <param name="method">The HTTP method (GET or POST).</param>
    /// <param name="hx">Optional HTMX configuration action.</param>
    /// <returns>A <see cref="FormElement"/> containing all form fields, labels, and a submit button.</returns>
    public static FormElement AutoForm<TModel>(this TModel model, string action, MethodType method, Action<HtmxFormConfig>? hx) where TModel : notnull
    {
        return AutoForm(model, action, method, hx, null);
    }

    /// <summary>
    /// Generates a complete HTML form from the model type using reflection, DataAnnotations, optional configuration, and optional field customization.
    /// </summary>
    /// <typeparam name="TModel">The model type.</typeparam>
    /// <param name="model">The model instance used for type inference.</param>
    /// <param name="action">The form action URL.</param>
    /// <param name="method">The HTTP method (GET or POST).</param>
    /// <param name="hx">Optional HTMX configuration action.</param>
    /// <param name="configure">Optional field configuration action.</param>
    /// <returns>A <see cref="FormElement"/> containing all form fields, labels, and a submit button.</returns>
    public static FormElement AutoForm<TModel>(this TModel model, string action, MethodType method, Action<HtmxFormConfig>? hx, Action<FieldConfiguration<TModel>>? configure) where TModel : notnull
    {
        var config = new FieldConfiguration<TModel>();
        configure?.Invoke(config);

        var form = new FormElement();
        form.Action(action);
        form.Method(method.ToString().ToLowerInvariant());

        if (!string.IsNullOrEmpty(config.FormClass))
            form.Class(config.FormClass);
        if (!string.IsNullOrEmpty(config.FormId))
            form.Id(config.FormId);

        if (hx is not null)
        {
            var hxConfig = new HtmxFormConfig();
            hx.Invoke(hxConfig);
            if (!string.IsNullOrEmpty(hxConfig.Post))
                form.Attributes.Set("hx-post", hxConfig.Post);
            if (!string.IsNullOrEmpty(hxConfig.Get))
                form.Attributes.Set("hx-get", hxConfig.Get);
            if (!string.IsNullOrEmpty(hxConfig.Target))
                form.Attributes.Set("hx-target", hxConfig.Target);
            if (!string.IsNullOrEmpty(hxConfig.Swap))
                form.Attributes.Set("hx-swap", hxConfig.Swap);
            if (!string.IsNullOrEmpty(hxConfig.Indicator))
                form.Attributes.Set("hx-indicator", hxConfig.Indicator);
        }

        var properties = typeof(TModel).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead && p.GetIndexParameters().Length == 0);

        foreach (var prop in properties)
        {
            if (config.ExcludedProperties.Contains(prop.Name))
                continue;

            if (Attribute.IsDefined(prop, typeof(ScaffoldColumnAttribute)))
            {
                var scaffold = prop.GetCustomAttribute<ScaffoldColumnAttribute>()!;
                var visibleProp = scaffold.GetType().GetProperty("Visible");
                if (visibleProp?.GetValue(scaffold) is false)
                    continue;
            }

            var label = config.CustomLabels.TryGetValue(prop.Name, out var customLabel)
                ? customLabel
                : GetDisplayName(prop);

            var wrapper = new DivElement();
            wrapper.Class("mb-3");

            var labelElement = new LabelElement(label);
            labelElement.For(prop.Name);

            Node input;

            if (config.CustomOptions.TryGetValue(prop.Name, out var options))
            {
                input = CreateSelect(prop, options);
                labelElement.Class("form-label");
                wrapper.AddChild(labelElement);
                wrapper.AddChild(input);
            }
            else if (config.CustomInputTypes.TryGetValue(prop.Name, out var customType))
            {
                input = CreateInput(prop, customType);
                labelElement.Class("form-label");
                wrapper.AddChild(labelElement);
                wrapper.AddChild(input);
            }
            else
            {
                var inputType = DetermineInputType(prop);
                if (inputType == "checkbox")
                {
                    var checkWrapper = new DivElement();
                    checkWrapper.Class("form-check");
                    input = CreateInput(prop, inputType);
                    labelElement.Class("form-check-label");
                    checkWrapper.AddChild(input);
                    checkWrapper.AddChild(labelElement);
                    wrapper.AddChild(checkWrapper);
                }
                else
                {
                    input = CreateInputForProperty(prop);
                    labelElement.Class("form-label");
                    wrapper.AddChild(labelElement);
                    wrapper.AddChild(input);
                }
            }

            form.AddChild(wrapper);
        }

        var requiredType = method == MethodType.Post ? "submit" : "submit";
        var submitBtn = new ButtonElement(config.SubmitText);
        submitBtn.Type(requiredType);
        submitBtn.Class(config.SubmitClass);

        var submitWrapper = new DivElement();
        submitWrapper.Class("mt-3");
        submitWrapper.AddChild(submitBtn);
        form.AddChild(submitWrapper);

        return form;
    }

    private static Node CreateInputForProperty(PropertyInfo prop)
    {
        var inputType = DetermineInputType(prop);
        return CreateInput(prop, inputType);
    }

    private static Node CreateInput(PropertyInfo prop, string inputType)
    {
        if (inputType == "select")
        {
            var enumValues = Enum.GetNames(prop.PropertyType);
            var items = enumValues.Select(v => new SelectListItem { Text = v, Value = v }).ToArray();
            return CreateSelect(prop, items);
        }

        if (inputType == "textarea" || (inputType == "text" && IsLargeString(prop)))
        {
            return CreateTextArea(prop);
        }

        var input = new InputElement();
        input.Type(inputType);
        input.Name(prop.Name);
        input.Id(prop.Name);

        if (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?))
        {
            input.Class("form-check-input");
        }
        else
        {
            input.Class("form-control");
        }

        if (Attribute.IsDefined(prop, typeof(RequiredAttribute)))
            input.Required();

        var rangeAttr = prop.GetCustomAttribute<RangeAttribute>();
        if (rangeAttr is not null)
        {
            if (rangeAttr.Minimum is not null && rangeAttr.Minimum is IComparable min && Convert.ToDouble(min) > double.MinValue)
                input.Attributes.Set("min", Convert.ToString(min)!);
            if (rangeAttr.Maximum is not null && rangeAttr.Maximum is IComparable max && Convert.ToDouble(max) < double.MaxValue)
                input.Attributes.Set("max", Convert.ToString(max)!);
        }

        var stringLengthAttr = prop.GetCustomAttribute<StringLengthAttribute>();
        if (stringLengthAttr is not null && stringLengthAttr.MaximumLength > 0)
            input.Attributes.Set("maxlength", stringLengthAttr.MaximumLength.ToString());

        return input;
    }

    private static Node CreateSelect(PropertyInfo prop, SelectListItem[] items)
    {
        var select = new SelectElement();
        select.Name(prop.Name);
        select.Id(prop.Name);
        select.Class("form-select");

        if (Attribute.IsDefined(prop, typeof(RequiredAttribute)))
            select.Required();

        foreach (var item in items)
        {
            var option = new OptionElement(item.Text).Value(item.Value);
            if (item.Selected)
                option.Selected();
            select.AddChild(option);
        }

        return select;
    }

    private static Node CreateTextArea(PropertyInfo prop)
    {
        var textarea = new TextareaElement();
        textarea.Attributes.Set("name", prop.Name);
        textarea.Attributes.Set("id", prop.Name);
        textarea.Attributes.Set("rows", "4");
        textarea.Attributes.Set("class", "form-control");

        if (Attribute.IsDefined(prop, typeof(RequiredAttribute)))
            textarea.Required();

        var stringLengthAttr = prop.GetCustomAttribute<StringLengthAttribute>();
        if (stringLengthAttr is not null && stringLengthAttr.MaximumLength > 0)
            textarea.Attributes.Set("maxlength", stringLengthAttr.MaximumLength.ToString());

        return textarea;
    }

    private static string DetermineInputType(PropertyInfo prop)
    {
        var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

        if (type == typeof(bool))
            return "checkbox";

        if (type == typeof(DateTime))
        {
            var dataType = prop.GetCustomAttribute<DataTypeAttribute>();
            if (dataType?.DataType == DataType.Date)
                return "date";
            if (dataType?.DataType == DataType.DateTime)
                return "datetime-local";
            return "date";
        }

        if (type == typeof(DateOnly))
            return "date";

        if (type == typeof(TimeOnly))
            return "time";

        if (type == typeof(TimeSpan))
            return "time";

        if (type == typeof(int) || type == typeof(long) || type == typeof(short)
            || type == typeof(byte) || type == typeof(sbyte))
            return "number";

        if (type == typeof(decimal) || type == typeof(double) || type == typeof(float))
            return "number";

        if (type.IsEnum)
            return "select";

        if (type == typeof(string))
        {
            var dataType = prop.GetCustomAttribute<DataTypeAttribute>();
            if (dataType is not null)
            {
                return dataType.DataType switch
                {
                    DataType.EmailAddress => "email",
                    DataType.PhoneNumber => "tel",
                    DataType.Url => "url",
                    DataType.Password => "password",
                    DataType.MultilineText => "textarea",
                    _ => "text"
                };
            }

            if (Attribute.IsDefined(prop, typeof(EmailAddressAttribute)))
                return "email";

            if (Attribute.IsDefined(prop, typeof(PhoneAttribute)))
                return "tel";

            if (Attribute.IsDefined(prop, typeof(UrlAttribute)))
                return "url";

            return "text";
        }

        return "text";
    }

    private static bool IsLargeString(PropertyInfo prop)
    {
        if (prop.PropertyType != typeof(string))
            return false;

        var stringLength = prop.GetCustomAttribute<StringLengthAttribute>();
        if (stringLength is not null && stringLength.MaximumLength >= 500)
            return true;

        return Attribute.IsDefined(prop, typeof(DataTypeAttribute))
            && prop.GetCustomAttribute<DataTypeAttribute>()?.DataType == DataType.MultilineText;
    }

    private static string GetDisplayName(PropertyInfo prop)
    {
        var displayAttr = prop.GetCustomAttribute<DisplayAttribute>();
        if (displayAttr?.Name is not null)
            return displayAttr.Name;

        return prop.Name;
    }
}

/// <summary>
/// Configuration for HTMX attributes on an auto-generated form.
/// </summary>
public sealed class HtmxFormConfig
{
    /// <summary>
    /// Gets or sets the hx-post URL.
    /// </summary>
    public string? Post { get; set; }

    /// <summary>
    /// Gets or sets the hx-get URL.
    /// </summary>
    public string? Get { get; set; }

    /// <summary>
    /// Gets or sets the hx-target selector.
    /// </summary>
    public string? Target { get; set; }

    /// <summary>
    /// Gets or sets the hx-swap strategy.
    /// </summary>
    public string? Swap { get; set; }

    /// <summary>
    /// Gets or sets the hx-indicator selector.
    /// </summary>
    public string? Indicator { get; set; }

    /// <summary>
    /// Gets or sets the hx-trigger value.
    /// </summary>
    public string? Trigger { get; set; }

    /// <summary>
    /// Gets or sets the hx-confirm message.
    /// </summary>
    public string? Confirm { get; set; }
}
