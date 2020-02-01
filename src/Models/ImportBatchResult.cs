using System;
using System.Collections.Generic;

namespace CASPR.Extensions.Import
{
    public class ImportBatchResult
    {
        public ImportBatchResult()
        {
            Failures = new List<ImportBatchFailure>();
        }

        public ICollection<ImportBatchFailure> Failures { get; set; }
        public TimeSpan Duration { get; set; }
    }
}