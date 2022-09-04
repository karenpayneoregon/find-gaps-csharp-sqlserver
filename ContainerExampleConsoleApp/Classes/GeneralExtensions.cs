using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ContainerExampleConsoleApp.Classes;

internal static class GeneralExtensions
{
    /// <summary>
    /// Join string array with " and " as the last delimiter.
    /// </summary>
    /// <param name="sender">String array to convert to delimited string</param>
    /// <returns>Delimited string</returns>
    [DebuggerStepThrough]
    public static string JoinWithLastSeparator(this int[] sender)
        => string.Join(", ", sender.Take(sender.Length - 1)) + (((sender.Length <= 1) ? "" : " and ") +
                                                                sender.LastOrDefault());

    [DebuggerStepThrough]
    public static string ToYesNoString(this bool value) => (value ? "Yes" : "No");

    [DebuggerStepThrough]
    public static string Colorize(this string sender) 
        => sender.Replace(",", "[plum1],[/]").Replace("and", "[plum1]and[/]");

    /// <summary>
    /// Use to split on upper cased characters and separate with a single space.
    /// </summary>
    [DebuggerStepThrough]
    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", Regex.Matches(sender, @"([A-Z][a-z]+)")
            .Select(m => m.Value));
}