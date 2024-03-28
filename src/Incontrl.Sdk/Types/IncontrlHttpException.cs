using System;
using System.Collections.Generic;
using System.Linq;

namespace Indice.Types
{
    public class IncontrlHttpException(string message) : Exception(message)
    {
    }

    public class IncontrlHttpInternalServerErrorException(string message) : IncontrlHttpException(message)
    {
    }

    public class IncontrlHttpForbiddenException(string message) : IncontrlHttpException(message)
    {
    }

    public class IncontrlHttpUnauthorizedException(string message) : IncontrlHttpException(message)
    {
    }

    public class IncontrlHttpBadRequestException(string message, IEnumerable<string> errors) : IncontrlHttpException(message)
    {
        public string[] Errors { get; } = errors.ToArray();
    }
}
