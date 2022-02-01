using ElephantStarter.Persistence;

namespace ElephantStarter.ShortcutSorting
{
	/// <summary>
	/// <see cref="ShortcutMenuDto"/> sorting interface.
	/// </summary>
	public interface IShortcutSorter
	{
		/// <summary>
		/// Sorts the <see cref="ShortcutMenuDto"/>'s.
		/// </summary>
		IOrderedEnumerable<ShortcutMenuDto> Sort(IEnumerable<ShortcutMenuDto> shortcuts);
	}
}
