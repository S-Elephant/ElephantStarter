namespace ElephantStarter.Domain
{
	/// <summary>
	/// Shortcut menu DTO with only a <see cref="Target"/>, <see cref="Arguments"/> and <see cref="WorkingDirectory"/>.
	/// Use this DTO for starting the process.
	/// </summary>
	public interface IShortcutMenuTargetForStarting
	{
		/// <summary>
		/// Optional start argument(s).
		/// </summary>
		string? Arguments { get; set; }

		/// <summary>
		/// lnk file path.
		/// </summary>
		public string? LnkFilePath { get; set; }

		/// <summary>
		/// Shortcut target. Usually this is the path to run.
		/// </summary>
		string? Target { get; set; }

		/// <summary>
		/// Working directory.
		/// </summary>
		string? WorkingDirectory { get; set; }
	}
}