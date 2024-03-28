using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// Provides functionality for reporting services.
    /// </summary>
    public interface IReportsApi
    {
        /// <summary>
        /// Lists all services that have to generate reports. This is a system call.
        /// </summary>
        /// <param name="type">The <see cref="ReportType"/> of the report.</param>
        /// <param name="frequency">The <see cref="ReportingFrequency"/> of the report.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Subscription[]> ListAsync(ReportType type, ReportingFrequency? frequency, CancellationToken cancellationToken = default);
    }
}
