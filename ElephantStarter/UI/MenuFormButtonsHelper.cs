using ElephantStarter.Domain.Configuration;
using ElephantStarter.Persistence;
using ElephantStarter.Services;

namespace ElephantStarter.UI
{
	/// <summary>
	/// <see cref="AppButton"/> creator helper.
	/// </summary>
	public class MenuFormButtonsHelper
	{
		private readonly IShortcutsService _shortcutsService;
		private readonly IThemeService _themeService;
		private readonly IConfigurationService _configurationService;
		private readonly Control _contentsContainer;
		private bool _isInitialized = false;

		/// <summary>
		/// Constructor.
		/// </summary>
		public MenuFormButtonsHelper(IShortcutsService shortcutsService, IThemeService themeService, IConfigurationService configurationService, Control contentsContainer)
		{
			_shortcutsService = shortcutsService;
			_themeService = themeService;
			_configurationService = configurationService;
			_contentsContainer = contentsContainer;
		}

		/// <summary>
		/// Returns the amount of added buttons.
		/// </summary>
		public int Initialize()
		{
			if (_isInitialized)
				return -1;

			IOrderedEnumerable<ShortcutMenuDto> shortCuts = _shortcutsService.AllShortcuts().OrderBy(x => x.Name);

			int addedCount = 0;
			foreach (ShortcutMenuDto shortcutMenuDto in shortCuts)
			{
				if (!shortcutMenuDto.IsFolder)
				{
					_contentsContainer.Controls.Add(CreateButton(shortcutMenuDto));
					addedCount++;
				}

				foreach (ShortcutMenuDto subItem in shortcutMenuDto.SubItems.Where(x => !x.IsFolder))
				{
					_contentsContainer.Controls.Add(CreateButton(subItem));
					addedCount++;
				}
			}

			_isInitialized = true;
			return addedCount;
		}

		private AppButton CreateButton(ShortcutMenuDto shortcutMenuDto)
		{
			AppButton btn = new(_themeService);
			btn.Image = shortcutMenuDto.IconAsBitmap;
			btn.Size = new Size(_configurationService.Style.AppButtonSize, _configurationService.Style.AppButtonSize);
			btn.Button.Text = shortcutMenuDto.Name;
			string lnkFilePath = shortcutMenuDto.LnkFilePath ?? "<Unknown>";
			btn.ToolTipText = shortcutMenuDto.Arguments == null ? lnkFilePath : $"{lnkFilePath}\nArguments: {shortcutMenuDto.Arguments}";
			return btn;
		}
	}
}
