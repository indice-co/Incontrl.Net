using System;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum ScopeFlags
    {
        Core = 1,
        Members = 2,
        Banking = 4,
        Identity = 8,
        Apps = 16
    }

    public static class ScopeFlagsExtensions
    {
        public static string ToScopesText(this ScopeFlags scopes)  =>
            $"core:{scopes}".ToLowerInvariant()
                            .Replace(", ", $" core:")
                            .Replace("core:core", "core")
                            .Replace("core:identity", "identity");
    }
}
