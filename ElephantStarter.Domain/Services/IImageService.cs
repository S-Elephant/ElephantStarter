using System.Drawing;

namespace ElephantStarter.Domain.Services;

/// <summary>
/// Image service.
/// </summary>
public interface IImageService
{
	/// <summary>
	/// Auto start bitmap.
	/// </summary>
	public Bitmap AutoStart { get; }

	/// <summary>
	/// Exit bitmap.
	/// </summary>
	Bitmap Exit { get; }

	/// <summary>
	/// Folder bitmap.
	/// </summary>
	Bitmap Folder { get; }

	/// <summary>
	/// Restart bitmap.
	/// </summary>
	Bitmap Restart { get; }

	/// <summary>
	/// Settings (gear) bitmap.
	/// </summary>
	Bitmap Settings { get; }

	/// <summary>
	/// ToggleVisibility bitmap.
	/// </summary>
	Bitmap ToggleVisibility { get; }
}