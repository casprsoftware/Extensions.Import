using System.Collections.Generic;

namespace CASPR.Extensions.Import
{
    public class RecordDefinition
    {
        public string Description { get; set; }
        public string RecordTypeName { get; set; }
        public ICollection<FieldDefinition> FieldDefinitions { get; set; }
        public ICollection<FieldMapping> FieldMappings { get; set; }
    }
}