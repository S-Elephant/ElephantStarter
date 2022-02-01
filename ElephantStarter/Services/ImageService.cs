using ElephantStarter.Domain.Services;
using Svg;

namespace ElephantStarter.Services
{
	/// <summary>
	/// Image service.
	/// </summary>
	public class ImageService : IImageService
	{
		private const string BasePath = "Images\\";

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public Bitmap AutoStart { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public Bitmap Exit { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public Bitmap Folder { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public Bitmap Restart { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public Bitmap Settings { get; }

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public Bitmap ToggleVisibility { get; }

		/// <summary>
		/// Constructor.
		/// </summary>
		public ImageService()
		{
			AutoStart = LoadFromSvgFileFromBasePath("AutoStart.svg");
			Exit = LoadFromSvgFileFromBasePath("Exit.svg");
			Folder = LoadFromSvgFileFromBasePath("Folder.svg");
			Restart = LoadFromSvgFileFromBasePath("Restart.svg");
			Settings = LoadFromSvgFileFromBasePath("Settings.svg");
			ToggleVisibility = LoadFromSvgFileFromBasePath("ToggleVisibility.svg");
		}

		private static Bitmap LoadFromSvgFileFromBasePath(string relativePathInclExtension)
		{
			return LoadFromSvgFile(BasePath + relativePathInclExtension);
		}

		private static Bitmap LoadFromSvgFile(string pathInclExtension)
		{
			return SvgDocument.Open(pathInclExtension).Draw();
		}
	}
}
