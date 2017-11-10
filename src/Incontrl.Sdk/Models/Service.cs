namespace Incontrl.Sdk.Models
{
    public class Service
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool Enabled { get; set; }
        public UiHint UiHint { get; set; }
        public dynamic Settings { get; set; }
    }
}
