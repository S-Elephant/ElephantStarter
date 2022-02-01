using System.Diagnostics.CodeAnalysis;
using ElephantStarter.Domain.Configuration;

namespace ElephantStarter.Services
{
	/// <summary>
	/// Theme service interface.
	/// </summary>
	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileNameMustMatchTypeName", Justification = "Local interface.")]
	public interface IThemeService
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
		/// Button background color when hovered.
		/// </summary>
		Color ButtonHoverBackgroundColor { get; }

		/// <summary>
		/// Common foreground color.
		/// </summary>
		Color ForeColor { get; }

		/// <summary>
		/// Apply the current theme to the specified <see cref="Form"/>.
		/// </summary>
		void ApplyTheme(Form form);

		/// <summary>
		/// Apply the current theme to the specified <see cref="Button"/> and optionally also applies the themed font.
		/// </summary>
		void ApplyTheme(Button button, bool applyFont = true);

		/// <summary>
		/// Apply the current theme to the specified <see cref="Button"/>s and optionally also applies the themed font.
		/// </summary>
		void ApplyTheme(bool applyFont, params Button[] buttons);
	}

	/// <summary>
	/// Theme service.
	/// </summary>
	public class ThemeService : IThemeService
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
		public Color ButtonHoverBackgroundColor { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public Color ForeColor { get; }

		private readonly Font _buttonFont;

		/// <summary>
		/// Constructor.
		/// </summary>
		public ThemeService(IConfigurationService configurationService)
		{
			IThemeConfigurationSection themeConfigurationSection = configurationService.Theme;

			BackgroundColor = themeConfigurationSection.BackgroundColor;
			ButtonBackgroundColor = themeConfigurationSection.ButtonBackgroundColor;
			ButtonHoverBackgroundColor = themeConfigurationSection.ButtonHoverBackgroundColor;
			ForeColor = themeConfigurationSection.ForeColor;
			_buttonFont = new Font(themeConfigurationSection.ButtonFontFamily, themeConfigurationSection.ButtonFontEmSize, FontStyle.Bold);
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public void ApplyTheme(Form form)
		{
			form.BackColor = BackgroundColor;
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public void ApplyTheme(Button button, bool applyFont = true)
		{
			button.FlatStyle = FlatStyle.Flat;
			button.BackColor = ButtonBackgroundColor;
			button.FlatAppearance.MouseOverBackColor = ButtonHoverBackgroundColor;
			button.ForeColor = ForeColor;

			if (applyFont)
				button.Font = _buttonFont;
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public void ApplyTheme(bool applyFont, params Button[] buttons)
		{
			foreach (Button button in buttons)
				ApplyTheme(button);
		}
	}
}
