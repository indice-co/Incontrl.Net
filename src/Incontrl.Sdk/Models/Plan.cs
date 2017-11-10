using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class Plan
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string RichText { get; set; }
        public UiHint UiHint { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();
        public List<LimitPolicy> Limits { get; set; } = new List<LimitPolicy>();
    }
}
