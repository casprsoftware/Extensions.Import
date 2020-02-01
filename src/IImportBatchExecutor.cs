using System.Threading;
using System.Threading.Tasks;

namespace CASPR.Extensions.Import
{
    public interface IImportBatchExecutor
    {
        Task<ImportBatchResult> RunAsync(ImportBatch batch, CancellationToken cancellationToken);
    }
}