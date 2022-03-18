using ElephantStarter.Domain.Configuration;
using ElephantStarter.Domain.RecentlyUsed;
using ElephantStarter.Domain.Services;
using ElephantStarter.Persistence;
using ElephantStarter.ShortcutSorting;

namespace ElephantStarter.UI
{
	/// <summary>
	/// Menu item helper.
	/// </summary>
	public class MenuItemsHelper
	{
		private readonly IImageService _imageService;
		private readonly ContextMenuStrip _cmsSystemTray;
		private readonly IConfigurationService _configurationService;
		private readonly IRecentlyUsed<string> _recentlyUsed;
		private readonly IShortcutsService _shortcutsService;

		/// <summary>
		/// The next shortcut its name number prefix.
		/// </summary>
		private static uint _nextShortcutNumber = 0;

		/// <summary>
		/// Constructor.
		/// </summary>
		public MenuItemsHelper(IImageService imageService, ContextMenuStrip cmsSystemTray, IConfigurationService configurationService,
			IRecentlyUsed<string> recentlyUsed, IShortcutsService shortcutsService)
		{
			_imageService = imageService;
			_cmsSystemTray = cmsSystemTray;
			_configurationService = configurationService;
			_recentlyUsed = recentlyUsed;
			_shortcutsService = shortcutsService;
		}

		/// <summary>
		/// Creates the default menu items like for example "Exit".
		/// </summary>
		public void CreateDefaultMenuItems(EventHandler visibilityClick, EventHandler exitClick)
		{
			AddSeparator(_cmsSystemTray);

			// Toggle visibility.
			ToolStripMenuItem tsmiToggleVisibility = new()
			{
				Image = _imageService.ToggleVisibility,
				Name = "TsmiToggleVisibility",
				Text = "Toggle &menu",
			};
			tsmiToggleVisibility.Click += visibilityClick;
			_cmsSystemTray.Items.Add(tsmiToggleVisibility);

			// Exit.
			ToolStripMenuItem tsmiExit = new()
			{
				Image = _imageService.Exit,
				Name = "TsmiExit",
				Text = "&Exit",
			};
			tsmiExit.Click += exitClick;
			_cmsSystemTray.Items.Add(tsmiExit);
		}

		/// <summary>
		/// Creates and adds all system tray shortcut menu items.
		/// </summary>
		public void CreateAllShortcutToolStripMenuItem(EventHandler shortcutMenuItemOnClick)
		{
			IShortcutSorter shortcutSorter = _configurationService.Common.ShowFolderAtBottom ? new ShortcutSorterByFolderThenName() : new ShortcutSorterByName();
			IOrderedEnumerable<ShortcutMenuDto> orderedShortcuts = shortcutSorter.Sort(_shortcutsService.AllShortcuts());

			foreach (ShortcutMenuDto shortcutDto in orderedShortcuts)
				CreateShortcutToolStripMenuItemRecursively(shortcutDto, shortcutMenuItemOnClick);
		}

		/// <summary>
		/// Creates and adds all recently used system tray shortcut items.
		/// </summary>
		public void CreateAllRecentlyUsedItems(EventHandler shortcutMenuItemOnClick)
		{
			// Get all items.
			List<string> allRecentlyUsedItemPaths = _recentlyUsed.Get();

			// If there are none then do nothing, thus return.
			if (!allRecentlyUsedItemPaths.Any())
				return;

			AddSeparator(_cmsSystemTray);

			// Reverse the list because we want the list ordered top to bottom : newest to oldest.
			allRecentlyUsedItemPaths.Reverse();

			// Create and add the recently used items.
			foreach (string shortcutPath in allRecentlyUsedItemPaths)
			{
				ShortcutMenuDto? shortcut = shortcutPath.EndsWith(".url", StringComparison.InvariantCultureIgnoreCase) ? _shortcutsService.UrlByPath(shortcutPath, true) : _shortcutsService.ShortcutByPath(shortcutPath, true);

				if (shortcut != null)
				{
					ToolStripMenuItem newMenuItem = CreateShortcutToolStripMenuItem(shortcut, shortcutMenuItemOnClick);
					_cmsSystemTray.Items.Add(newMenuItem);
				}
			}
		}

		private void CreateShortcutToolStripMenuItemRecursively(ShortcutMenuDto shortcutDto, EventHandler shortcutMenuItemOnClick)
		{
			ToolStripMenuItem newMenuItem = CreateShortcutToolStripMenuItem(shortcutDto, shortcutMenuItemOnClick);

			foreach (ShortcutMenuDto shortcutDtoSubItem in shortcutDto.SubItems)
			{
				ToolStripMenuItem newMenuSubItem = CreateShortcutToolStripMenuItem(shortcutDtoSubItem, shortcutMenuItemOnClick);
				newMenuItem.DropDownItems.Add(newMenuSubItem);
			}

			_cmsSystemTray.Items.Add(newMenuItem);
		}

		private static ToolStripMenuItem CreateShortcutToolStripMenuItem(ShortcutMenuDto shortcutDto, EventHandler shortcutMenuItemOnClick)
		{
			ToolStripMenuItem newMenuItem = new();
			newMenuItem.Name = $"Shortcut_{_nextShortcutNumber++}";
			newMenuItem.Text = shortcutDto.Name;
			if (shortcutDto.LnkFilePath != null)
			{
				newMenuItem.Tag = new ShortcutMenuForStarting(shortcutDto.LnkFilePath, shortcutDto.Arguments, shortcutDto.WorkingDirectory);
				newMenuItem.Click += shortcutMenuItemOnClick;
			}
			newMenuItem.Image = shortcutDto.IconAsBitmap;
			return newMenuItem;
		}

		private static void AddSeparator(ContextMenuStrip cmsSystemTray)
		{
			cmsSystemTray.Items.Add(new ToolStripSeparator());
		}
	}
}
