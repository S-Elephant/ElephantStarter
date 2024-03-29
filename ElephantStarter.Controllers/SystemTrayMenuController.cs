﻿using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using ElephantStarter.Domain;
using ElephantStarter.Domain.Gui;
using ElephantStarter.Domain.RecentlyUsed;

namespace ElephantStarter.Controllers
{
	/// <summary>
	/// System tray menu controller interface.
	/// </summary>
	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileNameMustMatchTypeName", Justification = "Local interface.")]
	public interface ISystemTrayMenuController
	{
		/// <summary>
		/// The <see cref="Action"/> to execute when the user wants to exit.
		/// </summary>
		Action Exit { get; }

		/// <summary>
		/// The <see cref="Action"/> to execute after the recently used history was changed.
		/// </summary>
		Action? RefreshRecentlyUsedAction { get; set; }

		/// <summary>
		/// The main GUI.
		/// </summary>
		IMainGui? MainGui { get; set; }

		/// <summary>
		/// Starts the process and returns null if success. On failure it will return the error message.
		/// </summary>
		string? StartShortcut(IShortcutMenuForStarting shortcutMenuForStarting);
	}

	/// <summary>
	/// System tray menu controller.
	/// </summary>
	public class SystemTrayMenuController : ISystemTrayMenuController
	{
		private readonly IRecentlyUsed<string> _recentlyUsed;

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public Action Exit { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public Action? RefreshRecentlyUsedAction { get; set; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public IMainGui? MainGui { get; set; }

		/// <summary>
		/// Constructor.
		/// </summary>
		public SystemTrayMenuController(IRecentlyUsed<string> recentlyUsed, Action exitAction)
		{
			_recentlyUsed = recentlyUsed;
			Exit = exitAction;
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public string? StartShortcut(IShortcutMenuForStarting shortcutMenuForStarting)
		{
			// Expand environment variables if required.
			string? workingDirectory = null;
			if (shortcutMenuForStarting.WorkingDirectory != null)
				workingDirectory = Environment.ExpandEnvironmentVariables(shortcutMenuForStarting.WorkingDirectory);

			// Start process.
			string? errorMessage = StartProcess(shortcutMenuForStarting.LnkFilePath, shortcutMenuForStarting.Arguments, workingDirectory);

			if (errorMessage != null)
				return errorMessage;

			MainGui?.Hide();

			if (shortcutMenuForStarting.LnkFilePath != null)
			{
				// Attempt to add a recently used item to the history.
				bool isRecentlyUsedRefreshRequired = _recentlyUsed.Add(shortcutMenuForStarting.LnkFilePath);

				// If the history changed then invoke the recently used refresh action.
				if (isRecentlyUsedRefreshRequired)
					RefreshRecentlyUsedAction?.Invoke();
			}

			return null;
		}

		private static string? StartProcess(string? fullPath, string? arguments = null, string? workingDirectory = null)
		{
			if (fullPath == null)
				return "No path."; // Error, no path.

			// Create and initialize ProcessStartInfo.
			ProcessStartInfo processStartInfo = new()
			{
				FileName = fullPath,
				Arguments = arguments ?? string.Empty,
				UseShellExecute = true, // Is required for starting .lnk files and for starting with admin privileges.
			};
			if (workingDirectory != null)
				processStartInfo.WorkingDirectory = workingDirectory;

			try
			{
				// Try to start it without admin privileges.
				Process.Start(processStartInfo);
			}
			catch
			{
				try
				{
					// Try to start it with admin privileges.
					processStartInfo.Verb = "runas";
					Process.Start(processStartInfo);
				}
				catch (Exception exception)
				{
					return exception.ToString(); // Error, see exception details.
				}
			}

			return null; // All went well.
		}
	}
}