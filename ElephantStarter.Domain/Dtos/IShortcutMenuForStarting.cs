namespace ElephantStarter.Domain
{
	/// <summary>
	/// Shortcut menu DTO with only <see cref="Arguments"/> and <see cref="WorkingDirectory"/>.
	/// Use this DTO for starting the process.
	/// </summary>
	public interface IShortcutMenuForStarting
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
		/// Working directory.
		/// </summary>
		string? WorkingDirectory { get; set; }
	}
}