using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using ElephantStarter.Configurations;
using ElephantStarter.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElephantStarter
{
	/// <summary>
	/// Program.cs.
	/// </summary>
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		[SuppressMessage("Style", "IDE0063:Use simple 'using' statement", Justification = "Reviewed")]
		private static void Main()
		{
			ForceSetCurrentWorkingDirectory();

			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			IConfigurationBuilder builder = new ConfigurationBuilder()
				.AddCustomConfiguration();
			IConfigurationRoot configuration = builder.Build();

			ServiceCollection services = new();
			new ServiceConfigurator().ConfigureServices(services, configuration);

			using (ServiceProvider serviceProvider = services.BuildServiceProvider())
			{
				MainGui mainGui = serviceProvider.GetRequiredService<MainGui>();
				Application.Run(mainGui);
			}
		}

		/// <summary>
		/// Set current working directory to current executable path.
		/// </summary>
		private static void ForceSetCurrentWorkingDirectory()
		{
			string? newCurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			if (newCurrentDirectory == null)
				throw new NullReferenceException($"Unable to set current working directory because {nameof(newCurrentDirectory)} is null.");
			Environment.CurrentDirectory = newCurrentDirectory;
		}
	}
}