using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// A dictionary for translation objects.
    /// </summary>
    /// <typeparam name="T">The object parameter.</typeparam>
    public class TranslationDictionary<T> : Dictionary<string, T> { }
}
