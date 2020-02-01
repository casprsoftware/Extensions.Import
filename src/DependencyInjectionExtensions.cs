using System;
using CASPR.Extensions.Import.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CASPR.Extensions.Import
{
    /// <summary>
    /// Extension methods for setting up import services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Adds import services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configure">The <see cref="IImportConfigurationBuilder"/> configuration delegate.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddImport(
            this IServiceCollection services, Action<IImportConfigurationBuilder> configure)
        {
            // add default implementations
            services.AddTransient<IImportWorkerFactory, DIImportWorkerFactory>();
            services.AddTransient<IImportBatchExecutor, ImportBatchExecutor>();

            configure(new ImportConfigurationBuilder(services));
            return services;
        }

    }
}