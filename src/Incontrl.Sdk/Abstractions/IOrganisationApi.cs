using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface IOrganisationApi
    {
        string SubscriptionId { get; set; }
        string OrganisationId { get; set; }

        /// <summary>
        /// Gets an organisation's information by it's unique id.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Organisation> GetAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an organisation's information.
        /// </summary>
        /// <param name="request">An object of type <see cref="UpdateOrganisationRequest"/> that contains information about the organisation to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Organisation> UpdateAsync(UpdateOrganisationRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an organisation's information.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task DeleteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the organization logo.
        /// </summary>
        /// <param name="fileContent">The contents of the template file.</param>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Link> LogoUploadAsync(Stream fileContent, string fileName, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Updates the organization logo url with an external absolute link.
        /// </summary>
        /// <param name="absoluteUri">The absolute link</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Link> LogoSetUriAsync(Uri absoluteUri, CancellationToken cancellationToken = default);
    }
}
