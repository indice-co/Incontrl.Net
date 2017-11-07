using System;

namespace Incontrl.Sdk.Abstractions
{
    public interface IClientsApi : IApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IAppsApi Apps();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        IAppApi App(Guid appId);
    }
}
