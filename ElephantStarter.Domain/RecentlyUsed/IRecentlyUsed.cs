namespace ElephantStarter.Domain.RecentlyUsed
{
	/// <summary>
	/// Recently used shortcuts interface.
	/// </summary>
	public interface IRecentlyUsed<TPersistentType>
	{
		/// <summary>
		/// Add a new recently used item.
		/// Returns true if a change to the recently used items was made.
		/// </summary>
		bool Add(TPersistentType item);

		/// <summary>
		/// Gets the list of recently used item.
		/// </summary>
		List<TPersistentType> Get();
	}
}
