// ReSharper disable CheckNamespace

using System;
using System.Collections.Generic;

namespace CASPR.Extensions.Import
{
    public class ImportType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool AllowNew { get; set; }
        public bool AllowUpdate { get; set; }
        public Type WorkerType { get; set; }
        public ICollection<RecordType> RecordTypes { get; set; }
    }
}
