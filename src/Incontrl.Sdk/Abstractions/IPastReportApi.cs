using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// Provides functionality for reporting services.
    /// </summary>
    public interface IPastReportApi
    {
        /// <summary>
        /// The subscription id.
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// Generates or updates a report for a subscription. This is a system call.
        /// </summary>
        /// <param name="frequency">The frequency of the report to create.</param>
        /// <param name="type">The type of report to create.</param>
        /// <param name="month">The month of the past report to generate.</param>
        /// <param name="year">The year of the past report to generate.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Report> CreateAsync(ReportingFrequency frequency, ReportType type, int month, int year, CancellationToken cancellationToken = default(CancellationToken));
    }
}
