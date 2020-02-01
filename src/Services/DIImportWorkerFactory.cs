using System;
using Microsoft.Extensions.DependencyInjection;

namespace CASPR.Extensions.Import.Services
{
    // ReSharper disable once InconsistentNaming
    public class DIImportWorkerFactory : IImportWorkerFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IImportTypeStorage _importTypeStorage;

        public DIImportWorkerFactory(
            IServiceProvider serviceProvider, 
            IImportTypeStorage importTypeStorage)
        {
            _serviceProvider = serviceProvider;
            _importTypeStorage = importTypeStorage;
        }

        public IImportWorker Create(string importTypeName)
        {
            if (string.IsNullOrEmpty(importTypeName))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(importTypeName));
            }

            var importType = _importTypeStorage.GetImportType(importTypeName);
            if (importType == null)
            {
                throw new ArgumentException($"Import type with name '{importTypeName}' does not exist.");
            }

            return (IImportWorker) _serviceProvider.GetRequiredService(importType.WorkerType);
        }
    }
}