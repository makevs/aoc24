using System.Text.RegularExpressions;

namespace CommonUtils;

public static partial class RegexHelper
{
    [GeneratedRegex(@"\s+")]
    public static partial Regex RemoveWhitespaces();
}