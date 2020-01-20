using System.Threading;
using CASPR.Extensions.Import.Services;

namespace CASPR.Extensions.Import
{
    public class ImportBackgroundService
    {
        private readonly IImportWorkerFactory _importWorkerFactory;
        private readonly IImportProfileStorage _importProfileStorage;
        private readonly IImportTypeStorage _importTypeStorage;

        public ImportBackgroundService(
            IImportWorkerFactory importWorkerFactory, 
            IImportProfileStorage importProfileStorage, 
            IImportTypeStorage importTypeStorage)
        {
            _importWorkerFactory = importWorkerFactory;
            _importProfileStorage = importProfileStorage;
            _importTypeStorage = importTypeStorage;
        }

        public void Start()
        {
            var batch = new ImportBatch
            {
                ImportProfileName = "TestProfile", 
                FileName = "some/file.csv"
            };
            // get profile
            var profile = _importProfileStorage.GetImportProfile(batch.ImportProfileName);
            
            // create ImportWorker
            var importWorker = _importWorkerFactory.Create(profile.ImportTypeName);
            var importType = _importTypeStorage.GetImportType(profile.ImportTypeName);

            var context = new ImportWorkerContext
            {
                Batch = batch,
                Profile = profile,
                ImportType = importType
            };

            // run worker
            var importTask = importWorker.RunAsync(context, CancellationToken.None);
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