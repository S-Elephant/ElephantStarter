namespace ElephantStarter.Persistence;

/// <summary>
/// Shortcut service interface.
/// </summary>
public interface IShortcutsService
{
	/// <summary>
	/// Get a list of all shortcuts.
	/// </summary>
	List<ShortcutMenuDto> AllShortcuts();

	/// <summary>
	/// Get a shortcut by filepath. Returns null if not found.
	/// </summary>
	ShortcutMenuDto? ShortcutByPath(string path, bool ensureFileExists);
}