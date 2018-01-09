using System;

namespace Incontrl.Sdk.Models
{
    public class Period
    {
        public DateTimeOffset? From { get; set; }
        public DateTimeOffset? To { get; set; }

        public override string ToString() => $"{From:d} - {To:d}";
    }
}
