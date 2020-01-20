namespace CASPR.Extensions.Import.Services
{
    public interface IImportWorkerFactory
    {
        IImportWorker Create(string importTypeName);
    }
}