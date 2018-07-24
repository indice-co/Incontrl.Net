using System;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// Represents a chronological period.
    /// </summary>
    public class Period
    {
        /// <summary>
        /// Period starting date.
        /// </summary>
        public DateTimeOffset? From { get; set; }

        /// <summary>
        /// Period ending date.
        /// </summary>
        public DateTimeOffset? To { get; set; }

        /// <summary>
        /// String representation of the period.
        /// </summary>
        /// <returns></returns>

        public override string ToString() => $"{From:d} - {To:d}";
    }
}
