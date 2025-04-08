using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Represents a room in the dungeon with a description, item and monster.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Gets the description of the room.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the item present in the room.
        /// </summary>
        public Item Item { get; private set; }

        /// <summary>
        /// Gets the monster present in the room, if any.
        /// </summary>
        public Monster Monster { get; private set; }

        /// <summary>
        /// A flag to track if the monster is hidden or not.
        /// </summary>
        private bool isMonsterHidden = true;

        /// <summary>
        /// Initialises a new instance of <see cref="Room"/> class.
        /// </summary>
        /// <param name="description">The description of the room.</param>
        /// <param name="item">The item in the room.</param>
        /// <param name="monster">The monster in the room, if any.</param>
        public Room(string desc, Item item = null, Monster monster = null)
        {
            Description = desc;
            Item = item;
            Monster = monster;
        }

        /// <summary>
        /// Returns the item in the room, or "no items" if none exists.
        /// </summary>
        /// <returns>A string representing the item in the room, or "no items" if none.</returns>
        public string GetItemName() => Item != null ? Item.Name : "no items";

        /// <summary>
        /// Checks if the monster is visible (exists and hidden).
        /// </summary>
        /// <returns>True if the monster is visible, otherwise false.</returns>
        public bool IsMonsterVisible() => Monster != null && isMonsterHidden;

        /// <summary>
        /// Removes the item from the room.
        /// </summary>
        public void RemoveItem() => Item = null;

        /// <summary>
        /// Removes the monster from the room by setting it to null.
        /// </summary>
        public void RemoveMonster() => Monster = null;

        /// <summary>
        /// Hides the monster in the room.
        /// </summary>
        public void HideMonster() => isMonsterHidden = false;

        /// <summary>
        /// Resets the monster's visibility to hidden, making it appear again.
        /// </summary>
        public void ResetMonster() => isMonsterHidden = true;
    }
}
