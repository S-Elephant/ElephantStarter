using System.Drawing;

namespace ElephantStarter.Persistence
{
	/// <summary>
	/// Shortcut for menu DTO.
	/// </summary>
	public class ShortcutMenuDto : ShortcutMenuForStarting
	{
		/// <summary>
		/// The icon as a bitmap.
		/// </summary>
		public Bitmap? IconAsBitmap { get; set; } = null;

		/// <summary>
		/// Display name.
		/// </summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Child <see cref="ShortcutMenuDto"/>'s.
		/// </summary>
		public List<ShortcutMenuDto> SubItems { get; set; } = new();

		/// <summary>
		/// Indicates if this is a folder.
		/// </summary>
		public bool IsFolder { get; set; }

		/// <summary>
		/// Constructor.
		/// </summary>
		public ShortcutMenuDto()
		{
		}

		/// <summary>
		/// Constructor with all properties.
		/// </summary>
		public ShortcutMenuDto(Bitmap? iconAsBitmap, string? lnkFilePath, string name, string? arguments, string? workingDirectory, bool isFolder, List<ShortcutMenuDto>? subItems = null)
		: base(lnkFilePath, arguments, workingDirectory)
		{
			IconAsBitmap = iconAsBitmap;
			Name = name;
			IsFolder = isFolder;
			SubItems = subItems ?? new List<ShortcutMenuDto>();
		}
	}
}
