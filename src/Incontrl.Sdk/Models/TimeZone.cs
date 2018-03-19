using System;

namespace Incontrl.Sdk.Models
{
    public class TimeZone
    {
        /// <summary>
        /// Gets the time difference between the current time zone's standard time and Coordinated Universal Time (UTC).
        /// </summary>
        public TimeSpan BaseUtcOffset { get; set; }

        /// <summary>
        /// Gets the time zone identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the display name for the time zone's standard time.
        /// </summary>
        public string StandardName { get; set; }

        /// <summary>
        /// Gets the display name for the time zone's dayight time.
        /// </summary>
        public string DaylightName { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CountryCode { get; set; }
        public string DisplayName { get; set; }
    }
}
