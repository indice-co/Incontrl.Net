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
        /// Generates a report for a subscription in a defined period. This is a system call.
        /// </summary>
        /// <param name="period">The period to consider for reporting.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Report> GenerateAsync(Period period, CancellationToken cancellationToken = default(CancellationToken));
    }
}
