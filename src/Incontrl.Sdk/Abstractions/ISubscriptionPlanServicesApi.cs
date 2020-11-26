using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// Contains operations to modify the properties of a specified service.
    /// </summary>
    public interface ISubscriptionPlanServicesApi
    {
        /// <summary>
        /// The id of the subscription.
        /// </summary>
        string SubscriptionId { get; set; }
        /// <summary>
        /// The id of the service.
        /// </summary>
        string ServiceId { get; set; }
        /// <summary>
        /// Updates the properties of a specified service based on the <see cref="UpdateServiceRequest"/> model.
        /// </summary>
        /// <param name="request">Models a request to update a service.</param>
        /// <param name="cancellationToken">Returns the task object representing the asynchronous operation.</param>
        Task<Service> UpdateAsync(UpdateServiceRequest request, CancellationToken cancellationToken = default);
    }
}
