namespace Incontrl.Sdk.Abstractions
{
    public interface IClientsApi : IApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiAddress"></param>
        /// <param name="authorityAddress"></param>
        /// <returns></returns>
        IClientsApi Configure(string apiAddress, string authorityAddress = null);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IAppsApi Apps();
    }
}
