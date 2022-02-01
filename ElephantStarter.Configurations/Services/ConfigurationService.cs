using ElephantStarter.Configurations.Sections;
using ElephantStarter.Domain.Configuration;
using Microsoft.Extensions.Configuration;

namespace ElephantStarter.Configurations.Services
{
	/// <summary>
	/// Configuration service.
	/// </summary>
	public class ConfigurationService : IConfigurationService
	{
		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public ICommonConfigurationSection Common { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public IStyleConfigurationSection Style { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public IThemeConfigurationSection Theme { get; }

		/// <summary>
		/// Constructor.
		/// </summary>
		public ConfigurationService(IConfiguration configuration)
		{
			Common = new CommonConfigurationSection(configuration);
			Style = new StyleConfigurationSection(configuration);
			Theme = new ThemeConfigurationSection(configuration);
		}
	}
}
