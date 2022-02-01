using ElephantStarter.Services;

namespace ElephantStarter.UI
{
	/// <summary>
	/// Application shortcut button (custom control).
	/// </summary>
	public partial class AppButton : UserControl
	{
		/// <summary>
		/// The shortcut <see cref="Image"/>.
		/// </summary>
		public Bitmap? Image { set => BtnMain.Image = value; }

		/// <summary>
		/// The shortcut <see cref="Button"/>.
		/// </summary>
		public Button Button { get => BtnMain; set => BtnMain = value; }

		/// <summary>
		/// The shortcut button <see cref="ToolTip"/>.
		/// </summary>
		public string ToolTipText { set => _toolTip.SetToolTip(Button, value); }

		private readonly ToolTip _toolTip = new();

		/// <summary>
		/// Constructor.
		/// </summary>
		public AppButton(IThemeService themeService)
		{
			InitializeComponent();
			themeService.ApplyTheme(BtnMain);
			_toolTip.ShowAlways = true;
		}
	}
}
