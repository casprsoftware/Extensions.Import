using System.Collections.Generic;

namespace CASPR.Extensions.Import
{
    public class RecordType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Field> Fields { get; set; }
    }
}