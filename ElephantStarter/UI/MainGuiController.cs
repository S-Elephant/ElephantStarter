using System.Diagnostics.CodeAnalysis;
using Elephant.Common;
using ElephantStarter.Configurations;
using ElephantStarter.Domain.Configuration;

namespace ElephantStarter.UI
{
	/// <summary>
	/// Main GUI controller interface.
	/// </summary>
	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileNameMustMatchTypeName", Justification = "Local interface.")]
	public interface IMainGuiController
	{
		/// <summary>
		/// Attempts to open the settings. Returns null if success; otherwise, returns the error message.
		/// </summary>
		string? OpenSettings();

		/// <summary>
		/// Adds or removes this application from the operating system startup. Returns true if it auto-starts.
		/// </summary>
		bool ConfigureStartup();

		/// <summary>
		/// Opens the folder that contains all shortcuts for this application.
		/// </summary>
		void OpenShortcutsFolder();

		/// <summary>
		/// Restarts this application.
		/// </summary>
		void RestartThisApplication();
	}

	/// <summary>
	/// Main GUI controller.
	/// </summary>
	public class MainGuiController : IMainGuiController
	{
		private readonly IConfigurationService _configurationService;

		/// <summary>
		/// Constructor.
		/// </summary>
		public MainGuiController(IConfigurationService configurationService)
		{
			_configurationService = configurationService;
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public string? OpenSettings()
		{
			string arguments = GetApplicationSettingsJsonPath();
			ProcessStarter.IProcessStartResult processStartResult = ProcessStarter.StartProcess("notepad++", arguments, null, true);

			if (processStartResult.HasError)
				processStartResult = ProcessStarter.StartProcess("notepad", arguments);

			return processStartResult.ErrorMessage;
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public bool ConfigureStartup()
		{
			if (_configurationService.Common.LaunchOnWindowsStartup)
			{
				StartOnOsStart.RegisterInStartup(_configurationService.Common.ApplicationName, Application.ExecutablePath);
				return true;
			}

			StartOnOsStart.DeregisterFromStartup(_configurationService.Common.ApplicationName);
			return false;
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public void OpenShortcutsFolder()
		{
			ProcessStarter.StartProcess(Path.Combine(Application.StartupPath, "Shortcuts"), null, null, true);
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public void RestartThisApplication()
		{
			Application.Restart();
		}

		private static string GetApplicationSettingsJsonPath()
		{
			return Path.Combine(Environment.CurrentDirectory, Constants.SettingsJsonFilename);
		}
	}
}
