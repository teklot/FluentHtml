using FluentHtml.Nodes;

namespace FluentHtml.Components;

/// <summary>
/// A component that renders an inline <c>&lt;script&gt;</c> tag with the specified content.
/// </summary>
public sealed class InlineScriptComponent : Component
{
    private readonly string _scriptContent;

    /// <summary>
    /// Initializes a new instance of the <see cref="InlineScriptComponent"/> class.
    /// </summary>
    /// <param name="scriptContent">The JavaScript code to render inside the script tag.</param>
    public InlineScriptComponent(string scriptContent)
    {
        _scriptContent = scriptContent;
    }

    /// <inheritdoc/>
    public override Node Render()
    {
        return new RawHtml($"<script>{_scriptContent}</script>");
    }
}
