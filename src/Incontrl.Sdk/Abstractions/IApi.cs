using System;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface IApi
    {
        /// <summary>
        /// The Uri of the API.
        /// </summary>
        Uri ApiAddress { get; }

        /// <summary>
        /// Login by using your credentials as a user.
        /// </summary>
        /// <param name="userName">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="scopes">The scopes of the API to request.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task LoginAsync(string userName, string password, ScopeFlags scopes = ScopeFlags.Core);

        /// <summary>
        /// Login by using your client credentials.
        /// </summary>
        /// <param name="scopes">The scopes of the API to request.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task LoginAsync(ScopeFlags scopes = ScopeFlags.Core);

        /// <summary>
        /// Login by using a refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token to use.</param>
        /// <param name="scopes">The scopes of the API to request.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task LoginAsync(string refreshToken, ScopeFlags scopes = ScopeFlags.Core);
    }
}
