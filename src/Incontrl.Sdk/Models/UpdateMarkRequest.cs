using System;

namespace Incontrl.Sdk.Models
{
    public class UpdateMarkRequest
    {
        /// <summary>
        /// Unique id for the document in AADE.
        /// </summary>
        public string Mark { get; set; }
        /// <summary>
        /// Unique id for the cancelled document in AADE.
        /// </summary>
        public string CancelMark { get; set; }
        /// <summary>
        /// Invoice identifier.
        /// </summary>
        public string Uuid { get; set; }
        /// <summary>
        /// Date and time that document was successfully sent to AADE.
        /// </summary>
        public DateTimeOffset? MarkDate { get; set; }
        /// <summary>
        /// Date and time that document was successfully cancelled in AADE.
        /// </summary>
        public DateTimeOffset? CancelMarkDate { get; set; }
        /// <summary>
        /// QR Code url. The url to embed to the printout in order to retrieve the document from its respective Tax Authority. Optional
        /// </summary>
        public string QrCodeUrl { get; set; }
    }
}
