using Elephant.Common;
using ElephantStarter.Domain.Configuration;
using Microsoft.Extensions.Configuration;

namespace ElephantStarter.Configurations.Sections
{
	/// <summary>
	/// Style configuration section.
	/// </summary>
	public class StyleConfigurationSection : IStyleConfigurationSection
	{
		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public int AppButtonSize { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public int AppButtonSpacing { get; }

		/// <summary>
		/// Constructor.
		/// </summary>
		public StyleConfigurationSection(IConfiguration configuration)
		{
			IConfigurationSection section = ConfigurationHelper.GetSection(configuration, "Style");

			AppButtonSize = section.GetValue<int>("AppButtonSize");
			AppButtonSpacing = section.GetValue<int>("AppButtonSpacing");
		}
	}
}
