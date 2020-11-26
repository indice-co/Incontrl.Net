using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISubscriptionPlanApi
    {
        /// <summary>
        /// The id of the subscription.
        /// </summary>
        string SubscriptionId { get; set; }
        /// <summary>
        /// Provides access to modify the properties of a specified service.
        /// </summary>
        /// <param name="serviceId">The id of the service.</param>
        ISubscriptionPlanServicesApi Services(Guid serviceId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken">Returns the task object representing the asynchronous operation.</param>
        Task<Plan> GetAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">Returns the task object representing the asynchronous operation.</param>
        Task<Plan> UpdateAsync(Plan request, CancellationToken cancellationToken = default);
    }
}
