using System.Drawing;
using System.Runtime.Versioning;
using Elephant.Lnk;
using ElephantStarter.Domain.Services;

namespace ElephantStarter.Persistence;

/// <summary>
/// Shortcut service.
/// </summary>
public class ShortcutsService : IShortcutsService
{
	private readonly IImageService _imageService;
	private readonly string _baseDirectory;

	/// <summary>
	/// Constructor.
	/// </summary>
	public ShortcutsService(IImageService imageService)
	{
		_imageService = imageService;
		_baseDirectory = Path.Combine(Environment.CurrentDirectory, "Shortcuts");
	}

	/// <summary>
	/// <inheritdoc />
	/// </summary>
	[SupportedOSPlatform("windows")]
	public List<ShortcutMenuDto> AllShortcuts()
	{
		// Get top directory results.
		List<ShortcutMenuDto> result = CreateShortcutsFromDirectory(_baseDirectory);

		// Get sub directories and if none, return.
		string[] subDirectories = Directory.GetDirectories(_baseDirectory, "*", SearchOption.TopDirectoryOnly);
		if (subDirectories.Length == 0)
			return result;

		// Get sub directories results.
		Bitmap subdirectoryIcon = _imageService.Folder;
		foreach (string subDirectory in subDirectories)
		{
			List<ShortcutMenuDto> subDirectoryResults = CreateShortcutsFromDirectory(subDirectory);

			result.Add(new ShortcutMenuDto(
				subdirectoryIcon,
				null,
				GetFolderName(subDirectory),
				null,
				null,
				true,
				subDirectoryResults));
		}

		return result;
	}

	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	[SupportedOSPlatform("windows")]
	public ShortcutMenuDto? ShortcutByPath(string path, bool ensureFileExists)
	{
		if (path == null || (ensureFileExists && !File.Exists(path)))
			return null;

		LnkInfo? shortcutInfo = LnkHelper.GetAllInfo(path);
		if (shortcutInfo == null)
			return null;

		Icon? icon = Icon.ExtractAssociatedIcon(path);

		return new ShortcutMenuDto(
			icon?.ToBitmap(),
			path,
			shortcutInfo.Name ?? "<Unknown name>",
			shortcutInfo.ArgumentsAsString,
			shortcutInfo.WorkingDirectory,
			false);
	}

	/// <summary>
	/// Returns the folder name from the specified <paramref name="fullPath"/>.
	/// </summary>
	private static string GetFolderName(string fullPath)
	{
		return new DirectoryInfo(fullPath).Name;
	}

	[SupportedOSPlatform("windows")]
	private List<ShortcutMenuDto> CreateShortcutsFromDirectory(string directory)
	{
		List<ShortcutMenuDto> result = new();

		string[] shortcutFiles = Directory.GetFiles(directory, "*.lnk", SearchOption.TopDirectoryOnly);

		foreach (string fullFilePath in shortcutFiles)
		{
			ShortcutMenuDto? newShortcut = ShortcutByPath(fullFilePath, false);
			if (newShortcut != null)
				result.Add(newShortcut);
		}

		return result;
	}
}
