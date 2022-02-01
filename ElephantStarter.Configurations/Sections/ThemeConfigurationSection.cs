using System.Drawing;
using Elephant.Common;
using ElephantStarter.Domain.Configuration;
using Microsoft.Extensions.Configuration;

namespace ElephantStarter.Configurations.Sections
{
	/// <summary>
	/// Theme configuration section.
	/// </summary>
	public class ThemeConfigurationSection : IThemeConfigurationSection
	{
		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public Color BackgroundColor { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public Color ButtonBackgroundColor { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public string ButtonFontFamily { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public float ButtonFontEmSize { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public Color ButtonHoverBackgroundColor { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public Color ForeColor { get; }

		/// <summary>
		/// Constructor.
		/// </summary>
		public ThemeConfigurationSection(IConfiguration configuration)
		{
			IConfigurationSection section = ConfigurationHelper.GetSection(configuration, "Theme");

			BackgroundColor = section.GetValue<Color>("BackgroundColor");
			ButtonBackgroundColor = section.GetValue<Color>("ButtonBackgroundColor");
			ButtonFontFamily = section.GetValue<string>("ButtonFontFamily");
			ButtonFontEmSize = section.GetValue<float>("ButtonFontEmSize");
			ButtonHoverBackgroundColor = section.GetValue<Color>("ButtonHoverBackgroundColor");
			ForeColor = section.GetValue<Color>("ForeColor");
		}
	}
}
