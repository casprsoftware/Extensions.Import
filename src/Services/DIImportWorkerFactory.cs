using System;
using Microsoft.Extensions.DependencyInjection;

namespace CASPR.Extensions.Import.Services
{
    // ReSharper disable once InconsistentNaming
    public class DIImportWorkerFactory : IImportWorkerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DIImportWorkerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IImportWorker Create(Type workerType)
        {
            if (workerType == null)
            {
                throw new ArgumentNullException(nameof(workerType));
            }

            return (IImportWorker) _serviceProvider.GetRequiredService(workerType);
        }
    }
}