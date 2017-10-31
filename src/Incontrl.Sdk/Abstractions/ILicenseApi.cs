using System.Threading.Tasks;

namespace Incontrl.Sdk.Abstractions
{
    public interface ILicenseApi
    {
        /// <summary>
        /// Retrieves InContrl's license information.
        /// </summary>
        Task<string> GetAsync();
    }
}
