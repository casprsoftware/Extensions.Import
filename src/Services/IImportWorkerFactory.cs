using System;

namespace CASPR.Extensions.Import.Services
{
    public interface IImportWorkerFactory
    {
        IImportWorker Create(Type workerType);
    }
}