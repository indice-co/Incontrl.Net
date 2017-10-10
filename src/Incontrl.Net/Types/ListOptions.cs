using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Incontrl.Net.Types
{
    public class ListOptions
    {
        public class Sorting
        {
            const string ASC = nameof(ASC);
            const string DESC = nameof(DESC);
            public string Path { get; set; }
            public string Direction { get; set; }

            public override string ToString() {
                return $"{Path} ({Direction})";
            }

            public Sorting NextState() {
                switch (Direction) {
                    case ASC:
                        return new Sorting { Direction = DESC, Path = Path };
                    case DESC:
                        return null;
                    default:
                        throw new Exception($"unexpected direction {Direction}");
                }
            }

            public static Sorting Parse(string text) {
                if (string.IsNullOrWhiteSpace(text)) {
                    throw new ArgumentOutOfRangeException(nameof(text));
                }
                var raw = text.Trim();
                var sort = new Sorting {
                    Path = raw.TrimEnd('-', '+'),
                    Direction = raw.EndsWith("-", StringComparison.OrdinalIgnoreCase) ? DESC : ASC
                };
                return sort;
            }
        }

        public ListOptions() {
            Page = 1;
            Size = 100;
            Sort = string.Empty;
        }

        public int Page { get; set; }
        public int Size { get; set; }
        public string Sort { get; set; }
        public string Search { get; set; }

        public IEnumerable<Sorting> GetSortings() {
            var list = (Sort ?? string.Empty).Split(',');
            foreach (var item in list) {
                if (string.IsNullOrWhiteSpace(item)) {
                    continue;
                }
                yield return Sorting.Parse(item);
            }
        }

        public virtual IDictionary<string, object> ToDictionary() {
            var dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase) {
                { nameof(Page).ToLower(), Page.ToString() },
                { nameof(Size).ToLower(), Size.ToString() },
            };
            if (!string.IsNullOrWhiteSpace(Sort))
                dictionary.Add(nameof(Sort).ToLower(), Sort);
            if (!string.IsNullOrWhiteSpace(Search))
                dictionary.Add(nameof(Search).ToLower(), Search);
            return dictionary;
        }
    }

    public class ListOptions<TFilter> : ListOptions where TFilter : class, new()
    {
        public ListOptions() : base() {
            Filter = new TFilter();
        }

        public TFilter Filter { get; set; }

        public override IDictionary<string, object> ToDictionary() {
            var dictionary = base.ToDictionary();

            return dictionary.Merge(Filter, typeof(TFilter), "filter.");
        }


    }

    public static class ListOptionsExtensions
    {
        public static IDictionary<string, object> ToDictionary<TReplacements>(this ListOptions options, TReplacements replacements) where TReplacements : class {
            if (null == replacements)
                throw new ArgumentNullException(nameof(replacements));
            var overrides = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase).Merge(replacements, typeof(TReplacements));
            var sortings = options.GetSortings();
            var sortKey = nameof(options.Sort).ToLower();
            if (overrides.ContainsKey(sortKey)) {
                var sort = overrides[sortKey].ToString();
                if (sortings.Any(s => s.Path.Equals(sort))) {
                    overrides[sortKey] = sortings.Select(s => s.Path.Equals(sort) ? s.NextState() : s).Where(s => s != null).ToUriString();
                } else {
                    overrides[sortKey] = sortings.Union(new[] { ListOptions.Sorting.Parse(sort) }).ToUriString();
                }
            }

            // now replace accordingly.
            return options.ToDictionary().Merge(overrides, null);
        }
        public static IDictionary<string, object> Merge(this IDictionary<string, object> dictionary, object instance, Type type = null, string prefix = null) {
            if (instance is IDictionary<string, object>) {
                var other = instance as IDictionary<string, object>;
                foreach (var keyValue in other) {
                    if (dictionary.ContainsKey(keyValue.Key))
                        dictionary[keyValue.Key] = keyValue.Value;
                    else
                        dictionary.Add(keyValue.Key, keyValue.Value);
                }
                return dictionary;
            }
            type = type ?? instance?.GetType();
            foreach (var prop in type.GetRuntimeProperties()) {
                var value = prop.GetValue(instance);
                if (value != null) {
                    var textValue = GetStructValue(prop.PropertyType, value);
                    var key = $"{prefix}{prop.Name}";
                    if (!string.IsNullOrEmpty(textValue)) {
                        if (dictionary.ContainsKey(key))
                            dictionary[key] = textValue;
                        else
                            dictionary.Add(key, textValue);
                        continue;
                    }
                    var itemType = default(Type);
                    if (prop.PropertyType.IsArray ||
                        (itemType = prop.PropertyType.GetElementType()) != null) {
                        var array = ((IEnumerable)value).Cast<object>().Select(i => GetStructValue(itemType ?? i.GetType(), i)).ToArray();
                        if (dictionary.ContainsKey(key))
                            dictionary[key] = array;
                        else
                            dictionary.Add(key, array);
                    }
                }
            }
            return dictionary;
        }

        public static string ToUriString(this IEnumerable<ListOptions.Sorting> source) {
            return string.Join(",", source.Select(s => $"{s.Path}{(s.Direction == "DESC" ? "-" : "")}"));
        }


        private static string GetStructValue(Type type, object value) {
            var textValue = string.Empty;
            if (type == typeof(DateTime?) && ((DateTime?)value).HasValue) {
                textValue = ((DateTime?)value).Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            } else if (type == typeof(DateTime) && ((DateTime)value) != default(DateTime)) {
                textValue = ((DateTime)value).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            } else if (
                type == typeof(string) ||
                type == typeof(int) ||
                type == typeof(int?) ||
                type == typeof(decimal) ||
                type == typeof(decimal?) ||
                type == typeof(double) ||
                type == typeof(double?) ||
                type == typeof(Guid) ||
                type == typeof(Guid?) ||
                type.GetTypeInfo().IsEnum ||
#if NETSTANDARD14
                Nullable.GetUnderlyingType(type)?.GetTypeInfo().IsEnum == true) {
#else
                Nullable.GetUnderlyingType(type)?.IsEnum == true) {
#endif
                textValue = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", value);
            }
            return textValue;
        }



        public static IEnumerable<KeyValuePair<string, string>> AsRouteValues(this IDictionary<string, object> values) {
            return values.SelectMany(kv => {
                if (kv.Value == null)
                    return null;
                if (kv.Value.GetType().IsArray) {
                    if (kv.Key.ToLowerInvariant() == nameof(ListOptions.Sort).ToLowerInvariant())
                        return new[] { new KeyValuePair<string, string>(kv.Key, string.Join(",", (IList)kv.Value)) };

                    return ((IList)kv.Value).Cast<object>().Select(x => new KeyValuePair<string, string>(kv.Key, x?.ToString()));
                }
                return new[] { new KeyValuePair<string, string>(kv.Key, kv.Value.ToString()) };
            });
        }



        public static string ToFormUrlEncodedString(this IDictionary<string, object> values) {
            var parameters = values.AsRouteValues();
            return string.Join("&", parameters.Select(kv => $"{kv.Key}={kv.Value}"));
        }
    }
}