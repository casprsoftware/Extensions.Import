using System;
using System.Threading;
using System.Threading.Tasks;
using CASPR.Extensions.Import.Services;

namespace CASPR.Extensions.Import
{
    public class ImportBatchExecutor : IImportBatchExecutor
    {
        #region Constructors

        private readonly IImportProfileStorage _importProfileStorage;
        private readonly IImportTypeStorage _importTypeStorage;
        private readonly IImportWorkerFactory _importWorkerFactory;

        public ImportBatchExecutor(
            IImportProfileStorage importProfileStorage, 
            IImportTypeStorage importTypeStorage, 
            IImportWorkerFactory importWorkerFactory)
        {
            _importProfileStorage = importProfileStorage;
            _importTypeStorage = importTypeStorage;
            _importWorkerFactory = importWorkerFactory;
        }

        #endregion

        public Task<ImportBatchResult> RunAsync(ImportBatch batch, CancellationToken cancellationToken)
        {
            if (batch == null)
            {
                throw new ArgumentNullException(nameof(batch));
            }

            var profile = _importProfileStorage.GetImportProfile(batch.ImportProfileName);
            if (profile == null)
            {
                throw new Exception($"Import profile '{batch.ImportProfileName}' does not exist.");
            }

            var importType = _importTypeStorage.GetImportType(profile.ImportTypeName);

            var worker = _importWorkerFactory.Create(importType.WorkerType);

            var context = new ImportWorkerContext
            {
                Batch = batch,
                ImportType = importType,
                Profile = profile
            };

            return worker.RunAsync(context, cancellationToken);
        }
    }
}