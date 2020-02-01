using System.Threading;

namespace CASPR.Extensions.Import
{
    public class ImportBackgroundService
    {
        private readonly IImportBatchExecutor _batchExecutor;

        public ImportBackgroundService(IImportBatchExecutor batchExecutor)
        {
            _batchExecutor = batchExecutor;
        }

        public void Start()
        {
            var batch = new ImportBatch
            {
                ImportProfileName = "TestProfile",
                FileName = "some/file.csv"
            };

            // run worker
            var importTask = _batchExecutor.RunAsync(batch, CancellationToken.None);
            importTask.ContinueWith((task) =>
            {
                if (task.IsFaulted)
                {
                    // handler error
                    // task.Exception
                    return;
                }
                var result = task.Result;
            });

        }
    }
}