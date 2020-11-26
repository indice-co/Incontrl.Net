using System;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// Represents a service that a subscription owns.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Class.
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// Determines if the service is enabled.
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// UI hint.
        /// </summary>
        public UiHint UiHint { get; set; }
        /// <summary>
        /// Settings
        /// </summary>
        public dynamic Settings { get; set; }
        /// <summary>
        /// Settings schema.
        /// </summary>
        public object SettingsSchema { get; set; }
        /// <summary>
        /// Service type.
        /// </summary>
        public ServiceType Type { get; set; }
    }

    /// <summary>
    /// The type of the service.
    /// </summary>
    public enum ServiceType
    {
        /// <summary>
        /// Reconciliation service.
        /// </summary>
        Reconciliation = 1,
        /// <summary>
        /// Reconciliation service.
        /// </summary>
        WebHooks,
        /// <summary>
        /// Payment option service.
        /// </summary>
        PaymentOption,
        /// <summary>
        /// Trial service.
        /// </summary>
        Trial,
        /// <summary>
        /// Reporting service.
        /// </summary>
        Reporting,
        /// <summary>
        /// Metrics service.
        /// </summary>
        Metrics,
        /// <summary>
        /// AADE myData service.
        /// </summary>
        AadeMyData
    }
}
