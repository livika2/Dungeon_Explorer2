using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Represents a player, inheriting from Creature, with inventory and item interaction capabilities.
    /// </summary>
    public class Player : Creature
    {
        /// <summary>
        /// Player's inventory for storing items.
        /// </summary>
        private Inventory _inventory = new Inventory();

        /// <summary>
        /// Initializes a new player with a name and health.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <param name="health">The starting health value.</param>
        public Player(string name, int health) : base(name, health)
        {
            Name = name;
            Health = health;
        }

        /// <summary>
        /// Picks up an item and adds it to the player's inventory.
        /// It may also affect the player's health if the item is special.
        /// </summary>
        /// <param name="item">The item to pick up.</param>
        public void PickUpItem(Item item)
        {
            item.Use(this);

            // Handle key fragment combination before adding the item
            if (item is KeyFragment)
            {
                // Look for existing key fragments in inventory
                var keyFragments = GetItemsOfType<KeyFragment>().ToList();

                // Add the current one to the temp list
                keyFragments.Add((KeyFragment)item);

                if (keyFragments.Count == 2)
                {
                    // Remove both fragments from inventory
                    _inventory.Remove(keyFragments[0]); 
                    _inventory.Remove(keyFragments[1]); 

                    Console.WriteLine("You combined two key fragments into a full key!");
                    _inventory.Add(new Key()); // Add full key
                    return; 
                }

                else
                {
                    // Adding the first half
                    _inventory.Add(item);
                    return;
                }
            }

            // Only store the item if it's not consumable
            if (item is not Poison && item is not Potion)
                _inventory.Add(item);
        }

        /// <summary>
        /// Gets the contents of the player's inventory as a string.
        /// </summary>
        /// <returns>A string representing the contents of the inventory.</returns>
        public string GetInventoryContents() => _inventory.ListItems();

        /// <summary>
        /// Retrieves all items of a specific type from the inventory.
        /// </summary>
        /// <typeparam name="T">The item type to filter.</typeparam>
        /// <returns>A collection of items matching the type.</returns>
        public IEnumerable<T> GetItemsOfType<T>() where T : Item => _inventory.GetItemsOfType<T>();
    }
}
