using System;
using System.Collections.Generic;

namespace CASPR.Extensions.Import
{
    public class ImportBatchResult
    {
        public ICollection<ImportBatchFailure> Failures { get; set; }
        public TimeSpan Duration { get; set; }
    }
}