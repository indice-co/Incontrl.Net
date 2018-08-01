using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incontrl.Sdk.Models
{
    public class DocumentStatusOption
    {
        public string DisplayName { get; set; }
        public DocumentStatus Value { get; set; }
        public bool Available { get; set; }
    }
}
