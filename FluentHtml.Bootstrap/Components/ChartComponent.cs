using FluentHtml.Components;
using FluentHtml.Elements;
using FluentHtml.Nodes;
using System.Text;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// Supported Chart.js chart types.
/// </summary>
public enum ChartType
{
    /// <summary>A bar chart.</summary>
    Bar,
    /// <summary>A line chart.</summary>
    Line,
    /// <summary>A pie chart.</summary>
    Pie,
    /// <summary>A doughnut chart.</summary>
    Doughnut,
    /// <summary>A radar chart.</summary>
    Radar,
    /// <summary>A polar area chart.</summary>
    PolarArea
}

/// <summary>
/// A component that renders a Chart.js chart with a canvas element and inline initialization script.
/// </summary>
public sealed class ChartComponent : Component
{
    private readonly string _canvasId;
    private readonly ChartType _chartType;
    private readonly List<double[]> _datasets = [];
    private readonly List<string> _datasetLabels = [];
    private readonly List<string> _datasetColors = [];
    private readonly List<string> _labels = [];
    private string _title = string.Empty;
    private int _height = 400;
    private bool _responsive = true;
    private string _chartJsVersion = "4.4.7";

    /// <summary>
    /// Initializes a new instance of the <see cref="ChartComponent"/> class.
    /// </summary>
    /// <param name="canvasId">The HTML ID for the canvas element.</param>
    /// <param name="chartType">The Chart.js chart type.</param>
    public ChartComponent(string canvasId, ChartType chartType)
    {
        _canvasId = canvasId;
        _chartType = chartType;
    }

    /// <summary>
    /// Sets the chart data (single dataset).
    /// </summary>
    /// <param name="data">The numeric data points.</param>
    /// <returns>The current <see cref="ChartComponent"/> for method chaining.</returns>
    public ChartComponent Data(double[] data)
    {
        _datasets.Clear();
        _datasets.Add(data);
        return this;
    }

    /// <summary>
    /// Adds a named dataset (for multi-series charts).
    /// </summary>
    /// <param name="label">The dataset label.</param>
    /// <param name="data">The numeric data points.</param>
    /// <returns>The current <see cref="ChartComponent"/> for method chaining.</returns>
    public ChartComponent Dataset(string label, double[] data)
    {
        _datasetLabels.Add(label);
        _datasets.Add(data);
        return this;
    }

    /// <summary>
    /// Sets the border/background color for the most recently added dataset.
    /// </summary>
    /// <param name="color">A CSS color value (e.g., "red", "#ff0000", "rgba(255,0,0,0.5)").</param>
    /// <returns>The current <see cref="ChartComponent"/> for method chaining.</returns>
    public ChartComponent DatasetColor(string color)
    {
        if (_datasetColors.Count < _datasets.Count)
            _datasetColors.Add(color);
        else if (_datasetColors.Count > 0)
            _datasetColors[^1] = color;
        return this;
    }

    /// <summary>
    /// Sets the chart labels (x-axis for bar/line, slice labels for pie/doughnut).
    /// </summary>
    /// <param name="labels">The label strings.</param>
    /// <returns>The current <see cref="ChartComponent"/> for method chaining.</returns>
    public ChartComponent Labels(string[] labels)
    {
        _labels.Clear();
        _labels.AddRange(labels);
        return this;
    }

    /// <summary>
    /// Sets the chart title.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <returns>The current <see cref="ChartComponent"/> for method chaining.</returns>
    public ChartComponent Title(string title)
    {
        _title = title;
        return this;
    }

    /// <summary>
    /// Sets the chart height in pixels.
    /// </summary>
    /// <param name="height">The height in pixels.</param>
    /// <returns>The current <see cref="ChartComponent"/> for method chaining.</returns>
    public ChartComponent Height(int height)
    {
        _height = height;
        return this;
    }

    /// <summary>
    /// Sets whether the chart is responsive.
    /// </summary>
    /// <param name="responsive">True to enable responsiveness.</param>
    /// <returns>The current <see cref="ChartComponent"/> for method chaining.</returns>
    public ChartComponent Responsive(bool responsive = true)
    {
        _responsive = responsive;
        return this;
    }

    /// <inheritdoc/>
    public override Node Render()
    {
        var wrapper = new DivElement();
        wrapper.Style($"height: {_height}px;");

        var canvas = new CanvasElement();
        canvas.Id(_canvasId);
        wrapper.AddChild(canvas);

        var scriptContent = BuildScript();
        wrapper.AddChild(new RawHtml(scriptContent));

        return wrapper;
    }

    private string BuildScript()
    {
        var sb = new StringBuilder();

        sb.Append($"<script src=\"https://cdn.jsdelivr.net/npm/chart.js@{_chartJsVersion}\"></script>");
        sb.Append("<script>");
        sb.Append("(function(){");

        sb.Append($"var ctx=document.getElementById('{_canvasId}').getContext('2d');");

        var typeStr = _chartType.ToString().ToLowerInvariant();

        sb.Append("new Chart(ctx,{");

        sb.Append($"type:'{typeStr}',");

        sb.Append("data:{");

        if (_labels.Count > 0)
        {
            sb.Append("labels:[");
            for (var i = 0; i < _labels.Count; i++)
            {
                if (i > 0) sb.Append(',');
                sb.Append($"'{EscapeJs(_labels[i])}'");
            }
            sb.Append("],");
        }

        sb.Append("datasets:[");
        for (var i = 0; i < _datasets.Count; i++)
        {
            if (i > 0) sb.Append(',');
            sb.Append('{');

            if (i < _datasetLabels.Count)
                sb.Append($"label:'{EscapeJs(_datasetLabels[i])}',");

            sb.Append("data:[");
            for (var j = 0; j < _datasets[i].Length; j++)
            {
                if (j > 0) sb.Append(',');
                sb.Append(_datasets[i][j]);
            }
            sb.Append(']');

            if (i < _datasetColors.Count)
            {
                var color = _datasetColors[i];
                if (_chartType is ChartType.Line or ChartType.Radar)
                    sb.Append($",borderColor:'{EscapeJs(color)}',tension:0.1");
                else
                    sb.Append($",backgroundColor:'{EscapeJs(color)}'");
            }

            sb.Append('}');
        }
        sb.Append("]},");

        sb.Append("options:{");
        sb.Append($"responsive:{_responsive.ToString().ToLowerInvariant()}");

        if (!string.IsNullOrEmpty(_title))
        {
            sb.Append(",plugins:{title:{display:true,text:'");
            sb.Append(EscapeJs(_title));
            sb.Append("'}}");
        }

        sb.Append("}});");
        sb.Append("})();");
        sb.Append("</script>");

        return sb.ToString();
    }

    private static string EscapeJs(string value)
    {
        return value.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\n", "\\n").Replace("\r", "\\r");
    }
}

/// <summary>
/// Factory methods for creating <see cref="ChartComponent"/> instances.
/// </summary>
public static class ChartExtensions
{
    /// <summary>
    /// Creates a new <see cref="ChartComponent"/> with the specified canvas ID and chart type.
    /// </summary>
    /// <param name="canvasId">The HTML ID for the canvas element.</param>
    /// <param name="chartType">The Chart.js chart type.</param>
    /// <returns>A new <see cref="ChartComponent"/> instance.</returns>
    public static ChartComponent Chart(string canvasId, ChartType chartType) => new(canvasId, chartType);
}
