namespace CASPR.Extensions.Import.Services
{
    public interface IImportTypeStorage
    {
        ImportType GetImportType(string name);
    }
}