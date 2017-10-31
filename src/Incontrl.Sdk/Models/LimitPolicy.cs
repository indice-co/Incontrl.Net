using System;
using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class LimitPolicy
    {
        public string Name { get; set; }
        public List<LimitRule> Rules { get; set; }
    }

    public class LimitRule
    {
        /// <summary>
        /// HTTP verb and path 
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Rate limit period as in 1s, 1m, 1h.
        /// </summary>
        public string Period { get; set; }

        public TimeSpan? PeriodTimespan { get; set; }

        /// <summary>
        /// Maximum number of requests that a client can make in a defined period.
        /// </summary>
        public long Limit { get; set; }
    }
}
