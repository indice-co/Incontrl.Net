using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Incontrl.Net.Types
{
    public class ResultSet<T>
    {
        public ResultSet() { }

        public ResultSet(IEnumerable<T> collection, int totalCount) {
            Items = (collection ?? new T[0]).ToArray();
            Count = totalCount;
        }

        public int Count { get; set; }

        public T[] Items { get; set; }
    }
}