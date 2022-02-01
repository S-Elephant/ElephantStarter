using ElephantStarter.Configurations.Services;
using ElephantStarter.Domain.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElephantStarter.Configurations
{
	/// <summary>
	/// Configuration extensions.
	/// </summary>
	public static class ConfiguratorExtensions
	{
		/// <summary>
		/// Add custom configuration.
		/// </summary>
		public static IConfigurationBuilder AddCustomConfiguration(this IConfigurationBuilder builder)
		{
			return builder.AddJsonFile(Constants.SettingsJsonFilename, optional: false, reloadOnChange: false);
		}

		/// <summary>
		/// Add custom configuration service.
		/// </summary>
		public static IConfigurationService AddCustomConfigurationService(this IServiceCollection services, IConfiguration configuration)
		{
			IConfigurationService configurationService = new ConfigurationService(configuration);
			services.AddSingleton(configurationService);
			return configurationService;
		}
	}
}