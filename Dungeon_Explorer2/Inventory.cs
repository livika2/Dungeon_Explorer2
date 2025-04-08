using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Represents a player's inventory containing collectible items.
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// Internal list storing the collected items.
        /// </summary>
        private List<Item> _items = new List<Item>();

        /// <summary>
        /// Adds an item to the inventory.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(Item item) => _items.Add(item);

        /// <summary>
        /// Lists all items currently in the inventory as a string.
        /// </summary>
        /// <returns>A comma-separated string of item names, or a message if empty.</returns>
        public string ListItems() => _items.Any() ? string.Join(", ", _items.Select(i => i.Name)) : "empty.";

        /// <summary>
        /// Gets all items of a specific type from the inventory.
        /// </summary>
        /// <typeparam name="T">The type of item to retrieve.</typeparam>
        /// <returns>An enumerable collection of items of the specified type.</returns>
        public IEnumerable<T> GetItemsOfType<T>() where T : Item => _items.OfType<T>();

        /// <summary>
        /// Removes a specific item from the inventory if it exists.
        /// </summary>
        /// <param name="item">The item to be removed from the inventory.</param>
        public void Remove(Item item) => _items.Remove(item);
    }
}
