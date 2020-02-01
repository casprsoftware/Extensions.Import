using Microsoft.Extensions.DependencyInjection;

namespace CASPR.Extensions.Import
{
    /// <summary>
    /// An interface for configuring import providers.
    /// </summary>
    public interface IImportConfigurationBuilder
    {
        /// <summary>
        /// Gets the <see cref="IServiceCollection"/> where Import services are configured.
        /// </summary>
        IServiceCollection Services { get; }
    }
}