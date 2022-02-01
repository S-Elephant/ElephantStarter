using System.Text.Json;
using ElephantStarter.Domain.RecentlyUsed;

namespace ElephantStarter.Persistence
{
	/// <summary>
	/// Recently used default implementation.
	/// </summary>
	public class RecentlyUsed<TPersistentType> : IRecentlyUsed<TPersistentType>
	{
		/// <summary>
		/// Includes extension.
		/// </summary>
		private const string RecentlyUsedItemsFilename = "RecentlyUsedItems.json";

		/// <summary>
		/// The maximum amount of recently used items allowed.
		/// If this value is equal or smaller than 0 then the recently used items are considered disabled.
		/// </summary>
		private readonly int _maxItems;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="maxItems">If this value is equal or smaller than 0 then the recently used items are considered disabled.</param>
		public RecentlyUsed(int maxItems)
		{
			_maxItems = maxItems;
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public bool Add(TPersistentType newItem)
		{
			if (IsDisabled())
				return false;

			try
			{
				// Get all items.
				List<TPersistentType> allItems = Get();

				// Handle duplicates by moving it to the last position in the list.
				// If there's a duplicate then don't limit the maximum amount of items (because the item count doesn't change).
				if (allItems.Contains(newItem))
				{
					// If the new item is already the last item then nothing would change. Therefore return.
					if (EqualityComparer<TPersistentType>.Default.Equals(allItems.Last(), newItem))
						return false;

					allItems.Remove(newItem);
				}
				else
				{
					// If there're any items then limit the maximum amount of items.
					LimitItems(allItems, _maxItems);
				}

				// Add the new item.
				allItems.Add(newItem);

				// Serialize.
				string jsonString = JsonSerializer.Serialize(allItems, typeof(List<TPersistentType>), new JsonSerializerOptions { WriteIndented = true });

				// Save to disk.
				File.WriteAllText(RecentlyUsedItemsFilename, jsonString);
			}
			catch
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public List<TPersistentType> Get()
		{
			try
			{
				// If recently used items are disabled or the file doesn't exist then return an empty list.
				if (IsDisabled() || !File.Exists(RecentlyUsedItemsFilename))
					return new List<TPersistentType>();

				// Get raw json string.
				string jsonString = File.ReadAllText(RecentlyUsedItemsFilename);

				// Deserilize.
				List<TPersistentType>? allItems = JsonSerializer.Deserialize<List<TPersistentType>>(jsonString);

				// If something went wrong then return an empty list.
				if (allItems == null)
					return new List<TPersistentType>();

				// Limit items.
				LimitItems(allItems, _maxItems);

				// Return the deserialized values.
				return allItems.Cast<TPersistentType>().ToList();
			}
			catch
			{
				// If something went wrong then return an empty list.
				return new List<TPersistentType>();
			}
		}

		private bool IsDisabled() => _maxItems <= 0;

		private static void LimitItems(List<TPersistentType> items, int maxItems)
		{
			while (items.Count > maxItems)
				items.RemoveAt(0);
		}
	}
}
