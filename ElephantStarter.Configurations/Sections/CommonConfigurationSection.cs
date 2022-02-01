using Elephant.Common;
using ElephantStarter.Domain.Configuration;
using Microsoft.Extensions.Configuration;

namespace ElephantStarter.Configurations.Sections
{
	/// <summary>
	/// Common configuration section.
	/// </summary>
	public class CommonConfigurationSection : ICommonConfigurationSection
	{
		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public string ApplicationName { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public List<string> ErrorsToIgnore { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public bool LaunchOnWindowsStartup { get; }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int RecentlyUsedItemsMax { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public bool ShowFolderAtBottom { get; }

		/// <summary>
		/// Constructor.
		/// </summary>
		public CommonConfigurationSection(IConfiguration configuration)
		{
			IConfigurationSection section = ConfigurationHelper.GetSection(configuration, "Common");

			ApplicationName = section.GetValue<string>("ApplicationName");
			LaunchOnWindowsStartup = section.GetValue<bool>("LaunchOnWindowsStartup");
			RecentlyUsedItemsMax = section.GetValue<int>("RecentlyUsedItemsMax");
			ShowFolderAtBottom = section.GetValue<bool>("ShowFolderAtBottom");
			ErrorsToIgnore = section.GetValue<List<string>>("ErrorsToIgnore");
		}
	}
}
