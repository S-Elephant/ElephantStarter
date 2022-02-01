using System.Diagnostics.CodeAnalysis;
using ElephantStarter.Configurations;
using ElephantStarter.Controllers;
using ElephantStarter.Domain.Configuration;
using ElephantStarter.Domain.RecentlyUsed;
using ElephantStarter.Domain.Services;
using ElephantStarter.Persistence;
using ElephantStarter.Services;
using ElephantStarter.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ElephantStarter
{
	/// <summary>
	/// Service configurator interface.
	/// </summary>
	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileNameMustMatchTypeName", Justification = "Local interface.")]
	public interface IServiceConfigurator
	{
		/// <summary>
		/// Configure all services.
		/// </summary>
		void ConfigureServices(IServiceCollection services, IConfiguration configuration);
	}

	/// <summary>
	/// Service configurator.
	/// </summary>
	public class ServiceConfigurator : IServiceConfigurator
	{
		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			ConfigureBaseServices(services, configuration);
			ConfigureControllers(services);

			services.AddScoped<IShortcutsService, ShortcutsService>();
		}

		private static void ConfigureBaseServices(IServiceCollection services, IConfiguration configuration)
		{
			AddLogging(services, configuration);
			services.AddSingleton<MainGui>();
			IConfigurationService configurationService = services.AddCustomConfigurationService(configuration);
			IRecentlyUsed<string> recentlyUsed = AddRecentlyUsed(services, configurationService);
			services.AddScoped<ISystemTrayMenuController>(x => new SystemTrayMenuController(recentlyUsed, () => Application.Exit()));
			services.AddSingleton<IImageService, ImageService>();
			services.AddSingleton<IThemeService, ThemeService>();
		}

		/// <summary>
		/// Add logging.
		/// </summary>
		/// <remarks>Currently using the NuGet NReco.Logging.File, see: https://github.com/nreco/logging .</remarks>
		private static void AddLogging(IServiceCollection services, IConfiguration configuration)
		{
			services.AddLogging(loggingBuilder => { loggingBuilder.AddFile(configuration.GetSection("Logging")); });
		}

		private static void ConfigureControllers(IServiceCollection services)
		{
			services.AddSingleton<IMainGuiController, MainGuiController>();
		}

		private static IRecentlyUsed<string> AddRecentlyUsed(IServiceCollection services, IConfigurationService configurationService)
		{
			IRecentlyUsed<string> recentlyUsed = new RecentlyUsed<string>(configurationService.Common.RecentlyUsedItemsMax);
			services.AddSingleton(recentlyUsed);
			return recentlyUsed;
		}
	}
}
