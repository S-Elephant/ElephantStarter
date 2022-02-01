namespace ElephantStarter.Domain.Configuration;

/// <summary>
/// Configuration service interface.
/// </summary>
public interface IConfigurationService
{
	/// <summary>
	/// Common configuration section.
	/// </summary>
	ICommonConfigurationSection Common { get; }

	/// <summary>
	/// Style configuration section.
	/// </summary>
	IStyleConfigurationSection Style { get; }

	/// <summary>
	/// Theme configuration section.
	/// </summary>
	public IThemeConfigurationSection Theme { get; }
}