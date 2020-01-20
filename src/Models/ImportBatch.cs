using System;

namespace CASPR.Extensions.Import
{
    public class ImportBatch
    {
        public ImportBatch()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }
        public string ImportProfileName { get; set; }
        public string FileName { get; set; }
    }
}