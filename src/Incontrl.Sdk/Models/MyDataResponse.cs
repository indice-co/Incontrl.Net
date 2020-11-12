using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incontrl.Sdk.Models
{
    public class MyDataResponse
    {
        public bool HasErrors => ErrorDetails?.Count > 0;

        /// <summary>
        /// Unique Invoice Registration Number
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// Invoice identifier
        /// </summary>
        public string Mark { get; set; }

        public string AuthenticationCode { get; set; }

        public List<ErrorResult> ErrorDetails { get; set; } = new List<ErrorResult>();

        /// <summary>
        /// Date and time that document was successfully sent to Aade.
        /// </summary>
        public DateTimeOffset? SynchronizationDate { get; set; }

        public class ErrorResult
        {
            public string Code { get; set; }
            public string Message { get; set; }
        }
    }
}
