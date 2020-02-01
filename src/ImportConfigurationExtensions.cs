using System.Collections.Generic;
using CASPR.Extensions.Import.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CASPR.Extensions.Import
{
    public static class ImportConfigurationExtensions
    {
        public static IImportConfigurationBuilder AddInMemoryImportProfileStorage(
            this IImportConfigurationBuilder configurationBuilder, 
            ICollection<ImportProfile> importProfiles)
        {
            configurationBuilder.Services.AddSingleton<IImportProfileStorage>(new InMemoryImportProfileStorage(importProfiles));
            return configurationBuilder;
        }

        public static IImportConfigurationBuilder AddInMemoryImportTypeStorage(
            this IImportConfigurationBuilder configurationBuilder,
            ICollection<ImportType> importTypes)
        {
            configurationBuilder.Services.AddSingleton<IImportTypeStorage>(new InMemoryImportTypeStorage(importTypes));
            return configurationBuilder;
        }
    }
}