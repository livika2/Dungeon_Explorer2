using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Represents a complete key that the player can use to unlock something.
    /// </summary>
    public class Key : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class with a default name.
        /// </summary>
        public Key()
        {
            Name = "key"; // Set the item's name to "key"
        }

        /// <summary>
        /// Defines what happens when the player uses the key.
        /// </summary>
        /// <param name="player">The player using the key.</param>
        public override void Use(Player player)
        {
            // Inform the player that they now have a key
            Console.WriteLine("You now have a key!");
        }
    }
}
