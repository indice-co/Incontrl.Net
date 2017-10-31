using System.Collections.Generic;
using System.Linq;

namespace Incontrl.Sdk.Types
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

    public class ResultSet<T, TSummary> : ResultSet<T>
    {
        public ResultSet() : base() { }

        public ResultSet(IEnumerable<T> collection, int totalCount, TSummary summary) : base(collection, totalCount) => Summary = summary;

        public TSummary Summary { get; set; }
    }
}