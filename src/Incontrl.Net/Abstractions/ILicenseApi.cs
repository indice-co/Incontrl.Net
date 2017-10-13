using System.Threading.Tasks;

namespace Incontrl.Net.Abstractions
{
    public interface ILicenseApi
    {
        /// <summary>
        /// Retrieves InContrl's license information.
        /// </summary>
        Task<string> GetAsync();
    }
}
