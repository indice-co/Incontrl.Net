using System.Collections.Generic;

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
