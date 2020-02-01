using Microsoft.Extensions.DependencyInjection;

namespace CASPR.Extensions.Import
{
    internal class ImportConfigurationBuilder : IImportConfigurationBuilder
    {
        public ImportConfigurationBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}