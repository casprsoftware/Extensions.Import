using System.Threading;
using System.Threading.Tasks;

namespace CASPR.Extensions.Import.Services
{
    public interface IImportWorker
    {
        Task<ImportBatchResult> RunAsync(ImportWorkerContext context, CancellationToken cancellationToken);
    }
}