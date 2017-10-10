using System.Threading.Tasks;
using Incontrl.Net.Http;

namespace Incontrl.Net.Abstractions
{
    public interface ILicenseApi
    {
        Task<string> GetAsync();
    }
}
