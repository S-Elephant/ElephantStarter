using ElephantStarter.Domain;

namespace ElephantStarter.Persistence
{
	/// <summary>
	/// Shortcut menu DTO with only a <see cref="Target"/>, <see cref="Arguments"/> and <see cref="WorkingDirectory"/>.
	/// Use this DTO for starting the process.
	/// </summary>
	public class ShortcutMenuTargetForStarting : IShortcutMenuTargetForStarting
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
		public string? Target { get; set; } = string.Empty;

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public string? WorkingDirectory { get; set; } = null;

		/// <summary>
		/// Constructor.
		/// </summary>
		public ShortcutMenuTargetForStarting()
		{
		}

		/// <summary>
		/// Constructor with all properties.
		/// </summary>
		public ShortcutMenuTargetForStarting(string? target, string? lnkFilePath, string? arguments, string? workingDirectory)
		{
			Target = target;
			LnkFilePath = lnkFilePath;
			Arguments = arguments;
			WorkingDirectory = workingDirectory;
		}
	}
}
