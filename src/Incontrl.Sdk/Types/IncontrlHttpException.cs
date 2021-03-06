﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Indice.Types
{
    public class IncontrlHttpException : Exception
    {
        public IncontrlHttpException(string message) : base(message) { }
    }

    public class IncontrlHttpInternalServerErrorException : IncontrlHttpException
    {
        public IncontrlHttpInternalServerErrorException(string message) : base(message) { }
    }

    public class IncontrlHttpForbiddenException : IncontrlHttpException
    {
        public IncontrlHttpForbiddenException(string message) : base(message) { }
    }

    public class IncontrlHttpUnauthorizedException : IncontrlHttpException
    {
        public IncontrlHttpUnauthorizedException(string message) : base(message) { }
    }

    public class IncontrlHttpBadRequestException : IncontrlHttpException
    {
        public string[] Errors { get; }

        public IncontrlHttpBadRequestException(string message, IEnumerable<string> errors) : base(message) => Errors = errors.ToArray();
    }
}
