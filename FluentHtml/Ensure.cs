using System.Diagnostics.CodeAnalysis;

namespace FluentHtml;

/// <summary>
/// Lightweight guard class for validating fluent API method arguments.
/// </summary>
internal static class Ensure
{
    /// <summary>
    /// Ensures the specified value is not null.
    /// </summary>
    public static void NotNull([NotNull] string? value, string paramName)
    {
        ArgumentNullException.ThrowIfNull(value, paramName);
    }

    /// <summary>
    /// Ensures the specified value is not null, empty, or whitespace.
    /// </summary>
    public static void NotNullOrWhiteSpace([NotNull] string? value, string paramName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, paramName);
    }

    /// <summary>
    /// Ensures the specified value is not null or empty.
    /// </summary>
    public static void NotEmpty([NotNull] string? value, string paramName)
    {
        ArgumentException.ThrowIfNullOrEmpty(value, paramName);
    }
}
