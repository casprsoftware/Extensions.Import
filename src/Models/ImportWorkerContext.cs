namespace CASPR.Extensions.Import
{
    public class ImportWorkerContext
    {
        public ImportBatch Batch { get; set; }
        public ImportProfile Profile { get; set; }
        public ImportType ImportType { get; set; }
    }
}