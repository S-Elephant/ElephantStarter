using Elephant.Common.Extensions;
using ElephantStarter.Controllers;
using ElephantStarter.Domain.Configuration;
using ElephantStarter.Domain.Gui;
using ElephantStarter.Domain.RecentlyUsed;
using ElephantStarter.Domain.Services;
using ElephantStarter.Persistence;
using ElephantStarter.Services;
using Microsoft.Extensions.Logging;

namespace ElephantStarter.UI;

/// <summary>
/// Main form.
/// </summary>
public partial class MainGui : Form, IMainGui
{
	private readonly ISystemTrayMenuController _systemTrayMenuController;
	private readonly IConfigurationService _configurationService;
	private readonly IShortcutsService _shortcutsService;
	private readonly IImageService _imageService;
	private readonly IMainGuiController _mainGuiController;
	private readonly IRecentlyUsed<string> _recentlyUsed;
	private readonly ILogger _logger;
	private readonly MenuFormButtonsHelper _menuFormButtonsHelper;

	/// <summary>
	/// We can't use the normal Visible property. See: https://stackoverflow.com/questions/3742709/this-visible-is-not-working-in-windows-forms.
	/// </summary>
	private bool _isVisible = false;

	/// <summary>
	/// Constructor.
	/// </summary>
	public MainGui(ISystemTrayMenuController systemTrayMenuController, IConfigurationService configurationService,
		IShortcutsService shortcutsService, IImageService imageService, IThemeService themeService,
		IMainGuiController mainGuiController, IRecentlyUsed<string> recentlyUsed, ILogger<MainGui> logger)
	{
		_systemTrayMenuController = systemTrayMenuController;
		_configurationService = configurationService;
		_shortcutsService = shortcutsService;
		_imageService = imageService;
		_mainGuiController = mainGuiController;
		_recentlyUsed = recentlyUsed;
		_logger = logger;
		systemTrayMenuController.MainGui = this;
		InitializeComponent();

		ProcessSystemTrayItems();
		systemTrayMenuController.RefreshRecentlyUsedAction = ProcessSystemTrayItems;

		// Create buttons helper.
		_menuFormButtonsHelper = new MenuFormButtonsHelper(shortcutsService, themeService, configurationService, TableLayoutPanel);

		ApplyButtonImages(imageService);
		ApplyTheme(themeService);
	}

	/// <summary>
	/// Applies the images to the static buttons near the top.
	/// </summary>
	private void ApplyButtonImages(IImageService imageService)
	{
		BtnOpenSettings.BackgroundImage = imageService.Settings;
		BtnConfigureStartup.BackgroundImage = imageService.AutoStart;
		BtnOpenShortcutsFolder.BackgroundImage = imageService.Folder;
		BtnRestartThisApplication.BackgroundImage = imageService.Restart;
	}

	/// <summary>
	/// Apply the theme to all controls where applicable.
	/// </summary>
	private void ApplyTheme(IThemeService themeService)
	{
		themeService.ApplyTheme(this);
		themeService.ApplyTheme(false, BtnOpenSettings, BtnConfigureStartup, BtnOpenShortcutsFolder, BtnRestartThisApplication);
	}

	/// <summary>
	/// Creates and initializes the system tray items.
	/// </summary>
	private void ProcessSystemTrayItems()
	{
		CmsSystemTray.Items.Clear();
		MenuItemsHelper menuItemsHelper = new(_imageService, CmsSystemTray, _configurationService, _recentlyUsed, _shortcutsService);
		menuItemsHelper.CreateAllShortcutToolStripMenuItem(ShortcutMenuItemOnClick);
		menuItemsHelper.CreateAllRecentlyUsedItems(ShortcutMenuItemOnClick);
		menuItemsHelper.CreateDefaultMenuItems(TsmiToggleVisibility_Click, TsmiExit_Click);
	}

	/// <summary>
	/// Display this control.
	/// </summary>
	public new void Show()
	{
		Opacity = 1.00f;
		_isVisible = Visible = true;
		WindowState = FormWindowState.Normal;
		Enabled = true; // This line is required for this form to actually show.
		TableLayoutPanel.RowCount = 0;
		int addedCount = _menuFormButtonsHelper.Initialize();

		if (addedCount != -1)
		{
			TableLayoutPanel.RowCount = (addedCount + TableLayoutPanel.ColumnCount - 1) / TableLayoutPanel.ColumnCount;

			// Code below ensures that an infinite amount of shortcuts are supported.
			TableLayoutPanel.RowStyles.Clear();
			for (int i = 0; i < TableLayoutPanel.RowCount; i++)
				TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, _configurationService.Style.AppButtonSize + _configurationService.Style.AppButtonSpacing));

			// Force a TableLayoutPanel resize.
			TableLayoutPanel.Height = 0;
		}
	}

	/// <summary>
	/// Hides the control by setting the visible property to false.
	/// </summary>
	public new void Hide()
	{
		Opacity = 0f;
		_isVisible = Visible = false;
	}

	/// <summary>
	/// Hides and destroys the system tray icon.
	/// </summary>
	private void KillTrayIcon()
	{
		NiSystemTray.Visible = false;
		NiSystemTray.Dispose();
	}

	/// <summary>
	/// If this form is <see cref="FormWindowState.Minimized"/> then hide it instead.
	/// </summary>
	private void HideInsteadOfMinimize()
	{
		if (WindowState == FormWindowState.Minimized)
			Hide();
	}

	/// <summary>
	/// Returns true if the error was logged.
	/// </summary>
	private bool TryToLogError(string? errorMessage)
	{
		if (errorMessage != null && _configurationService.Common.ErrorsToIgnore.None(x => errorMessage.Contains(x)))
		{
			_logger.LogError(errorMessage);
			return true;
		}

		return false;
	}

	#region GUI events
	private void ShortcutMenuItemOnClick(object? sender, EventArgs e)
	{
		if (sender is not ToolStripMenuItem senderAsToolStripMenuItem)
			return;

		if (senderAsToolStripMenuItem.Tag is not ShortcutMenuForStarting shortcutMenuForStarting)
			return;

		string? errorMessage = _systemTrayMenuController.StartShortcut(shortcutMenuForStarting);
		TryToLogError(errorMessage);
	}

	private void MainGui_Load(object? sender, EventArgs e)
	{
		Text = $"{Text} v{Application.ProductVersion}";
		Hide();
	}

	private void BtnOpenSettings_Click(object sender, EventArgs e)
	{
		string? errorMessage = _mainGuiController.OpenSettings();

		if (TryToLogError(errorMessage))
			MessageBoxExt.ShowError(errorMessage!);
	}

	private void MainGui_Resize(object sender, EventArgs e)
	{
		HideInsteadOfMinimize();
	}

	private void BtnConfigureStartup_Click(object sender, EventArgs e)
	{
		bool autoStarts = _mainGuiController.ConfigureStartup();
		MessageBoxExt.ShowInfo(autoStarts ? "This application now automatically starts when your operating system starts." : "This application no longer automatically starts when your operating system starts.", "Configured automatic start");
	}

	private void TsmiToggleVisibility_Click(object? sender, EventArgs e)
	{
		if (_isVisible)
			Hide();
		else
		{
			Show();
			Activate();
		}
	}

	private void TsmiExit_Click(object? sender, EventArgs e)
	{
		_systemTrayMenuController.Exit();
	}

	private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
	{
		if (e.CloseReason == CloseReason.UserClosing)
		{
			// If the user closed this form, then hide it instead.
			e.Cancel = true;
			Hide();
		}
		else
		{
			// If something besides the user wants to close this form, then prevent the system tray icon from remaining there and let it close.
			KillTrayIcon();
		}
	}

	private void BtnOpenShortcutsFolder_Click(object sender, EventArgs e)
	{
		_mainGuiController.OpenShortcutsFolder();
	}

	private void BtnRestartThisApplication_Click(object sender, EventArgs e)
	{
		_mainGuiController.RestartThisApplication();
	}
	#endregion
}
