using System;
using System.Collections.Generic;
using System.Linq;

namespace Incontrl.Net.Types
{
    /// <summary>
    /// 
    /// </summary>
    public class IncontrlHttpException : Exception
    {
        public IncontrlHttpException(string message) : base(message) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IncontrlHttpForbiddenException : IncontrlHttpException
    {
        public IncontrlHttpForbiddenException(string message) : base(message) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IncontrlHttpUnauthorizedException : IncontrlHttpException
    {
        public IncontrlHttpUnauthorizedException(string message) : base(message) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IncontrlHttpBadRequestException : IncontrlHttpException
    {
        public string[] Errors { get; }

        public IncontrlHttpBadRequestException(string message, IEnumerable<string> errors) : base(message) {
            Errors = errors.ToArray();
        }
    }
}
