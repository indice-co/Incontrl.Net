using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incontrl.Sdk.Models
{
    public class Classification
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public List<Classification> Classifications { get; set; }
        public TranslationDictionary<ClassificationTranslation> Translations { get; set; }
    }
    public class ClassificationTranslation
    {
        public string Description { get; set; }
    }
}
