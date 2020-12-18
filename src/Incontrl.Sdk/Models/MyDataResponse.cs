using System;
using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class MyDataResponse
    {
        public string Uuid { get; set; }
        public string Mark { get; set; }
        public string AuthenticationCode { get; set; }
        public DateTimeOffset? SynchronizationDate { get; set; }
        public List<ErrorResult> ErrorDetails { get; set; } = new List<ErrorResult>();
        public bool HasErrors => ErrorDetails?.Count > 0;
    }

    public class MyDataResult
    {
        public string Mark { get; set; }
        public string Uuid { get; set; }
        public DateTimeOffset MarkDate { get; set; }
    }

    public class ErrorResult
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
