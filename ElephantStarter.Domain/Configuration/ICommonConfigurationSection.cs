namespace ElephantStarter.Domain.Configuration;

/// <summary>
/// Common configuration section interface.
/// </summary>
public interface ICommonConfigurationSection
{
	/// <summary>
	/// Application name.
	/// </summary>
	string ApplicationName { get; }

	/// <summary>
	/// Errors to ignore. If an error contains any of these (case sensitive) then it will be ignored.
	/// </summary>
	List<string> ErrorsToIgnore { get; }

	/// <summary>
	/// Whether or not this application should be launched on startup.
	/// </summary>
	bool LaunchOnWindowsStartup { get; }

	/// <summary>
	/// The maxmimum amount of recently used items.
	/// </summary>
	int RecentlyUsedItemsMax { get; }

	/// <summary>
	/// If true, shows all folders (if any) near the bottom of the system tray popup; otherwise, sorts everything only by name.
	/// </summary>
	bool ShowFolderAtBottom { get; }
}