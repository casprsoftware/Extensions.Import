namespace CASPR.Extensions.Import.Services
{
    public interface IImportProfileStorage
    {
        ImportProfile GetImportProfile(string name);
    }
}