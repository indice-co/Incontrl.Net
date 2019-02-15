using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// Provides functionality for reporting services.
    /// </summary>
    public interface IReportApi
    {
        /// <summary>
        /// The subscription id.
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// Generates or updates a report for a subscription. This is a system call.
        /// </summary>
        /// <param name="frequency">The frequency the of report to create or update.</param>
        /// <param name="type">The type of the report.</param>
        /// <param name="document">The document that was created and will be included in the report.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Report> UpsertAsync(ReportingFrequency frequency, ReportType type, Document document, CancellationToken cancellationToken = default(CancellationToken));
    }
}
