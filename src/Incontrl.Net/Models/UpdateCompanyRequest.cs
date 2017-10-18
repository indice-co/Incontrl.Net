using System.Collections.Generic;

namespace Incontrl.Net.Models
{
    public class UpdateCompanyRequest : UpdateOrganisationRequest
    {
        
        /// <summary>
        /// This is for keeping track of the available methods for the company to recieve payment.
        /// </summary>
        public ICollection<PaymentOption> PaymentMethods { get; set; }
    }
}
