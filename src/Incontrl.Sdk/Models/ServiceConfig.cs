namespace Incontrl.Sdk.Models
{
    public class ServiceConfig
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public UiHint UiHint { get; set; }
        public dynamic Settings { get; set; }
    }
}
