using FluentHtml.Components;
using FluentHtml.Elements;
using FluentHtml.Nodes;

namespace FluentHtml.Forms;

/// <summary>
/// An HTMX-powered drag-and-drop file upload zone component.
/// Renders a styled drop zone with a hidden file input, minimal inline JavaScript
/// for drag/drop events, and HTMX attributes for server-side file processing.
/// </summary>
public sealed class DragDropUploadComponent : Component
{
    private readonly string _uploadUrl;
    private readonly string _inputName;
    private readonly string _label;
    private string _accept = string.Empty;
    private string _dropZoneClass = "drag-drop-zone";
    private string? _hxTarget;
    private string _hxSwap = "innerHTML";

    /// <summary>
    /// Initializes a new instance of the <see cref="DragDropUploadComponent"/> class.
    /// </summary>
    /// <param name="uploadUrl">The server endpoint URL to POST files to.</param>
    /// <param name="inputName">The form field name for the file input.</param>
    /// <param name="label">The visible label text for the drop zone.</param>
    public DragDropUploadComponent(string uploadUrl, string inputName, string label = "Drop files here or click to browse")
    {
        _uploadUrl = uploadUrl;
        _inputName = inputName;
        _label = label;
    }

    /// <summary>
    /// Sets the accepted file types (e.g., ".jpg,.png,.pdf").
    /// </summary>
    /// <param name="accept">The comma-separated list of accepted file extensions.</param>
    /// <returns>The current <see cref="DragDropUploadComponent"/> for method chaining.</returns>
    public DragDropUploadComponent Accept(string accept)
    {
        _accept = accept;
        return this;
    }

    /// <summary>
    /// Sets the CSS class for the drop zone wrapper.
    /// </summary>
    /// <param name="cssClass">The CSS class(es).</param>
    /// <returns>The current <see cref="DragDropUploadComponent"/> for method chaining.</returns>
    public DragDropUploadComponent DropZoneClass(string cssClass)
    {
        _dropZoneClass = cssClass;
        return this;
    }

    /// <summary>
    /// Sets the hx-target attribute for the upload response.
    /// </summary>
    /// <param name="target">The CSS selector for the target element.</param>
    /// <returns>The current <see cref="DragDropUploadComponent"/> for method chaining.</returns>
    public DragDropUploadComponent Target(string target)
    {
        _hxTarget = target;
        return this;
    }

    /// <summary>
    /// Sets the hx-swap strategy.
    /// </summary>
    /// <param name="swap">The swap strategy (e.g., "innerHTML", "outerHTML", "beforeend").</param>
    /// <returns>The current <see cref="DragDropUploadComponent"/> for method chaining.</returns>
    public DragDropUploadComponent Swap(string swap)
    {
        _hxSwap = swap;
        return this;
    }

    /// <inheritdoc/>
    public override Node Render()
    {
        var inputId = $"{_inputName}-file-input";

        var wrapper = new DivElement();
        wrapper.Class(_dropZoneClass);
        wrapper.Custom("hx-post", _uploadUrl);
        wrapper.Custom("hx-encoding", "multipart/form-data");
        wrapper.Custom("hx-trigger", "drop");
        wrapper.Custom("hx-swap", _hxSwap);

        if (!string.IsNullOrEmpty(_hxTarget))
            wrapper.Custom("hx-target", _hxTarget);

        var acceptAttr = string.IsNullOrEmpty(_accept) ? "" : $" accept=\"{_accept}\"";
        var acceptFilter = string.IsNullOrEmpty(_accept) ? "''" : $"'{_accept}'";

        var script = $@"
<script>
(function() {{
    var dz = document.currentScript.parentElement;
    var fi = document.getElementById('{inputId}');
    var dragText = dz.querySelector('.drag-drop-text');

    dz.addEventListener('dragover', function(e) {{
        e.preventDefault();
        dz.classList.add('drag-drop-over');
    }});

    dz.addEventListener('dragleave', function(e) {{
        e.preventDefault();
        dz.classList.remove('drag-drop-over');
    }});

    dz.addEventListener('drop', function(e) {{
        e.preventDefault();
        dz.classList.remove('drag-drop-over');
        if (e.dataTransfer.files.length > 0) {{
            fi.files = e.dataTransfer.files;
            fi.dispatchEvent(new Event('change'));
            htmx.trigger(dz, 'drop', {{ files: e.dataTransfer.files }});
        }}
    }});

    dz.addEventListener('click', function() {{
        fi.click();
    }});

    fi.addEventListener('change', function() {{
        if (fi.files.length > 0) {{
            var names = Array.from(fi.files).map(function(f) {{ return f.name; }}).join(', ');
            if (dragText) dragText.textContent = names;
        }}
    }});
}})();
</script>";

        var hiddenInput = $"<input type=\"file\" id=\"{inputId}\" name=\"{_inputName}\" style=\"display:none\"{acceptAttr} />";

        var labelDiv = new DivElement();
        labelDiv.Class("drag-drop-label");
        var iconSpan = new SpanElement("📁");
        iconSpan.Class("drag-drop-icon");
        var textSpan = new SpanElement(_label);
        textSpan.Class("drag-drop-text");
        labelDiv.AddChild(iconSpan);
        labelDiv.AddChild(textSpan);

        wrapper.AddChild(labelDiv);
        wrapper.AddChild(new RawHtml(hiddenInput));
        wrapper.AddChild(new RawHtml(script));

        return wrapper;
    }
}

/// <summary>
/// Factory methods for creating <see cref="DragDropUploadComponent"/> instances.
/// </summary>
public static class DragDropUploadExtensions
{
    /// <summary>
    /// Creates a new drag-and-drop file upload zone.
    /// </summary>
    /// <param name="uploadUrl">The server endpoint URL to POST files to.</param>
    /// <param name="inputName">The form field name for the file input.</param>
    /// <param name="label">The visible label text. Defaults to "Drop files here or click to browse".</param>
    /// <returns>A new <see cref="DragDropUploadComponent"/> instance.</returns>
    public static DragDropUploadComponent DragDropUpload(string uploadUrl, string inputName, string label = "Drop files here or click to browse")
    {
        return new DragDropUploadComponent(uploadUrl, inputName, label);
    }
}
