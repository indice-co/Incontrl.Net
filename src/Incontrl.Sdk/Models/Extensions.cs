using System.Net;
using System.Net.Http;
using IdentityModel.Client;
using Incontrl.Sdk.Http;
using Indice.Types;

namespace Incontrl.Sdk.Models
{
    internal static class TokenResponseExtensions
    {
        internal static void HandleHttpError<TResponse>(this TokenResponse tokenResponse, JsonResponse<TResponse> httpResponse) => HandleHttpError(httpResponse);

        internal static void HandleHttpError<TResponse>(this HttpResponseMessage httpResponseMessage, JsonResponse<TResponse> httpResponse) => HandleHttpError(httpResponse);

        private static void HandleHttpError<TResponse>(JsonResponse<TResponse> httpResponse) {
            switch (httpResponse.HttpErrorStatusCode) {
                case HttpStatusCode.InternalServerError:
                    throw new IncontrlHttpInternalServerErrorException($"There was an error on our server. It's recorded and it will be fixed. Reason Phrase: {httpResponse.HttpErrorReason}");
                case HttpStatusCode.Forbidden:
                    throw new IncontrlHttpForbiddenException($"It seems that you have not access to this resource. Reason Phrase: {httpResponse.HttpErrorReason}");
                case HttpStatusCode.Unauthorized:
                    throw new IncontrlHttpUnauthorizedException($"It seems that your credentials are not correct. Reason Phrase: {httpResponse.HttpErrorReason}");
                case HttpStatusCode.BadRequest:
                    throw new IncontrlHttpBadRequestException(httpResponse.HttpErrorReason, httpResponse.Errors);
            }
        }
    }
}
