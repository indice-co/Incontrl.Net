using System.Threading.Tasks;
using Incontrl.Net.Http;

namespace Incontrl.Net.Abstract
{
    public interface ILicenseApi
    {
        Task<JsonResponse<string>> GetAsync();
    }
}
