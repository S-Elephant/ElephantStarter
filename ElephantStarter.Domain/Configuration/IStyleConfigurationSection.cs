namespace ElephantStarter.Domain.Configuration;

/// <summary>
/// Style configuration section interface.
/// </summary>
public interface IStyleConfigurationSection
{
	/// <summary>
	/// Application shortcut button size.
	/// </summary>
	public int AppButtonSize { get; }

	/// <summary>
	/// Application shortcut button spacing.
	/// </summary>
	public int AppButtonSpacing { get; }
}