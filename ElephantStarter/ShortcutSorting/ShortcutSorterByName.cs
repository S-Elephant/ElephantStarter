using ElephantStarter.Persistence;

namespace ElephantStarter.ShortcutSorting
{
	/// <summary>
	/// Sorts the <see cref="ShortcutMenuDto"/>'s by <see cref="ShortcutMenuDto.Name"/>.
	/// </summary>
	public class ShortcutSorterByName : IShortcutSorter
	{
		/// <summary>
		/// Sort by <see cref="ShortcutMenuDto.Name"/>.
		/// </summary>
		public IOrderedEnumerable<ShortcutMenuDto> Sort(IEnumerable<ShortcutMenuDto> shortcuts)
		{
			return shortcuts.OrderBy(shortcut => shortcut.Name);
		}
	}
}
