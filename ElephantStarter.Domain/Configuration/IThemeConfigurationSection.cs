using System.Drawing;

namespace ElephantStarter.Domain.Configuration;

/// <summary>
/// Theme configuration section interface.
/// </summary>
public interface IThemeConfigurationSection
{
	/// <summary>
	/// Common background color.
	/// </summary>
	Color BackgroundColor { get; }

	/// <summary>
	/// Button background color.
	/// </summary>
	Color ButtonBackgroundColor { get; }

	/// <summary>
	/// Button font family. Example value: "Arial".
	/// </summary>
	string ButtonFontFamily { get; }

	/// <summary>
	/// Button font size in em.
	/// </summary>
	float ButtonFontEmSize { get; }

	/// <summary>
	/// Button background color when hovered.
	/// </summary>
	Color ButtonHoverBackgroundColor { get; }

	/// <summary>
	/// Common foreground color.
	/// </summary>
	Color ForeColor { get; }
}