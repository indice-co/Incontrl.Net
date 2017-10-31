using System.IO;

namespace Incontrl.Sdk.Models
{
    public class FileResult
    {
        public string FileName { get; set; }
        public Stream Stream { get; set; }
    }
}
