using ElephantStarter.Persistence;

namespace ElephantStarter.ShortcutSorting
{
	/// <summary>
	/// Sorts the <see cref="ShortcutMenuDto"/>'s by <see cref="ShortcutMenuDto.IsFolder"/>, then by <see cref="ShortcutMenuDto.Name"/>.
	/// </summary>
	public class ShortcutSorterByFolderThenName : IShortcutSorter
	{
		/// <summary>
		/// Sort by <see cref="ShortcutMenuDto.IsFolder"/>, then by <see cref="ShortcutMenuDto.Name"/>.
		/// </summary>
		public IOrderedEnumerable<ShortcutMenuDto> Sort(IEnumerable<ShortcutMenuDto> shortcuts)
		{
			return shortcuts.OrderBy(shortcut => shortcut.IsFolder).ThenBy(shortcut => shortcut.Name);
		}
	}
}
