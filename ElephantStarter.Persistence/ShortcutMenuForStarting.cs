using ElephantStarter.Domain;

namespace ElephantStarter.Persistence
{
	/// <summary>
	/// Shortcut menu DTO with only <see cref="Arguments"/> and <see cref="WorkingDirectory"/>.
	/// Use this DTO for starting the process.
	/// </summary>
	public class ShortcutMenuForStarting : IShortcutMenuForStarting
	{
		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public string? Arguments { get; set; } = null;

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public string? LnkFilePath { get; set; } = string.Empty;

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public string? WorkingDirectory { get; set; } = null;

		/// <summary>
		/// Constructor.
		/// </summary>
		public ShortcutMenuForStarting()
		{
		}

		/// <summary>
		/// Constructor with all properties.
		/// </summary>
		public ShortcutMenuForStarting(string? lnkFilePath, string? arguments, string? workingDirectory)
		{
			LnkFilePath = lnkFilePath;
			Arguments = arguments;
			WorkingDirectory = workingDirectory;
		}
	}
}
