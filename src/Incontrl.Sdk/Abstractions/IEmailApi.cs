using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// An interface that provides functionality to send email messages.
    /// </summary>
    public interface IEmailApi
    {
        /// <summary>
        /// Sends an email message.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SendAsync(EmailRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
