using System;
using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class UpdateDocumentAadeFieldsRequest
    {
        /// <summary>
        /// Invoice identifier
        /// </summary>
        public string Mark { get; set; }
        /// <summary>
        /// Unique Invoice Registration Number
        /// </summary>
        public string Uuid { get; set; }
        /// <summary>
        /// QR Code url. The url to embed to the printout in order to retrieve the document from its respective Tax Authority. Optional
        /// </summary>
        public string QrCodeUrl { get; set; }
        /// <summary>
        /// Date and time that document was successfully sent to Aade.
        /// </summary>
        public DateTimeOffset? SynchronizationDate { get; set; }
        /// <summary>
        /// List of Error Details
        /// </summary>
        public List<ErrorResult> ErrorDetails { get; set; } = new List<ErrorResult>();
        
        public class ErrorResult
        {
            public string Code { get; set; }
            public string Message { get; set; }
        }
    }
}
