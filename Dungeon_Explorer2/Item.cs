using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Abstract base class for all collectible items.
    /// </summary>
    public abstract class Item : ICollectible
    {
        /// <summary>
        /// The item's name.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Defines how the item affects a player when used.
        /// </summary>
        /// <param name="player">The player using the item.</param>
        public abstract void Use(Player player);
    }
}
