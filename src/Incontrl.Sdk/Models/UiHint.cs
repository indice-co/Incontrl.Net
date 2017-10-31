namespace Incontrl.Sdk.Models
{
    public class UiHint
    {
        public string Theme { get; set; }
        public AccentColor Accent { get; set; }
        public string Icon { get; set; }
        public dynamic Stuff { get; set; }
    }

    public class AccentColor
    {
        public AccentColorType? Type { get; set; }
        public string Foreground { get; set; }
        public string Background { get; set; }
    }

    public enum AccentColorType
    {
        Bright,
        Dark
    }
}
