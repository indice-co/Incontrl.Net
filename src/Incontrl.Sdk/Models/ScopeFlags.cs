using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// The available scopes to request.
    /// </summary>
    [Flags]
    public enum ScopeFlags
    {
        Core = 1,
        CoreMembers = 2,
        CoreBanking = 4,
        CoreGlobal_metrics = 8,
        Identity = 16,
        IdentityApps = 32,
        IdentityUsers = 64
    }

    internal static class ScopeFlagsExtensions
    {
        public static string ToScopesText(this ScopeFlags scopes) => string.Join(" ", $"{scopes}".Split(',').Select(x => x.ToScopeCase()));

        private static string ToScopeCase(this string input) => Regex.Replace(input, "[a-z][A-Z]", m => $"{m.Value[0]}:{char.ToLowerInvariant(m.Value[1])}").ToLowerInvariant();
    }
}
