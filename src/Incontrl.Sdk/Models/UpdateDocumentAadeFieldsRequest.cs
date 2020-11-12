using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Date and time that document was successfully sent to Aade.
        /// </summary>
        public DateTimeOffset? SynchronizationDate { get; set; }

        /// <summary>
        /// Log of the synchronization attempts made to IAPR
        /// </summary>
        public string SynchronizationLog { get; set; }
    }
}
