using System.Collections.Generic;

namespace CASPR.Extensions.Import
{
    public class ImportProfile
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImportTypeName { get; set; }
        public char FieldDelimiter { get; set; }
        public char TextQualifier { get; set; }
        public bool IsFirstRowHeading { get; set; }
        public ICollection<RecordDefinition> RecordDefinitions { get; set; }
    }
}